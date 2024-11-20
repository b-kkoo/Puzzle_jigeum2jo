using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.UIManager.Show("StartCanvas");
    }

    
}
