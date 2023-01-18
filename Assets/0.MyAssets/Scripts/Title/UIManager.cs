using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject SettingUI;
    public GameObject TitleMenu;
    private void Awake()
    {
        if (instance != null) {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        DataManager.Instance.LoadGameData();
        StartCoroutine(BlackPannel.instance.FadeOut());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGameBtn() {
        StartCoroutine(StartGame());
    }
    public void SettingUIOnBtn() { Time.timeScale = 0f; SettingUI.SetActive(true); }
    public void SettingUIOffBtn() { Time.timeScale = 1f; SettingUI.SetActive(false); }
    public void ExitTheGameBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
    public IEnumerator StartGame() {
        BlackPannel blackPannel = BlackPannel.instance;
        yield return StartCoroutine(blackPannel.FadeIn());
        TitleMenu.SetActive(false);
        if (!DataManager.Instance.data.isFirstPlay)
            blackPannel.NextScene("MainVillage");
        else { blackPannel.NextScene("StoryStart"); }
    }
    public void OnApplicationQuit()
    {
        DataManager.Instance.SaveGameData();
    }
}
