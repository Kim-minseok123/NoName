using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SetVolume : MonoBehaviour
{
    public AudioMixer BGMmixer;
    public AudioMixer SFXmixer;
    public Slider BGMslider;
    public Slider SFXslider;
    // Start is called before the first frame update
    private void Start()
    {
        BGMslider.value = -20f;
        SFXslider.value = -20f;
        BGMAudioControl();
        SFXAudioControl();
    }
    public void BGMAudioControl() {
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
