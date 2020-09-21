using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    public Texture2D cursorNormal;
    public Texture2D cursorClick;
    public Texture2D cursorAttact;

    private CursorMode mode = CursorMode.Auto;
    private bool isStartGame = false;//是否开始操控飞船

    public static CursorManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (isStartGame == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetCursorClick();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                SetCursorNormal();
            }
        } 
    }

    public void SetCursorNormal()
    {
        Cursor.SetCursor(cursorNormal, Vector2.zero, mode);
    }
    public void SetCursorClick()
    {
        Cursor.SetCursor(cursorClick, Vector2.zero, mode);
    }
    public void SetCursorAttact()//进入play场景后切换
    {
        Cursor.SetCursor(cursorAttact, new Vector2(32, 32), mode);
        isStartGame = true;
    }
}
