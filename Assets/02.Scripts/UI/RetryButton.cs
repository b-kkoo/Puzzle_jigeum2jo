using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : UIBase
{
  public void Retry()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //현재 씬 로드
  }
}
