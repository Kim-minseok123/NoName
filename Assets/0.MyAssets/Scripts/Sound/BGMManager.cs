using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    // Inspector 에표시할 배경음악 목록
    public BgmType[] BGMList;

    private AudioSource BGM;
    private string NowBGMname = "";
    public AudioMixer BGMmixer;
    public AudioMixer SFXmixer;
    public Slider BGMslider;
    public Slider SFXslider;
    void Awake()
    {
        if (instance != null) {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        BGM = gameObject.GetComponent<AudioSource>();
        BGM.loop = true;
        if (BGMList.Length > 0) PlayBGM(BGMList[0].name);
    }
    private void Start()
    {
        BGMslider.value = -20f;
        SFXslider.value = -20f;
        BGMAudioControl();
        SFXAudioControl();
    }
    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;

        for (int i = 0; i < BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
                NowBGMname = name;
            }
    }

    // Start is called before the first frame update

    public void BGMAudioControl()
    {
        float sound = BGMslider.value;
        if (sound == -40f) BGMmixer.SetFloat("BGM", -80);
        else BGMmixer.SetFloat("BGM", sound);
    }
    public void SFXAudioControl()
    {
        float sound = SFXslider.value;
        if (sound == -40f) SFXmixer.SetFloat("SFX", -80);
        else SFXmixer.SetFloat("SFX", sound);
    }
}
