using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchWar : MonoBehaviour {

    public bool IsWatch { get; set; }

    public static WatchWar _instance;

    private void Awake()
    {
        _instance = this;
        IsWatch = false;
    }


    public void SetWatch(bool isWatch)
    {
        IsWatch = isWatch;
    }

    private void Update()
    {
        if (IsWatch)
        {
            float vSpeed = Input.GetAxis("Vertical") * 60 * Time.deltaTime;
            float hSpeed = Input.GetAxis("Horizontal") * 60 * Time.deltaTime;

            ChangeView();

            transform.Translate(transform.forward * vSpeed, Space.World);
            transform.Translate(transform.right * hSpeed, Space.World);
        }
        
    }

    //随鼠标转动
    private void ChangeView()
    {
        float xPos = Input.mousePosition.x / Screen.width;
        float yPos = Input.mousePosition.y / Screen.height;

        transform.Rotate(transform.up, (xPos - 0.5f) * 2 * 110 * Time.deltaTime, Space.World);
        transform.Rotate(transform.right, -(yPos - 0.5f) * 2 * 110 * Time.deltaTime, Space.World);
    }
}
