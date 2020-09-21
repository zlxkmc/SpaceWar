using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//动能武器 子弹类

public class Shell_Class : MonoBehaviour
{

    //由发射的武器得到
    public int Power { get; set; }//威力 
    public int MoveSpeed { get; set; }//速度

    private ParticleSystem shellEffect;



    public void SetShell(int power, int moveSpeed)
    {
        
        Power = power;
        MoveSpeed = moveSpeed;
        var main = shellEffect.main;
        main.startSpeed = MoveSpeed;
    }
    

    private void Awake()
    {
        shellEffect = transform.GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        
        

    }
    //撞击
    private void OnParticleCollision(GameObject other)
    {
        //播放撞击粒子效果
        ParticleSystem ps = transform.GetComponent<ParticleSystem>();
        ParticleSystem.Particle[] shells = new ParticleSystem.Particle[ps.particleCount+1];
        ps.GetParticles(shells);
        Instantiate(EffectManager._instance.smallShellCollision, shells[0].position, Quaternion.identity);//实例化粒子效果

        if (other.GetComponent<Body>() != null)//如果是是船体
        {
            //得到撞击目标的Body
            Body targrt = other.GetComponent<Body>();
            //目标掉血
            targrt.DropBlood(Power);
        }
    }
}
