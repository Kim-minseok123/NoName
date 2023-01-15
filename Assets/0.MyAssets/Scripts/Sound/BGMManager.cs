using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource audioSource;
    public BGMManager instance;
    // Start is called before the first frame update
    void AWake()
    {
        if (instance != null) {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayBGM() {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
    public void StopBGM() { 
        audioSource.Stop();
    }
}
