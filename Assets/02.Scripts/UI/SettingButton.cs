using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{

    public void ShowMenu()
    {
        ShowSoundCanvas();
        ShowMenuCanvas();
    }

    public void ShowSoundCanvas()
    {
        GameManager.instance.UIManager.Toggle("SoundCanvas");
    }

    public void ShowMenuCanvas()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != 0)
        {
            GameManager.instance.UIManager.Toggle("MenuCanvas");
        }
    }
}