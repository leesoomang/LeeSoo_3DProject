using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passivevalue;
    public Image uiBar;


    void Start()
    {
        curValue = startValue;
    }

    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    float GetPercentage()
    {
        return curValue / maxValue;
    }
    public void Subtract(float value)
    {
        curValue -= Mathf.Max(curValue - value, 0);
    }
    public void Add(float amount)
    {
        curValue = Mathf.Clamp(curValue + amount, 0f, maxValue);
    }
}
