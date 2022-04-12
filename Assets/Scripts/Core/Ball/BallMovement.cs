using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallMovement : MonoBehaviour
{
    public float ballForce;
    public bool fristCollisionDone = false;
    public Rigidbody2D rb2D;
    public Vector2 touchStartPos;
    public Vector2 touchEndPos;
    public Vector2 touchDirection;
    
    // private void Update()
    // {
    //     if (Input.touchCount > 0)
    //     {
    //         Touch touch = Input.GetTouch(0);
    //         if (touch.phase == TouchPhase.Began)
    //         {
    //             Debug.Log(touch.position);
    //             rb2D.constraints = RigidbodyConstraints2D.None;
    //             touchStartPos = touch.position;
    //         }
    //         else if (touch.phase == TouchPhase.Ended)
    //         {
    //             Debug.Log(touch.position);
    //             touchEndPos = touch.position;
    //             touchDirection = touchStartPos - touchEndPos;
    //             rb2D.AddForce(touchDirection * ballForce, ForceMode2D.Force);
    //         }
    //     }
    // }
    private void OnMouseDown()
    {
        Debug.Log("Mouse down!");
        rb2D.constraints = RigidbodyConstraints2D.None;
        touchStartPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up!");
        touchEndPos = Input.mousePosition;
        touchDirection = touchStartPos - touchEndPos;
        rb2D.AddForce(touchDirection * ballForce, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("LowerWall"))
        {
            rb2D.velocity = Vector2.zero;
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
