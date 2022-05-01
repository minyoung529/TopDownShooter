using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGaugeUI : MonoBehaviour
{
    [SerializeField]
    private Transform bar;
    
    public void ReloadGaugeNormal(float value)
    {
        bar.localScale = new Vector3(value, 1f, 1f);
    }
}
