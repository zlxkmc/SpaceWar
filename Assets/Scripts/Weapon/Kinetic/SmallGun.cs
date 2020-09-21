using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//小型枪

public class SmallGun : Kinetic_Class {

    public static SmallGun _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GameObject shellPos = transform.Find("ShellPos").gameObject;//子弹生成位置的空物体
        ParticleSystem shell=null;
        if (transform.parent.tag == "Enemy")
        {
            shell = EffectManager._instance.smallShellEnemy;
        }
        if (transform.parent.tag == "Teammate" || transform.parent.tag == "Player")
        {
            shell = EffectManager._instance.smallShellTeammate;
        }
        SetKinetic(5, 2, 200, shell, shellPos);
    }

    private void Update()
    {
        if(transform.parent.tag=="Player")
        {
            MustMethodUp();
        }
        else
        {
            AI_Rotation();
            AI_Shoot();
        }
        
    }
}
