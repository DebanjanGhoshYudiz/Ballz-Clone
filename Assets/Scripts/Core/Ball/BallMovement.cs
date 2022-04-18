using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    private bool _firstCollisionDone = true;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("LowerWall"))
        {
            if (_firstCollisionDone)
            {
                Debug.Log("First time collision!");
                _firstCollisionDone = false;
            }
            else if (!_firstCollisionDone)
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
