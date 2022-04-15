using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public Vector2 touchStartPos;
    public Vector2 touchEndPos;
    public Vector2 touchDirection;
    public Action<Vector2> Swipe;
    
    

    private void Update()
    {
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
        //     if (touch.phase == TouchPhase.Began)
        //     {
        //         Debug.Log(touch.position);
        //         touchStartPos = touch.position;
        //     }
        //     else if (touch.phase == TouchPhase.Ended)
        //     {
        //         Debug.Log(touch.position);
        //         touchEndPos = touch.position;
        //         touchDirection = touchStartPos - touchEndPos;
        //         Swipe?.Invoke(touchDirection);
        //     }
        // }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            touchStartPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(Input.mousePosition);
            touchEndPos = Input.mousePosition;
            touchDirection = touchStartPos - touchEndPos;
            Swipe?.Invoke(touchDirection);
        }
        

    }
    
}
