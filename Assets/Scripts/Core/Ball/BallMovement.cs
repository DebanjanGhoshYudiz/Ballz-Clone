using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public bool firstCollisionDone = true;
    public Rigidbody2D rb2D;

    

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
                rb2D.velocity = Vector2.zero;
                rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
                FindObjectOfType<BallManager>().CollectBall(rb2D);
            }
        }
    }
    
    // Ball Manager! - Throw and Collect, Update list!
    // Ball movement!
}
