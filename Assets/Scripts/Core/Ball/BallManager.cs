using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    
    [SerializeField] private GameObject mainBall;
    [SerializeField] private Rigidbody2D ballPrefab;
    [SerializeField] private SwipeController swipeControler;
    private int ballCounter;
    public List<Rigidbody2D> balls;
    public float ballForce;
    

    private void OnEnable()
    {
        // Subscribe Event which returns Vector 2 Direction
        swipeControler.Swipe += ThrowBall;
    }
    

    public void CreateBall( int mainBallSize)
    {
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
        foreach (Rigidbody2D ball in balls)
        {
            ballCounter++;
            ball.gameObject.SetActive(true);
            ball.constraints = RigidbodyConstraints2D.None;
            ball.AddForce(direciton * ballForce, ForceMode2D.Force);
            yield return new WaitForSeconds(0.6f);
        }
    }

    public void CollectBall(Rigidbody2D anotherBall)
    {
        anotherBall.transform.position = mainBall.transform.position;
        anotherBall.gameObject.SetActive(false);
        ballCounter--;
        Debug.Log(ballCounter);
    }

    private void OnDisable()
    {
        swipeControler.Swipe -= ThrowBall;
    }
}
