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

        GameObject ui = Instantiate(go);
        ui.name = ui.name.Replace("(Clone)", "");
        
        uiList.Add(ui);
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
        if (obj == null)
        {
            Show(uiName); // 없으면 생성
        }
        else
        {
            Hide(uiName);
        }
    }
}
