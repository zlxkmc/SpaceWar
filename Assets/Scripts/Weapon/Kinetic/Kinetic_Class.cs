using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//动能武器类

public class Kinetic_Class : MonoBehaviour {

    public void SetKinetic(int power, int shootSpeed, int moveSpeed, ParticleSystem shell, GameObject shellPos)
    {
        Power = power;
        ShootSpeed = shootSpeed;
        MoveSpeed = moveSpeed;
        Shell = shell;
        ShellPos = shellPos;
    }

    public int Power { get; set; }//威力
    public int ShootSpeed { get; set; }//射速 个/s
    public int MoveSpeed { get; set; }//子弹飞行速度 m/s
    public ParticleSystem Shell { get; set; }//子弹
    public GameObject ShellPos { get; set; }//子弹生成位置的空物体

    private float shootTime=0;//射击计时器
    public GameObject target;


    //必备方法Update
    public void MustMethodUp()
    {
        Rotate();
        Shoot();
    }

    //指向射击点
    public void Rotate()
    {
        RaycastHit hit;
        Camera mainCamera = FollowBoat._instance.mainCamera;

        //目标点
        Vector3 direction = mainCamera.ScreenPointToRay(Input.mousePosition).direction.normalized;
        Vector3 cameraVector3 = new Vector3(direction.x * 100, direction.y * 100, direction.z * 100);//从相机到目标点的向量
        Vector3 targetPos = cameraVector3 + mainCamera.transform.position;//目标点的位置

        bool isTarget = Physics.Raycast(mainCamera.transform.position,
            direction, out hit,2000,~(1<<LayerMask.NameToLayer("Teammate")));//忽视自己 看鼠标瞄准的方向是否有物体

        if (isTarget)//瞄准物体
        {
            targetPos = hit.point;
        }

        //瞄准点
        transform.LookAt(targetPos);
    }

    //射击
    public void Shoot()
    {

        if (shootTime < 1.0 / ShootSpeed)
        {
            shootTime += Time.deltaTime;
        }
        else if (Input.GetMouseButton(0))
        {
            //防止碰撞到自己
            bool isSelf = Physics.Raycast(ShellPos.transform.position, ShellPos.transform.forward, 2000, 1 << LayerMask.NameToLayer("Teammate"));
            if (isSelf == false) 
            {
                transform.GetComponent<AudioSource>().Play();//射击音效
                shootTime = 0;
                ParticleSystem shellps=Instantiate(Shell, ShellPos.transform.position, transform.rotation);
                SmallShell shellSetting = shellps.GetComponent<SmallShell>();
                shellSetting.SetShell(Power, MoveSpeed);//传递子弹信息
            }
            
        }
    }

    //AI的方法
    public void AI_Rotation()
    {
        if (target != null)
        {
            //对准目标
            transform.LookAt(target.transform.position+target.transform.forward.normalized*1f);
        }
        
    }
    //攻击
    public void AI_Shoot()
    {
        if(target!=null)
        {
            if (shootTime < 1.0 / ShootSpeed)
            {
                shootTime += Time.deltaTime;
            }
            else
            {
                bool isSelf = false;
                //防止碰撞到自己
                if (transform.parent.tag == "Teammate")
                {
                    isSelf = Physics.Raycast(ShellPos.transform.position, ShellPos.transform.forward, 2000, 1 << LayerMask.NameToLayer("Teammate"));
                }
                else
                {
                    isSelf = Physics.Raycast(ShellPos.transform.position, ShellPos.transform.forward, 2000, 1 << LayerMask.NameToLayer("Enemy"));
                }
                if (isSelf == false)
                {
                    //transform.GetComponent<AudioSource>().Play();//射击音效
                    shootTime = 0;
                    ParticleSystem shellps = Instantiate(Shell, ShellPos.transform.position, transform.rotation);
                    SmallShell shellSetting = shellps.GetComponent<SmallShell>();
                    shellSetting.SetShell(Power, MoveSpeed);//传递子弹信息
                }

            }
        }
        
    }
}
