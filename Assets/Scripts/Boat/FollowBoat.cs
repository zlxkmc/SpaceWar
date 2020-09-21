using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoat : MonoBehaviour {

    public Camera mainCamera;

    private Transform cameraPos;//船下

    public void SetcameraPos(Transform watchCameraPos)
    {
        cameraPos = watchCameraPos;
    }

    public static FollowBoat _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Follow(); 
    }

    //控制跟随
    private void Follow()
    {
        if (cameraPos != null)
        {
            //Transform cameraTra = mainCamera.transform;
            //围绕旋转
            //float xMousePos = Input.mousePosition.x / Screen.width;
            //float yMousePos = Input.mousePosition.y / Screen.height;
            //float rotationSpeed = BoatMove._instance.boat.RotationSpeed;
            //要变成的本地角度使有偏移角度
            //float xAngle = cameraPos.localEulerAngles.x - (yMousePos - 0.5f) * 2 * rotationSpeed * 0.12f;
            //float yAngle = cameraPos.localEulerAngles.y - (xMousePos - 0.5f) * 2 * rotationSpeed * 0.08f;
            //float zAngle = cameraPos.localEulerAngles.z;
            //保存空物体信息
            //Vector3 originAngle = cameraPos.eulerAngles;
            //Vector3 originPos = cameraPos.position;
            //改变角度
            //cameraPos.localEulerAngles = new Vector3(xAngle, yAngle, zAngle);
            //加速减速相机使远近
            //Vector3 direction = (boat.position - cameraPos.position).normalized;
            //cameraPos.Translate(direction* Input.GetAxis("Vertical"), Space.World);

            //传递给相机 插值运算
            transform.position = Vector3.Lerp(transform.position, cameraPos.position, Time.deltaTime*14f);
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraPos.rotation, Time.deltaTime*5f);

            //还原空物体的信息
            //cameraPos.eulerAngles = originAngle;
            //cameraPos.position = originPos;
        }       
    }

    //得到选择的船和信息
    public void GetPlayer(GameObject player)
    {
        cameraPos = player.transform.Find("CameraPos"); 
    }
}
