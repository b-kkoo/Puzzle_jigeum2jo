using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartButton : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("MapTestScene"); // 게임 씬으로 이동
    }
}
