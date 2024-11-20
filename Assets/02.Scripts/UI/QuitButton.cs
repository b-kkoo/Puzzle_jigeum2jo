using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : UIBase
{
    public void QuitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
