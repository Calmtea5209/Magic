using UnityEngine;
using UnityEngine.UI;

public class ShowAllEffect : MonoBehaviour
{
    public string[] effectNames;
    public string[] effect2Names;
    public Transform[] effects;
    public Text text1;
    private int currentIndex = 0;

    void Start()
    {
        Instantiate(effects[currentIndex], new Vector3(0, 5, 0), Quaternion.identity);
    }

    void Update()
    {
        text1.text = (currentIndex + 1) + ":" + effectNames[currentIndex];

        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = effects.Length - 1;

            PlayEffect();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            currentIndex++;
            if (currentIndex >= effects.Length)
                currentIndex = 0;

            PlayEffect();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayEffect();
        }
    }

    void PlayEffect()
    {
        for (int i = 0; i < effect2Names.Length; i++)
        {
            if (effectNames[currentIndex] == effect2Names[i])
            {
                Instantiate(effects[currentIndex], new Vector3(0, 0.01f, 0), Quaternion.identity);
                return;
            }
        }

        Instantiate(effects[currentIndex], new Vector3(0, 5, 0), Quaternion.identity);
    }
}
