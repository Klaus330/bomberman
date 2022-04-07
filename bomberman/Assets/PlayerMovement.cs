using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementInput;
    public Animator animator;
    public PlayerControls input;
    public int isHorizontalHash;
    public int isVerticalHash;
    public int isSpeedHash;
    bool movementPressed;

    public void Awake()
    {
        input = new PlayerControls();
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        isHorizontalHash = Animator.StringToHash("Horizontal");
        isVerticalHash = Animator.StringToHash("Vertical");
        isSpeedHash = Animator.StringToHash("Speed");
    }


    private void Update()
    {
        handleMovement();
        if (movementPressed)
        {
            transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime);
        }
    }

    public void handleMovement()
    {
        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Speed", movementInput.sqrMagnitude);
    }
    public void OnEnable()
    {
        input.Player.Enable();
    }

    public void OnDisable()
    {
        input.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
        movementPressed = movementInput.x != 0 || movementInput.y != 0;
    }
}

    