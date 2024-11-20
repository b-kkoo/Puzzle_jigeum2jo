using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : UIBase
{
    public void Title()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
