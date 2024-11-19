using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void Title()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
