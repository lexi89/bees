using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillableBar : MonoBehaviour
{
    [SerializeField] Image _fill;

    /// <summary>
    /// Pass float from 0 to 1
    /// </summary>
    /// <param name="fillPercentage"></param>
    public void ShowFill(float fillPercentage)
    {
        _fill.fillAmount = fillPercentage;
    }
}
