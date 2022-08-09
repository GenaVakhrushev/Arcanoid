using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

enum Target
{
    Platform = 0,
    Ball = 1,
}

public class InputManager : MonoBehaviour
{
    private static PlayerInput playerInput;
    public static PlayerInput PlayerInput => playerInput;

    private Target? target = null;

    private Platform platform;
    private Ball ball => platform.CurrentBall;

    private Vector2 TouchPosition => Camera.main.ScreenToWorldPoint(playerInput.Touch.TouchPosition.ReadValue<Vector2>());

    private void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.Touch.TouchPress.started += _ => DetectTarget();
        playerInput.Touch.TouchPress.canceled += _ => EndControlTagret();
        playerInput.Touch.TouchPosition.performed += _ => ControlTarget(TouchPosition);  
        
    }

    private void Start()
    {
        platform = Platform.Instance;
    }

    private void FixedUpdate()
    {
        
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void DetectTarget()
    {
        if (IsOverUI())
        {
            return;
        }

        target = TouchPosition.y <= platform.transform.position.y ? Target.Platform : Target.Ball;
        ControlTarget(TouchPosition);
    }

    private void EndControlTagret()
    {
        if (ball && target == Target.Ball)
        {
            ball.Launch(TouchPosition);
        }

        target = null;
    }

    private void ControlTarget(Vector2 pos)
    {
        if (target == Target.Platform)
        {
            platform.SetDestination(new Vector3(pos.x, platform.transform.position.y));
        }
        else if(target == Target.Ball)
        {
            if (ball)
            {
                ball.DrawLine(pos);
            }
        }
    }

    private bool IsOverUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        List<RaycastResult> raycastResults = new List<RaycastResult>();

        pointerEventData.position = playerInput.Touch.TouchPosition.ReadValue<Vector2>();

        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        return raycastResults.Count > 0;
    }
}
