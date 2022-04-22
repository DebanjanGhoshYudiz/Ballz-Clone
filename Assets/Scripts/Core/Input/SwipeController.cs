using System;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform mainBall;
    private Vector2 _touchStartPos;
    private Vector2 _touchEndPos;
    private Vector3 _touchDirection;
    public float lenghtOfLineRenderer;
    public Action<Vector2> Swipe;

    public bool isGamingRunning = false;


    private void Update()
    {
        if (!isGamingRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Tap Start
                _touchStartPos = Input.mousePosition;
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, mainBall.position);
            }
            else if (Input.GetMouseButton(0))
            {
                _touchEndPos = Input.mousePosition;
                _touchDirection = _touchStartPos - _touchEndPos;
                lineRenderer.SetPosition(1, mainBall.position + (_touchDirection * lenghtOfLineRenderer));
            }

            else if (Input.GetMouseButtonUp(0))
            {
                    // Tap End
                _touchEndPos = Input.mousePosition;
                _touchDirection = _touchStartPos - _touchEndPos;
                lineRenderer.enabled = false;
                Swipe?.Invoke(_touchDirection);
                isGamingRunning = true;
            }
        }
    }
    
}
