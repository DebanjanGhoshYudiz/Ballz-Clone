using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    
    [SerializeField] private GameObject mainBall;
    [SerializeField] private Rigidbody2D ballPrefab;
    [SerializeField] private SwipeController swipeControler;
    public int ballCounter;
    public float ballForce;
    public List<Rigidbody2D> balls;
    
    

    private void OnEnable()
    {
        // Subscribe Event which returns Vector 2 Direction
        swipeControler.Swipe += ThrowBall;
    }
    

    public void CreateBall( int mainBallSize)
    {
        // Create ball when Extra ball pickup is taken by the Player.
        for (int i = 0; i < mainBallSize; i++)
        {
            Rigidbody2D prefab = Instantiate(ballPrefab, transform);
            prefab.gameObject.SetActive(true);
            balls.Add(prefab);
        }
    }

    public void ThrowBall(Vector2 direction)
    {
        StartCoroutine(MainThrowBall(direction));
    }

    public IEnumerator MainThrowBall(Vector2 direciton)
    {
        ballCounter = 0; // Counter Reset
        for (int ball = 0; ball < balls.Count; ball++)
        {
            ballCounter++;
            balls[ball].gameObject.SetActive(true);
            balls[ball].constraints = RigidbodyConstraints2D.None;
            balls[ball].AddForce(direciton * ballForce, ForceMode2D.Force);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void CollectBall(Rigidbody2D anotherBall)
    {
        anotherBall.transform.position = mainBall.transform.position;
        anotherBall.gameObject.SetActive(false);
        ballCounter--;
        Debug.Log(ballCounter);
    }

    public void RemoveBall()
    {
        for (int ball = 0; ball < balls.Count; ball++)
        {
            if (balls[ball] != null)
            {
                Destroy(balls[ball].gameObject);
            }
        }
        balls.Clear();
    }

    private void OnDisable()
    {
        swipeControler.Swipe -= ThrowBall;
    }
}
