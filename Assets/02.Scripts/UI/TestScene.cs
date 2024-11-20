using UnityEngine;


public class TestScene : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.UIManager.Show("StartCanvas");
        GameManager.instance.UIManager.Show("MenuCanvas");
    }
}
