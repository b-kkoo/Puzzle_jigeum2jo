using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : UIBase
{

    public void ShowMenu()
    {
        GameManager.instance.UIManager.TimeTogle();
        ShowSoundCanvas();
        ShowInGameCanvas();
        GameManager.instance.UIManager.Hide("MenuCanvas"); ; //일시정지버튼 숨기기
        //TODO : 일시정지 버튼이 눌렸을때 일시정지버튼은 보이지 않게 하고, 다시하기버튼이 눌리면 일시정지버튼이 다시 보이는게 좋아보여요.
    }

    public void ShowSoundCanvas()
    {
        GameManager.instance.UIManager.Toggle("SoundCanvas");
    }

    public void ShowInGameCanvas()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != 0)
        {
            GameManager.instance.UIManager.Toggle("InGameCanvas");
        }
    }
}