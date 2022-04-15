using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallMovement : MonoBehaviour
{
    public bool fristCollisionDone = true;
    public Rigidbody2D rb2D;


    // private void OnMouseDown()
    // {
    //     Debug.Log("Mouse down!");
    //     rb2D.constraints = RigidbodyConstraints2D.None;
    //     touchStartPos = Input.mousePosition;
    // }
    //
    // private void OnMouseUp()
    // {
    //     Debug.Log("Mouse Up!");
    //     touchEndPos = Input.mousePosition;
    //     touchDirection = touchStartPos - touchEndPos;
    //     rb2D.AddForce(touchDirection * ballForce, ForceMode2D.Force);
    // }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("LowerWall"))
        {
            if (fristCollisionDone)
            {
                Debug.Log("First time collision!");
                fristCollisionDone = false;
            }
            else if (!fristCollisionDone)
            {
                Debug.Log("Second time and So on Collision!");
                rb2D.velocity = Vector2.zero;
                rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
                FindObjectOfType<BallManager>().CollectBall(this.rb2D);
            }
        }
    }
    
    // Ball Manager! - Throw and Collect, Update list!
    // Ball movement!
}
