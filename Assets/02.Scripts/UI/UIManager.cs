using System.Collections.Generic;
using UnityEngine;


/*public enum SceneIndex
{
    TitleScene,
    GameScene,
}*/
public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform Canvas;
    
    private List<GameObject> uiList = new List<GameObject>();

    public static UIManager instance;
    private void Awake()
    { 
        GameManager.instance.UIManager = this;
    }
   
    public void Show(string uiName)
    {
        GameObject go = Resources.Load<GameObject>("UI/" + uiName);
        // 폴더에서 찾은것을 go에 저장
        GameObject ui = Instantiate(go);
        // go에 저장한것을 복제
        ui.name = ui.name.Replace("(Clone)", "");
        
        uiList.Add(ui);
        //ui를 uiList에 Add
    }
    // UI 토글
    
    public void Hide(string uiName)
    {
        GameObject obj = uiList.Find(obj => obj.name == uiName);
        
        uiList.Remove(obj);
        Destroy(obj);
    }
    public void Toggle(string uiName)
    {
        GameObject obj = uiList.Find(obj => obj.name == uiName);
        //uiList에 넣은 obj 찾고
        if (obj == null) // 없으면 생성
        {
            Show(uiName); 
        }
        else //있으면 없애
        {
            Hide(uiName);
        }
    }
}
