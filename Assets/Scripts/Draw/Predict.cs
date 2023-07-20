using System.IO;
using TensorFlowLite;
using UnityEngine;

public class Predict : MonoBehaviour
{
    private float[,,,] inputArray;
    private float[] _outputs = new float[7];
    private Interpreter _interpreter;
    public Camera inputCamera;
    public static int result = 0;
    //private Texture2D _inputTexture2D;

    private int model_width;
    private int model_height;

    bool start = false;

    private void Start()
    {
        string modelPath = "Assets/tfliteModel/model_v7.tflite";
        byte[] model = File.ReadAllBytes(modelPath);

        var options = new InterpreterOptions()
        {
            threads = 2,
            useNNAPI = false,
        };

        _interpreter = new Interpreter(model, options);

        var inputShape = _interpreter.GetInputTensorInfo(0).shape;
        var inputWidth = inputShape[2];
        var inputHeight = inputShape[1];
        model_width = inputWidth;
        model_height = inputHeight;
        inputArray = new float[1, inputHeight, inputWidth, inputShape[3]];
        _interpreter.ResizeInputTensor(0, new int[] { 1, inputHeight, inputWidth, inputShape[3] });
        _interpreter.AllocateTensors();

        //_inputTexture2D = new Texture2D(Camera.main.pixelWidth, Camera.main.pixelHeight, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        if (start && Input.GetKeyDown(KeyCode.V) && !ControlCanvas.SettingMenuStatus)
        {
            start = false;
            var inputTexture = new RenderTexture(inputCamera.pixelWidth, inputCamera.pixelHeight, 0);
            inputCamera.targetTexture = inputTexture;
            inputCamera.Render();
            var tmp = RenderTexture.GetTemporary(model_width, model_height, 0);

 
            Texture2D resizedTexture = new Texture2D(model_width, model_height, TextureFormat.RGB24, false);


            Graphics.Blit(inputTexture, tmp);

            RenderTexture.active = tmp;
            resizedTexture.ReadPixels(new Rect(0, 0, resizedTexture.width, resizedTexture.height), 0, 0);
            resizedTexture.Apply();
            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(tmp);

            for (int y = 0; y < resizedTexture.height; y++)
            {
                for (int x = 0; x < resizedTexture.width; x++)
                {
                    Color color = resizedTexture.GetPixel(x, y);

                    inputArray[0, y, x, 0] = color.r*255f;
                    inputArray[0, y, x, 1] = color.g*255f;
                    inputArray[0, y, x, 2] = color.b*255f;
                }
            }

            _interpreter.SetInputTensorData(0, inputArray);
            _interpreter.Invoke();
            _interpreter.GetOutputTensorData(0, _outputs);

            var number = 0;
            var max = 0f;
            for (var i = 0; i < _outputs.Length; i++)
            {
                Debug.Log("Number"+i+":"+_outputs[i]);
                if (!(_outputs[i] > max)) continue;
                number = i;
                max = _outputs[i];
            }
            inputCamera.targetTexture = null;
            result = number;
        }
        else if(Input.GetKeyDown(KeyCode.V))
        {
            start = true;
        }
    }

    private void OnDestroy()
    {
        _interpreter?.Dispose();
    }

}
