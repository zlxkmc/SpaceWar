using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//控制按钮字体透明度变化
//text 要控制的字体
//audioManager 移上按时播放的音乐

public class ButtonTextEffect : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{

    public Text text;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager._instance;
    }
    //鼠标移上
    public void OnPointerEnter(PointerEventData eventData)
    {
        Color color = text.color;
        color = new Color(color.r, color.g, color.b, 1);
        text.color = color;
        audioManager.audios[1].Play();
    }
    //鼠标移出
    public void OnPointerExit(PointerEventData eventData)
    {
        Color color = text.color;
        color = new Color(color.r, color.g, color.b, 0.8f);
        text.color = color;
    }
    
}
