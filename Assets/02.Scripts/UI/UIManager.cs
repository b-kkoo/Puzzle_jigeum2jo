using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneIndex
{
    TitleScene,
    GameScene,
}
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject TitleUI;
    [SerializeField] private GameObject MenuUI;

    [SerializeField] private GameObject MenuBtn;

    [SerializeField] private GameObject RetryBtn;
    [SerializeField] private Transform canvas;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartCanvasShow()
    {
        Instantiate(TitleUI, canvas);
    }

    public void MenuCanvasShow()
    {
        Instantiate(MenuUI, canvas);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // 현재 진행중인 scene 불러오기
    }
    public void TitleButton()
    {
        SceneManager.LoadScene((int)SceneIndex.TitleScene);
        // title scene 불러오기
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene((int)SceneIndex.GameScene);
        // 게임 Scene 불러오기
    }
    public void OnMenu()
    {
        NowScene();
        bool isMenuOpen = UIMenu.activeSelf;
        UIMenu.SetActive(!isMenuOpen);
        Time.timeScale = isMenuOpen ? 1 : 0;
    }

    public void QuitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서 플레이 중지
#else
    Application.Quit(); // 빌드 후 실행 시 게임 종료
#endif
    }

    public void NowScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            MenuBtn.SetActive(false);
            RetryBtn.SetActive(false);
        }
    }
}
