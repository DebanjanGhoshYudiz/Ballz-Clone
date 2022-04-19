using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collide outer");
        if (col.gameObject.CompareTag("LowerWall"))
        {
            Debug.Log("Collide Inside!");
            rb2D.velocity = Vector2.zero;
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            FindObjectOfType<BallManager>().CollectBall(rb2D);
        }
    }

}
