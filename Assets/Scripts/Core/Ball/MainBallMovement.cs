using UnityEngine;

public class MainBallMovement : MonoBehaviour
{
    [SerializeField] private SwipeController swipeControler;
    [SerializeField] private Rigidbody2D mainBallRd2D;
    [SerializeField] private CubeObjectPool cubeObjectPool;
    private bool _firstCollisionDone = true;
    public float ballForce;

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
            if (_firstCollisionDone)
            {
                Debug.Log("First time collision!");
                _firstCollisionDone = false;
            }
            else if (!_firstCollisionDone)
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
