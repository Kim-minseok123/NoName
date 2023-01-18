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
    public 
    // Start is called before the first frame update
    void Start()
    {
        BGMManager.instance.StopBGM();
        StartCoroutine(BlackPannel.instance.FadeOut());
        PlayerDeath.SetTrigger("Death");
        StartCoroutine(StoryStart());
        DataManager.Instance.data.isFirstPlay = false;
    }

    IEnumerator StoryStart() {
        if (DataManager.Instance.data.CurrentStoryNumber == 1) yield return new WaitForSeconds(1.5f);
        if (DataManager.Instance.data.CurrentStoryNumber == 4) {
            yield return StartCoroutine(Typing(PlayerText, StoryTextData.StoryText[DataManager.Instance.data.CurrentStoryNumber], 0.05f));
            yield return new WaitForSeconds(2f);
            yield return StartCoroutine(BlackPannel.instance.FadeIn());
            BlackPannel.instance.NextScene("MainVillage");
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
}
