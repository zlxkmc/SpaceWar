using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//加载场景后一些设置

public class LoadPlayScene : MonoBehaviour {

    public GameObject boat;

    public Transform enemy;
    public Transform teammate;

    public List<GameObject> allBoats = new List<GameObject>();

    private int Count = 0;//总的船的数量



    public static LoadPlayScene _instance;

    private void Awake()
    {
        _instance = this;
        ShowBoat();
        CreatAllBoats();
        //变为攻击指针
        CursorManager._instance.SetCursorAttact();
        
    }

    private void Start()
    {

    }

    //实例选择的船
    private void ShowBoat()
    {
        boat = BoatManager._instance.playerBoats[PlayerPrefs.GetInt("boatId")];
        GameObject player= Instantiate(boat, teammate.position, Quaternion.identity);
        allBoats.Add(player);
        Count++;
        FollowBoat._instance.GetPlayer(player);
    }
    //生成所有船
    private void CreatAllBoats()
    {
        GameObject[] enemyBoats = BoatManager._instance.enemyBoats;
        GameObject[] teammateBoats = BoatManager._instance.teammateBoats;

        //Vector3 enemyPos = enemy.position - Random.insideUnitSphere * 30;
        //Vector3 teammatePos = teammate.position - Random.insideUnitSphere * 30;

        //敌人
        for (int i = 0; i < PlayerPrefs.GetInt("smallEnemyNum"); i++)
        {
            allBoats.Add(Instantiate(enemyBoats[0], enemy.position - Random.insideUnitSphere * 150, Quaternion.identity));
            Count++;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("middleEnemyNum"); i++)
        {
            allBoats.Add(Instantiate(enemyBoats[1], enemy.position - Random.insideUnitSphere * 150, Quaternion.identity));
            Count++;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("bigEnemyNum"); i++)
        {
            allBoats.Add(Instantiate(enemyBoats[2], enemy.position - Random.insideUnitSphere * 150, Quaternion.identity));
            Count++;
        }
        //队友
        for (int i = 0; i < PlayerPrefs.GetInt("smallTeammateNum"); i++)
        {
            allBoats.Add(Instantiate(teammateBoats[0], teammate.position - Random.insideUnitSphere * 150, Quaternion.identity));
            Count++;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("middleTeammateNum"); i++)
        {
            allBoats.Add(Instantiate(teammateBoats[1], teammate.position - Random.insideUnitSphere * 150, Quaternion.identity));
            Count++;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("bigTeammateNum"); i++)
        {
            allBoats.Add(Instantiate(teammateBoats[2], teammate.position - Random.insideUnitSphere * 150, Quaternion.identity));
            Count++;
        }

    }
}
