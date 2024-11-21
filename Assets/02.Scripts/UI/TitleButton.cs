using UnityEngine.SceneManagement;

public class TitleButton : UIBase
{
    public void OnTitleButton()
    {
        SceneManager.LoadScene(0); // 타이틀로
        GameManager.instance.SoundManager.PlayMusic(GameManager.instance.SoundManager.mainMusicClip);
        SceneManager.sceneLoaded += Title;
        GameManager.instance.UIManager.OnTime();
    }
    public void Title(Scene scene, LoadSceneMode mode)
    {
        GameManager.instance.UIManager.ClearDestroyUI();
        GameManager.instance.UIManager.Show("StartCanvas");
        SceneManager.sceneLoaded -= Title;
    }
    
}
