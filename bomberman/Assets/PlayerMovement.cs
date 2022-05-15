using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    // public Tilemap tilemapGameplay;
    // public Tile wallTile;
    private Vector2 movementInput;
    public float moveSpeed = 5f;
    public bool isSpeedAffected = false;
    public float speedAfectedCountDown = 5f;
    public Animator animator;
    public PlayerControls input;
    public int isHorizontalHash;
    public int isVerticalHash;
    public int isSpeedHash;
    bool movementPressed;

    public float isDyingCountDown = 0.3f;

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
            transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * moveSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (isSpeedAffected) {
            if (speedAfectedCountDown <= 0){
                isSpeedAffected = false;
                speedAfectedCountDown = 10f;
                moveSpeed = 5f;
            }

            speedAfectedCountDown -= Time.fixedDeltaTime;
        }

        if(isDyingCountDown <= 0){
            if(!FindObjectOfType<PowerUpRandomSpawner>().isPositionValidForPlayer(transform.position)){
                GetComponent<PlayerReactions>().die();
            }
            isDyingCountDown = 1f;
        }   

        isDyingCountDown -= Time.fixedDeltaTime;
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

    