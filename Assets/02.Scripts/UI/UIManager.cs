using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*public enum SceneIndex
{
    TitleScene,
    GameScene,
}*/
public class UIManager : MonoBehaviour
{
    [SerializeField ]List<GameObject> uiList = new List<GameObject>();
    [SerializeField] private Transform Canvas;

    public static UIManager instance;
    private void Awake()
    { 
        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
         GameManager.instance.UIManager = this;
    }
   
    public GameObject Show(string uiName)
    {
        GameObject go = uiList.Find(obj => obj.name == uiName);
        
        GameObject existingUI = GameObject.Find(uiName);
        /*if (existingUI != null)
        {
            return existingUI; // 이미 존재하면 해당 UI 반환
        }*/

        // 새로 인스턴스화
        /*GameObject instantiatedUI = Instantiate(go);
        instantiatedUI.name = uiName; // 이름 지정 (복제본 방지)*/
        Instantiate(go);
        return go;
    }
}
