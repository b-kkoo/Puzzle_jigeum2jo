using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : UIBase
{
    public void OnTitleButton()
    {
        SceneManager.LoadScene(0); // 타이틀로
        SceneManager.sceneLoaded += Title;
    }
    public void Title(Scene scene, LoadSceneMode mode)
    {
        GameManager.instance.UIManager.ClearDestroyUI();
        GameManager.instance.UIManager.Show("StartCanvas");
        SceneManager.sceneLoaded -= Title;
    }
    
}
