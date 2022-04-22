using System;
using UnityEngine;

public class MainBallMovement : MonoBehaviour
{
    [SerializeField] private SwipeController swipeController; 
    [SerializeField] private Spawner spawnerScirpt;
    public Rigidbody2D mainBallRd2D;
    public float ballForce;
    public Vector2 mainBallPosition;

    private void OnEnable()
    {
        swipeController.Swipe += MainThrowBall;
    }

    private void Start()
    {
        mainBallPosition = transform.position;
    }

    public void MainThrowBall(Vector2 direction)
    {
        Debug.Log(direction.normalized);
        mainBallRd2D.constraints = RigidbodyConstraints2D.None;
        mainBallRd2D.velocity = direction.normalized * ballForce;
        //mainBallRd2D.AddForce(direction * ballForce, ForceMode2D.Force);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("LowerWall"))
        {
            swipeController.isGamingRunning = false;
            mainBallRd2D.velocity = Vector2.zero;
            mainBallRd2D.constraints = RigidbodyConstraints2D.FreezeAll;
            spawnerScirpt.NextMove();
        } 
    }

    private void OnDisable()
    {
        swipeController.Swipe -= MainThrowBall;
    }
}
