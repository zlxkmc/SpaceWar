using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//管理音乐

public class AudioManager : MonoBehaviour {
    

    public AudioSource[] audios;

    public static AudioManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        
    }
    //点击音乐
    public void OnbuttonClickAudio()
    {
        audios[0].Play();
    }
}
