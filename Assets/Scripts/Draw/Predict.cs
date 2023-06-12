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
    private Texture2D _inputTexture2D;

    private void Start()
    {
        string modelPath = "Assets/tfliteModel/model_v5.tflite";
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
        inputArray = new float[1, inputHeight, inputWidth, inputShape[3]];
        _interpreter.ResizeInputTensor(0, new int[] { 1, inputHeight, inputWidth, inputShape[3] });
        _interpreter.AllocateTensors();

        _inputTexture2D = new Texture2D(inputWidth, inputHeight, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        if (LineGenerator.isDrawing && Input.GetKeyDown(KeyCode.V) && !ControlCanvas.SettingMenuStatus)
        {
            var inputTexture = new RenderTexture(_inputTexture2D.width, _inputTexture2D.height, 0);
            inputCamera.targetTexture = inputTexture;
            inputCamera.Render();

            RenderTexture.active = inputTexture;
            _inputTexture2D.ReadPixels(new Rect(0, 0, _inputTexture2D.width, _inputTexture2D.height), 0, 0);
            _inputTexture2D.Apply();
            RenderTexture.active = null;

            for (int y = 0; y < _inputTexture2D.height; y++)
            {
                for (int x = 0; x < _inputTexture2D.width; x++)
                {
                    Color color = _inputTexture2D.GetPixel(x, y);
                    inputArray[0, y, x, 0] = color.r;
                    inputArray[0, y, x, 1] = color.g;
                    inputArray[0, y, x, 2] = color.b;
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
    }

    private void OnDestroy()
    {
        _interpreter?.Dispose();
    }
}
