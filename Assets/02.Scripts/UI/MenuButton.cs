using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private GameObject menucanvas;
    private GameObject soundcanvas;
    public void ShowMenu()
    {
        if (soundcanvas == null)
        {
            soundcanvas = UIManager.instance.Show("SoundCanvas");
        }
        else
        {
            Destroy(soundcanvas);
            //soundcanvas = null;
        }
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != 0)
        {
            if (menucanvas == null)// 만약 메뉴캔버스가 없다면
            {
                menucanvas = UIManager.instance.Show("MenuCanvas"); //생성
            }
            else
            {
                Destroy(menucanvas);
                //menucanvas = null; 
            }
        }
        
    }

}
