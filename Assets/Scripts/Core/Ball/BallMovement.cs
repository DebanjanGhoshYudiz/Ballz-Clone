using System;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    private BallManager ballManager;
    public bool firstTime = true;

    private void Start()
    {
        ballManager = FindObjectOfType<BallManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collide outer");
        if (col.gameObject.CompareTag("LowerWall"))
        {

            ballManager.CollectBall(rb2D);
            rb2D.velocity = Vector2.zero;
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}

    
    
