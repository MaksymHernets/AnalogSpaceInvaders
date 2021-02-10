using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    private float LastTouch = 2f;
    private float PeriodTouch = 1f;

    public delegate void Click();
    public event Click EventClick;

    void Update()
    {
        LastTouch += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (LastTouch < PeriodTouch)
            {
                EventClick();
            }
            else
            {
                LastTouch = 0f;
            }
        }
    }
}
