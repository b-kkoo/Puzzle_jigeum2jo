using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    public void Showpopup(int index)
    {
        switch (index)
        {
            case 0:
                UIManager.instance.Show("StartButton");
                break;
            case 1:
                UIManager.instance.Show("SettingButton");
                break;
            case 2:
                UIManager.instance.Show("QuitButton");
                break;
        }
        Destroy(gameObject);
    }
}
