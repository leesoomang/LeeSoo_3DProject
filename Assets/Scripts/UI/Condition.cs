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

    public void Add(float value)
    {
        curValue = Mathf.Clamp(curValue + value, 0f, maxValue);
    }




}
