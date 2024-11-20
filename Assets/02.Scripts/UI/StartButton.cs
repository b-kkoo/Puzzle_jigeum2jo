using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButton : UIBase
{
    public void StartGameButton()
    {
        SceneManager.LoadScene(1); // 게임 씬으로 이동
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0) // 게임씬일때
        {
            GameManager.instance.UIManager.ClearDestroyUI();
            GameManager.instance.UIManager.Show("MenuCanvas");
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}