using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FirstStoryStart : MonoBehaviour
{
    public StoryTextData StoryTextData = new();
    public TextMeshProUGUI Story;
    public TextMeshProUGUI PlayerText;
    public Animator PlayerDeath;
    public GameObject Player;
    public GameObject TutoCanvas;
    public GameObject StoryPlayer;
    // Start is called before the first frame update
    void Start()
    {
        BGMManager.instance.StopBGM();
        StartCoroutine(BlackPannel.instance.FadeOut());
        PlayerDeath.SetTrigger("Death");
        StartCoroutine(StoryStart());
        Debug.Log("½ÇÇàµÊ0");
        DataManager.Instance.data.isFirstPlay = false;
    }

    IEnumerator StoryStart() {
        if (DataManager.Instance.data.CurrentStoryNumber == 1) yield return new WaitForSeconds(1.5f);
        if (DataManager.Instance.data.CurrentStoryNumber == 4) {
            yield return StartCoroutine(Typing(PlayerText, StoryTextData.StoryText[DataManager.Instance.data.CurrentStoryNumber], 0.05f));
            yield return new WaitForSeconds(2f);
            yield return StartCoroutine(BlackPannel.instance.FadeIn());
            StoryPlayer.SetActive(false);
            Story.text = "";
            PlayerText.text = "";
            Instantiate(Player, new Vector3(0, -2.5f, 0), Quaternion.identity);
            TutoCanvas.SetActive(true);
            yield return StartCoroutine(BlackPannel.instance.FadeOut());
            yield break;
        }
        yield return StartCoroutine(Typing(Story, StoryTextData.StoryText[DataManager.Instance.data.CurrentStoryNumber], 0.1f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(StoryStart());
    }
    IEnumerator Typing(TextMeshProUGUI typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
        DataManager.Instance.data.CurrentStoryNumber++;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Started());
        }
    }
    IEnumerator Started() {
        yield return StartCoroutine(BlackPannel.instance.FadeIn());
        PrototypeHero.instance.Warp(new Vector3(-6.5f, -2.55f, 0));
        BlackPannel.instance.NextScene("MainVillage");
    }
}
//BlackPannel.instance.NextScene("MainVillage");