using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBallMovement : MonoBehaviour
{
    public SwipeController swipeControler;
    public Rigidbody2D mainBallRd2D;
    public float ballForce;
    public bool firstCollisionDone = true;
    public CubeObjectPool cubeObjectPool;

    private void OnEnable()
    {
        swipeControler.Swipe += MainThrowBall;
    }

    public void MainThrowBall(Vector2 direction)
    {
        mainBallRd2D.constraints = RigidbodyConstraints2D.None;
        mainBallRd2D.AddForce(direction * ballForce, ForceMode2D.Force);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("LowerWall"))
        {
            if (firstCollisionDone)
            {
                Debug.Log("First time collision!");
                firstCollisionDone = false;
            }
            else if (!firstCollisionDone)
            {
                Debug.Log("Second time and So on Collision!");
                mainBallRd2D.velocity = Vector2.zero;
                mainBallRd2D.constraints = RigidbodyConstraints2D.FreezeAll;
                cubeObjectPool.NextMove();
            }
        }
    }

    private void OnDisable()
    {
        swipeControler.Swipe -= MainThrowBall;
    }
}
