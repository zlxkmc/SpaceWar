using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//船的一个组件有Cube,Key,Weapon

public class Body : MonoBehaviour {

    public int Hp;

    public int boatType;


    private void SetBody(int hp)
    {
        Hp = hp;
    }

    private void Start()
    {
        switch (gameObject.tag)
        {
            case "Cube":SetBody(100);break;
            case "Key":SetBody(300);break;
            case "Weapon":SetBody(50);break;
        }
    }
    //掉血
    public void DropBlood(int power)
    {
        Hp -= power;

        //血小于等与0后销毁方法
        if (Hp <= 0 && Hp + power >= 0)
        {
            DestroySelf();  
        }
    }
    //销毁
    public void DestroySelf()
    {
        //粒子效果 实例化一个
        ParticleSystem explosion = null;
        switch (gameObject.tag)
        {
            case "Cube": explosion = EffectManager._instance.explosionCube; break;
            case "Key": explosion = EffectManager._instance.explosionKey; break;
            case "Weapon": explosion = EffectManager._instance.explosionWeapon; break;
        }
        Instantiate(explosion, transform.position, Quaternion.identity, transform.parent);
        //销毁
        if (gameObject.tag == "Key")//如果是Key就销毁所有Body
        {
            Transform parent = transform.parent;
            GameObject obj = parent.gameObject;
            List<GameObject> allBoats = LoadPlayScene._instance.allBoats;

            if (obj.tag == "Player")
            {
                PlayerUI._instance.speedText.text = "速度：" + 0.ToString("#0.0");
                PlayerUI._instance.SetDie(true);
            }

            Destroy(obj, 8);
            for(int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (child.tag != "Key"&& (child.tag=="Cube"|| child.tag=="Weapon"))
                {
                    child.GetComponent<Body>().DestroySelf();
                }
                else if(child.tag=="Fire"||child.tag=="EnemyTarget")
                {
                    Object effect = child.gameObject;
                    Destroy(effect);
                }
            }
        }
        Destroy(gameObject);
    }
}
