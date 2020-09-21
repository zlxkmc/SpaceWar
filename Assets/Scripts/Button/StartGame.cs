using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//在option界面
//开始游戏

public class StartGame : MonoBehaviour {

    public GameObject startUI;
    public GameObject optionUI;
    public Toggle[] characterToggles;

    public Text smallEnemyText;
    public Text middleEnemyText;
    public Text bigEnemyText;
    public Text smallTeammateText;
    public Text middleTeammateText;
    public Text bigTeammateText;

    public int smallEnemyNum = 0;
    public int middleEnemyNum = 0;
    public int bigEnemyNum = 0;
    public int smallTeammateNum = 0;
    public int middleTeammateNum = 0;
    public int bigTeammateNum = 0;

    private void Start()
    {

    }

    //开始游戏
    public void OnStartGameButtonClick()
    {
        startUI.SetActive(false);
        optionUI.SetActive(false);

        
        //保存选择的是哪个船
        PlayerPrefs.SetInt("boatId", GetBoatId());
        //保存双方船的类型数量
        PlayerPrefs.SetInt("smallEnemyNum", smallEnemyNum);
        PlayerPrefs.SetInt("middleEnemyNum", middleEnemyNum);
        PlayerPrefs.SetInt("bigEnemyNum",bigEnemyNum);
        PlayerPrefs.SetInt("smallTeammateNum", smallTeammateNum);
        PlayerPrefs.SetInt("middleTeammateNum", middleTeammateNum);
        PlayerPrefs.SetInt("bigTeammateNum", bigTeammateNum);

        //加载play场景
        SceneManager.LoadSceneAsync(1);
    }
    //敌人
    public void OnSmallEnemyDown()
    {
        smallEnemyNum++;
        smallEnemyText.text = smallEnemyNum.ToString();
    }
    public void OnMiddleEnemyDown()
    {
        middleEnemyNum++;
        middleEnemyText.text = middleEnemyNum.ToString();
    }
    public void OnBigEnemyDown()
    {
        bigEnemyNum++;
        bigEnemyText.text = bigEnemyNum.ToString();
    }
    //队友
    public void OnSmallTeammateDown()
    {
        smallTeammateNum++;
        smallTeammateText.text = smallTeammateNum.ToString();
    }
    public void OnMiddleTeammateDown()
    {
        middleTeammateNum++;
        middleTeammateText.text = middleTeammateNum.ToString();
    }
    public void OnBigTeammateDown()
    {
        bigTeammateNum++;
        bigTeammateText.text = bigTeammateNum.ToString();
    }

    //减
    public void OnSmallEButton_jian()
    {
        if (smallEnemyNum > 0)
        {
            smallEnemyNum--;
            smallEnemyText.text = smallEnemyNum.ToString();
        }
        
    }
    public void OnMiddleEButton_jian()
    {
        if (middleEnemyNum > 0)
        {
            middleEnemyNum--;
            middleEnemyText.text = middleEnemyNum.ToString();
        }
        
    }
    public void OnBigEButton_jian()
    {
        if (bigEnemyNum > 0)
        {
            bigEnemyNum--;
            bigEnemyText.text = bigEnemyNum.ToString();
        }
        
    }
    public void OnSmallTButton_jian()
    {
        if (smallTeammateNum > 0)
        {
            smallTeammateNum--;
            smallTeammateText.text = smallTeammateNum.ToString();
        }
        
    }
    public void OnMiddleTButton_jian()
    {
        if (middleTeammateNum>0)
        {
            middleTeammateNum--;
            middleTeammateText.text = middleTeammateNum.ToString();
        }
        
    }
    public void OnBigTButton_jian()
    {
        if (bigTeammateNum > 0)
        {
            bigTeammateNum--;
            bigTeammateText.text = bigTeammateNum.ToString();
        }
        
    }

    //得到选择的船的Id
    private int GetBoatId()
    {
        int boatId = 0;
        foreach (var toggle in characterToggles)
        {
            if (toggle.isOn == true)
            {
                break;
            }
            boatId++;
        }
        return boatId;
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }

}
