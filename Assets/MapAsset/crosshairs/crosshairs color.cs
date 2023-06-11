using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshairscolor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Sprite[] color;

    // Update is called once per frame
    void Update()
    {
        int id = Predict.result;
        gameObject.GetComponent<Image>().sprite = color[id];
    }
}
