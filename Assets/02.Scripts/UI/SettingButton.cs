using UnityEngine.SceneManagement;

public class SettingButton : UIBase
{

    public void ShowMenu()
    {
        GameManager.instance.UIManager.TimeTogle();
        ShowSoundCanvas();
        ShowInGameCanvas();
        ShowMenuCanvas();
    }

    public void ShowSoundCanvas()
    {
        GameManager.instance.UIManager.Toggle("SoundCanvas");
    }

    public void ShowInGameCanvas()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameManager.instance.UIManager.Toggle("InGameCanvas");
        }
    }

    public void ShowMenuCanvas()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameManager.instance.UIManager.Toggle("MenuCanvas");
        }
    }
    
}