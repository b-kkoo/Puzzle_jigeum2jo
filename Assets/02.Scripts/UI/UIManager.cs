using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform Canvas;
    
    private List<UIBase> uiList = new List<UIBase>();

    public static UIManager instance;

    private void Update()
    {
        /*Debug.Log(Time.timeScale);*/
    }

    private void Awake()
    { 
        GameManager.instance.UIManager = this;
    }
   
    public void Show(string uiName)
    {
        TimeTogle();
        UIBase go = Resources.Load<UIBase>("UI/" + uiName);
        // 폴더에서 찾은것을 go에 저장
        UIBase ui = Instantiate(go);
        // go에 저장한것을 복제
        ui.name = ui.name.Replace("(Clone)", "");
        
        uiList.Add(ui);
        //ui를 uiList에 Add
    }
    public void Hide(string uiName)
    {
        TimeTogle();
        UIBase go = uiList.Find(obj => obj.name == uiName);
        
        uiList.Remove(go);
        Destroy(go.gameObject);
    }
    public void Toggle(string uiName)
    {
        /*Debug.Log(uiList.Count);
        for (int i = 0; i < uiList.Count; i++)
        {
            Debug.Log(uiList[i].name);

        }*/
        UIBase go = uiList.Find(obj => obj.name == uiName);
        
        //uiList에 넣은 obj 찾고
        if (go == null) // 없으면 생성
        {
            Show(uiName); 
            go = uiList.Find(obj => obj.name == uiName);
        }
        else //있으면 없애
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == 0)
            {
                Hide(uiName);
            }
        }
        
    }

    public void TimeTogle()
    {
        Time.timeScale = (Time.timeScale <= 0.9 ? 0f : 1f);
    }
    
    public void ClearDestroyUI()
    {
        uiList.RemoveAll(ui => ui == null);
    }
}
