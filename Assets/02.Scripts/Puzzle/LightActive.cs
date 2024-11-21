using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActive : MonoBehaviour
{
    [SerializeField] private GameObject Light;
    
    private void OnEnable()
    {
        StartCoroutine(CoLight());
    }

    IEnumerator CoLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Light.SetActive(!Light.activeSelf);
        }
    }
}
