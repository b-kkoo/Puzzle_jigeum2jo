using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
  public void OnRetryButton()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //현재 씬 로드
    SceneManager.sceneLoaded += OnRetry;
  }
  
  public void OnRetry(Scene scene, LoadSceneMode mode)
  {
    if (SceneManager.GetActiveScene().buildIndex != 0) // 게임씬일때
    {
      GameManager.instance.UIManager.ClearDestroyUI();
      GameManager.instance.UIManager.Show("MenuCanvas");
      SceneManager.sceneLoaded -= OnRetry;
    }
    
  }
  
}
