using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVillage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlackPannel.instance.FadeOut());
        BGMManager.instance.PlayBGM("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
