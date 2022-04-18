using System;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform mainBall;
    private Vector2 _touchStartPos;
    private Vector2 _touchEndPos;
    private Vector3 _touchDirection;
    public int lenghtOfLineRenderer;
    public Action<Vector2> Swipe;
    
    
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Tap Start
            Debug.Log(Input.mousePosition);
            _touchStartPos = Input.mousePosition;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, mainBall.position);
        }
        else if (Input.GetMouseButton(0))
        {
            // Moved
            Debug.Log(Input.mousePosition);
            _touchEndPos = Input.mousePosition;
            _touchDirection = _touchStartPos - _touchEndPos;
            lineRenderer.SetPosition(1, mainBall.position + (_touchDirection * lenghtOfLineRenderer));
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Tap End
            Debug.Log(Input.mousePosition);
            _touchEndPos = Input.mousePosition;
            _touchDirection = _touchStartPos - _touchEndPos;
            lineRenderer.enabled = false;
            Swipe?.Invoke(_touchDirection);
        }
        

    }
    
}
