using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {

    public Text speedText;

    public GameObject watchWarPosGo;

    public GameObject vectory;
    public GameObject defeated;
    public GameObject die;
    public GameObject reGameButton;
    public GameObject watchWar;

    public Text smallE;
    public Text middleE;
    public Text bigE;
    public Text smallT;
    public Text middleT;
    public Text bigT;

    private int smallENum;
    private int middleENum;
    private int bigENum;
    private int smallTNum;
    private int middleTNum;
    private int bigTNum;

    private bool isGameOver = false;
    public bool isDie { get; set; }

    public void SetDie(bool isdie)
    {
        isDie = isdie;
    }


    public static PlayerUI _instance;
    
    //public void GetBoatNum(int smallENum, int middleENum, int bigENum, int smallTNum, int middleTNum, int bigTNum)
    //{
    //    this.smallENum = smallENum;
    //    this.middleENum = middleENum;
    //    this.bigENum = bigENum;
    //    this.smallTNum = smallTNum;
    //    this.middleTNum = middleTNum;
    //    this.bigTNum = bigTNum;
    //}

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        //smallENum = PlayerPrefs.GetInt("smallEnemyNum");
        //middleENum = PlayerPrefs.GetInt("middleEnemyNum");
        //bigENum = PlayerPrefs.GetInt("bigEnemyNum");

        //smallTNum = PlayerPrefs.GetInt("smallTeammateNum");
        //middleTNum = PlayerPrefs.GetInt("middleTeammateNum");
        //bigTNum = PlayerPrefs.GetInt("bigTeammateNum");

        //switch (PlayerPrefs.GetInt("boatId"))
        //{
        //    case 0:smallTNum++;break;
        //    case 1:middleTNum++;break;
        //    case 2:bigTNum++;break;
        //}
        watchWar.SetActive(false);
        reGameButton.SetActive(false);
        defeated.SetActive(false);
        die.SetActive(false);
        vectory.SetActive(false);
        StartCoroutine(GetBoatNum());
    }

    private void Update()
    {
        smallE.text = "小型船："+smallENum.ToString();
        middleE.text = "中型船："+middleENum.ToString();
        bigE.text = "大型船："+bigENum.ToString();

        smallT.text = "小型船："+smallTNum.ToString();//&& (WatchWar._instance.IsWatch == false) || isGameOver == false
        middleT.text = "中型船："+middleTNum.ToString();
        bigT.text = "大型船："+bigTNum.ToString();

        if (isDie)
        {
            watchWar.SetActive(true);
            isDie = false;
        }

        if (smallENum + middleENum + bigENum == 0 && isGameOver == false)//胜利
        {
            isGameOver = true;
            vectory.SetActive(true);
            reGameButton.SetActive(true);
        }
        else if(smallTNum+middleTNum+bigTNum==0 && isGameOver == false)//失败
        {
            isGameOver = true;
            defeated.SetActive(true);
            reGameButton.SetActive(true);
        }
        if (LoadPlayScene._instance.allBoats[0] != null)
        {
            watchWarPosGo.transform.position = LoadPlayScene._instance.allBoats[0].transform.Find("CameraPos").position;
        }
        
    }

    public IEnumerator GetBoatNum()
    {
        smallENum=0;
        middleENum=0;
        bigENum=0;
        smallTNum=0;
        middleTNum=0;
        bigTNum=0;
        foreach( var boat in LoadPlayScene._instance.allBoats)
        {
            if(boat!=null&&boat.transform.Find("Key"))
            {
                int boatType = -1;
                if (boat.GetComponent<SmallBoat>() != null) boatType = 0;
                else if (boat.GetComponent<MiddleBoat>() != null) boatType = 1;
                else if (boat.GetComponent<BigBoat>() != null) boatType = 2;

                if (boat.tag == "Enemy")//减少船数
                {
                    switch (boatType)
                    {
                        case 0: smallENum++; break;
                        case 1: middleENum++; break;
                        case 2: bigENum++; break;
                    }
                }
                else
                {
                    switch (boatType)
                    {
                        case 0: smallTNum++; break;
                        case 1: middleTNum++; break;
                        case 2: bigTNum++; break;
                    }
                }
            } 
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(GetBoatNum());
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
    //重新开始
    public void OnReGameButtonClick()
    {
        SceneManager.LoadSceneAsync(0);
        CursorManager._instance.SetCursorNormal();
    }
    //观战
    public void OnWatchWar()
    {
        watchWarPosGo.SetActive(true);
        WatchWar._instance.SetWatch(true);

        FollowBoat._instance.SetcameraPos(watchWarPosGo.transform);
        watchWar.SetActive(false);
        reGameButton.SetActive(false);
        defeated.SetActive(false);
        die.SetActive(false);
        vectory.SetActive(false);
    }
}
