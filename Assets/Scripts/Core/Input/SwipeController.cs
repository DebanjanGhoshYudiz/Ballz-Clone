using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform mainBall;
    private Vector2 _touchStartPos;
    private Vector2 _touchEndPos;
    private Vector3 _touchDirection;
    public float lenghtOfLineRenderer;
    public Action<Vector2> Swipe;
    public bool swipe = false;

    private void OnEnable()
    {
        GameEvents.ResetGame += OnSwipeEnable;
        GameEvents.onResume += OnSwipeEnable;
        GameEvents.onGameOver += OnSwipeDisable;
        GameEvents.onGameplayPause += OnSwipeDisable;
        GameEvents.onPlay += OnSwipeEnable;
    }

    private void Update()
    {
        if (swipe)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            
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
                Swipe?.Invoke(_touchDirection.normalized);
            }
        }
    }

    public void OnSwipeEnable()
    {
        StartCoroutine(OntrueSwipe());
    }

    IEnumerator OntrueSwipe()
    {
        yield return new WaitForSeconds(1f);
        swipe = true;
    }

    public void OnSwipeDisable()
    {
        swipe = false;
    }

    private void OnDisable()
    {
        GameEvents.ResetGame -= OnSwipeEnable;
        GameEvents.onResume -= OnSwipeEnable;
        GameEvents.onGameOver -= OnSwipeDisable;
        GameEvents.onGameplayPause -= OnSwipeDisable;
        GameEvents.onPlay -= OnSwipeEnable;
    }
}
