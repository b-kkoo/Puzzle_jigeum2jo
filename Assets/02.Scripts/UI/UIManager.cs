using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform Canvas;
    private bool isPaused = false;
    private List<UIBase> uiList = new List<UIBase>();

    public static UIManager instance;
    private void Awake()
    { 
        GameManager.instance.UIManager = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameManager.instance.UIManager.Show("StartCanvas");
        }
    }

    public void Show(string uiName)
    {
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
        UIBase go = uiList.Find(obj => obj.name == uiName);
        
        uiList.Remove(go);
        Destroy(go.gameObject);
    }
    public void Toggle(string uiName)
    {
        UIBase go = uiList.Find(obj => obj.name == uiName);

        //uiList에 넣은 go 찾고
        if (go == null) // 없으면 생성
        {
            Show(uiName);
            go = uiList.Find(obj => obj.name == uiName);
        }
        else //있으면 없애
        {
            Hide(uiName);
        }
    }

    /// <summary>
    /// 일시정지버튼 (Temporary Stop)
    /// </summary>
    public void TimeTogle()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void OnTime()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
    
    public void ClearDestroyUI() // 모든 UI를 디스트로이
    {
        uiList.RemoveAll(ui => ui == null);
    }
}
