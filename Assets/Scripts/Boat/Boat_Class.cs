using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//船类

public class Boat_Class: MonoBehaviour
{
    public float MaxMoveSpeed { get; set; }//最大移速 m/s
    public float AddSpeed { get; set; }//加速度 m/s^2
    public float RotationSpeed { get; set; }//角速度 °/s

    private GameObject target;//AI 400m内离自己最近的船
    private SmallGun[] smallGun;
    public Vector3 targetPos;//目标点周围的点
    Vector3 targetDirection;//战斗点周围；

    public float time = 5;

    //public bool isEnemy = false;

    private float moveSpeed = 0;//移速 m/s

    public void GetSmallGun(SmallGun[] smallGun)
    {
        this.smallGun = smallGun;
    }

    public void SetBoat(float maxMoveSpeed, float addSpeed, float rotationSpeed)
    {
        MaxMoveSpeed = maxMoveSpeed;
        AddSpeed = addSpeed;
        RotationSpeed = rotationSpeed;
    }

    //必备方法Update
    public void MustMethodUp()
    {
        if (transform.Find("Key") != null)
        {
            ChangeView();
            Move();
            Rotate();
        }

    }

    //移动方法
    public void Move()
    {
        //向前移动
        if (Mathf.Abs(moveSpeed) <= MaxMoveSpeed || Input.GetAxis("Vertical") * moveSpeed < 0)
        {
            moveSpeed += Input.GetAxis("Vertical") * AddSpeed * Time.deltaTime;
        }
        PlayerUI._instance.speedText.text = "速度：" + moveSpeed.ToString("#0.0");
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        //AudioSource MoveAudio= AudioManager._instance.audios[3];
        //MoveAudio.volume = Mathf.Abs(moveSpeed) / MaxMoveSpeed;
        //MoveAudio.Play();
    }

    //旋转
    private void Rotate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h != 0)
        transform.RotateAround(transform.position, transform.forward, h * RotationSpeed * Time.deltaTime * 0.5f);
    }

    //船随鼠标转动
    private void ChangeView()
    {
        float xPos = Input.mousePosition.x / Screen.width;
        float yPos = Input.mousePosition.y / Screen.height;

        transform.Rotate(transform.up, (xPos - 0.5f) * 2 * RotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(transform.right, -(yPos - 0.5f) * 2 * RotationSpeed * Time.deltaTime, Space.World);
    }
    //AI
    //找到400m内离自己最近的船 每2秒调用一次
    public void AI_target()
    {
        time += Time.deltaTime;
        if (time >= 2)
        {
            time = 0;
            float minDistance = 400;
            List<GameObject> allBoats = LoadPlayScene._instance.allBoats;
            //得到要攻击的船
            foreach (var boat in allBoats)
            {
                if (boat!=null&&transform.tag == "Enemy" && (boat.tag == "Teammate" || boat.tag == "Player") && gameObject != boat)
                {
                    float distance = Vector3.Distance(transform.position, boat.transform.position);
                    if (distance < minDistance)
                    {
                        target = boat;
                        minDistance = distance;
                    }
                }
                else if (boat!=null&&transform.tag == "Teammate" && boat.tag == "Enemy" && gameObject != boat)
                {
                    float distance = Vector3.Distance(transform.position, boat.transform.position);
                    if (distance < minDistance)
                    {
                        target = boat;
                        minDistance = distance;
                    }
                }
            }
            foreach (var sGun in smallGun)//向武器传递目标位置
            {
                sGun.target = target;
            }

            if (target != null)
            {
                targetPos = target.transform.position - Random.insideUnitSphere * 5;//在目标周围随机生成一个目标位置 5m
            }
            
            targetDirection = (GameManager._instance.WarPos.transform.position - transform.position) - Random.insideUnitSphere * 150;
        }
      
    }
    //AI移动
    public void AI_move()
    {
        if (transform.Find("Key") == true)
        {
            if (target != null && Vector3.Distance(targetPos, transform.position) > 3f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(targetPos - transform.position), RotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.LookRotation(targetDirection), RotationSpeed * Time.deltaTime);
            }

            if (Mathf.Abs(moveSpeed) <= MaxMoveSpeed)
            {
                moveSpeed += AddSpeed * Time.deltaTime;
            }
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }
    } 
}

    

