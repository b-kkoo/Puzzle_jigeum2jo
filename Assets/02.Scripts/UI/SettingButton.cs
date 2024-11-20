using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    private GameObject menucanvas;
    private GameObject soundcanvas;
    public void ShowMenu()
    {
        ShowSoundCanvas();
        ShowMenuCanvas();
    }

    public void ShowSoundCanvas()
    {
        if (soundcanvas == null)
        {
            soundcanvas = GameManager.instance.UIManager.Show("SoundCanvas"); //생성
        }
        else
        {
            Destroy(soundcanvas);
            soundcanvas = null; 
        }
    }

    public void ShowMenuCanvas()
    {
        if (menucanvas == null)// 만약 메뉴캔버스가 없다면
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex != 0)
            {
                menucanvas = GameManager.instance.UIManager.Show("MenuCanvas"); //생성
            }
        }
        else
        {
            Destroy(menucanvas);
            menucanvas = null; 
        }
    }
}