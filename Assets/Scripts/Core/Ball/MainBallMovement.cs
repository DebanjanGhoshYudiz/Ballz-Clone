using System;
using UnityEngine;

public class MainBallMovement : MonoBehaviour
{
    [SerializeField] private SwipeController swipeControler; 
    [SerializeField] private Spawner spawnerScirpt;
    public Rigidbody2D mainBallRd2D;
    public float ballForce;
    public Vector2 mainBallPosition;

    private void OnEnable()
    {
        swipeControler.Swipe += MainThrowBall;
    }

    private void Start()
    {
        mainBallPosition = transform.position;
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
            Debug.Log("Second time and So on Collision!");
            mainBallRd2D.velocity = Vector2.zero;
            mainBallRd2D.constraints = RigidbodyConstraints2D.FreezeAll;
            spawnerScirpt.NextMove();
        }
    }

    private void OnDisable()
    {
        swipeControler.Swipe -= MainThrowBall;
    }
}
