using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//在start界面
//进入option界面

public class NewGame : MonoBehaviour
{

    public GameObject startUI;
    public GameObject optionUI;


    private void Start()
    {

    }

    //点击按钮
    public void OnNewGameButtonClick()
    {
        startUI.SetActive(false);
        optionUI.SetActive(true);
    }
    public void OnQuitGame()
    {
        Application.Quit();
    }


}
