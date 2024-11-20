using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButton : UIBase
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("MapTestScene"); // 게임 씬으로 이동
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MapTestScene")
        {
            GameManager.instance.UIManager.Show("MenuCanvas");
        }
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
