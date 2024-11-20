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
    GameManager.instance.UIManager.Show("MenuCanvas");
    //메뉴 캔버스가 보이게 했습니다.
    //TODO : 현재씬을 다시로드 하는것 보단, 계속하기(Resume)로 하는게 좋아 보여요! 일시정지버튼도 다시 보여야 할듯 합니다.
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
