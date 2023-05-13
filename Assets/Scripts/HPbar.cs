using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    private const float MAX_HP = 100f;
    public static float hp = MAX_HP;
    private Image hpBar;
    void Start()
    {
        hpBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = hp / MAX_HP;
    }
}
