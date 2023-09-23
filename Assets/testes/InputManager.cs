using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Events
    private delegate void StartTouch(Vector2 position, float time);
    private event StartTouch OnStartTouch;
    private delegate void EndTouch(Vector2 position, float time);
    private event EndTouch OnEndTouch;

    public delegate void Tapped();
    public event Tapped OnTapped;
    public delegate void MultiTapped();
    public event MultiTapped OnMultiTapped;

    public delegate void LeftSwipe();
    public event LeftSwipe OnSwipeLeft;
    public delegate void RightSwipe();
    public event RightSwipe OnSwipeRight;
    public delegate void UpSwipe();
    public event UpSwipe OnSwipeUp;
    public delegate void DownSwipe();
    public event DownSwipe OnSwipeDown;
    #endregion

    [SerializeField] private float minimumDistance = 15f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField, Range(0f, 1f)] private float directionThreshold = 0.9f;

    private Vector2 startPosition, endPosition;
    private float startTime, endTime;

    private PlayerControls playerControls;

    private void Awake() => playerControls = new PlayerControls();

    private void OnEnable()
    {
        playerControls.Enable();
        OnStartTouch += SwipeStart;
        OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        OnStartTouch -= SwipeStart;
        OnEndTouch -= SwipeEnd;
    }

    private void Start()
    {
        playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        
        
    }

    private void TappedPerformed(InputAction.CallbackContext ctx) { if (OnTapped != null) OnTapped(); }
    private void MultiTappedPerformed(InputAction.CallbackContext ctx) { if (OnMultiTapped != null) OnMultiTapped(); }
    private void StartTouchPrimary(InputAction.CallbackContext ctx) { if (OnStartTouch != null) OnStartTouch(ScreenPosition(), (float)ctx.startTime); }
    private void EndTouchPrimary(InputAction.CallbackContext ctx) { if (OnEndTouch != null) OnEndTouch(ScreenPosition(), (float)ctx.time); }
    private Vector2 ScreenPosition() { return playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(); }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance && (endTime - startTime) < maximumTime)
        {
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            if (OnSwipeUp != null) OnSwipeUp();
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            if (OnSwipeDown != null) OnSwipeDown();
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            if (OnSwipeLeft != null) OnSwipeLeft();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            if (OnSwipeRight != null) OnSwipeRight();
        }
    }
}
