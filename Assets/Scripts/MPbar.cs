using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MPbar : MonoBehaviour
{
    private const float MAX_MP = 100f;
    public static float currentMP = MAX_MP;
    public float mpRecoveryRate = 10f;
    public float idleTime = 3f;
    private Image mpBar;
    
    private float previousMP;
    

    private Coroutine recoveryCoroutine;
    private Coroutine idleCoroutine;
    void Start()
    {
        mpBar = GetComponent<Image>();
        idleCoroutine = StartCoroutine(DelayRecoverMP());
    }

    void Update()
    {
        mpBar.fillAmount = currentMP / MAX_MP;
    }

    public void UseMP(float amount)
    {
        currentMP -= amount;
        if (currentMP < 0)
            currentMP = 0;

        if (recoveryCoroutine != null)
            StopCoroutine(recoveryCoroutine);

        if (idleCoroutine != null)
            StopCoroutine(idleCoroutine);
        idleCoroutine = StartCoroutine(DelayRecoverMP());
        
        mpBar.fillAmount = currentMP / MAX_MP;
    }

    private IEnumerator RecoverMP()
    {
        while (currentMP < MAX_MP)
        {
            
            currentMP += mpRecoveryRate * Time.deltaTime;
            if (currentMP > MAX_MP)
                currentMP = MAX_MP;

            mpBar.fillAmount = currentMP / MAX_MP;

            yield return null;
        }

        recoveryCoroutine = null;
    }

    private IEnumerator DelayRecoverMP()
    {
        yield return new WaitForSeconds(idleTime);

        recoveryCoroutine = StartCoroutine(RecoverMP());
    }


}
