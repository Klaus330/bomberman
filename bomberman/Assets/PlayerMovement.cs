using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementInput;

    private void Update()
    {
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime);
    }
    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();


    //public float moveSpeed = 5f;

    //public Rigidbody2D rb;
    //public Animator animator;

    //Vector2 movement;

    //void Update()
    //{
    //    movement.x = Input.GetAxisRaw("Horizontal");
    //    movement.y = Input.GetAxisRaw("Vertical");

    //    animator.SetFloat("Horizontal", movement.x);
    //    animator.SetFloat("Vertical", movement.y);
    //    animator.SetFloat("Speed", movement.sqrMagnitude);
    //}

    //void FixedUpdate()
    //{
    //    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    //}
    //[SerializeField]
    //private float playerSpeed = 2.0f;
    ////[SerializeField]
    ////private float jumpHeight = 1.0f;
    //[SerializeField]
    //private float gravityValue = 0;

    //private CharacterController controller;
    //private Vector3 playerVelocity;
    ////private bool groundedPlayer;
    //private Vector2 movementInput = Vector2.zero;

    //private void Start()
    //{
    //    controller = gameObject.GetComponent<CharacterController>();
    //}

    //public void OnMove(InputAction.CallbackContext context) {
    //    movementInput = context.ReadValue<Vector2>();
    //}

    //void Update()
    //{
    //    //groundedPlayer = controller.isGrounded;
    //    //if (groundedPlayer && playerVelocity.y < 0)
    //    //{
    //    //    playerVelocity.y = 0f;
    //    //}

    //    Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
    //    controller.Move(move * Time.deltaTime * playerSpeed);

    //    if (move != Vector3.zero)
    //    {
    //        gameObject.transform.forward = move;
    //    }

    //    // Changes the height position of the player..
    //    //if (groundedPlayer)
    //    //{
    //    //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //    //}

    //    playerVelocity.y += gravityValue * Time.deltaTime;
    //    controller.Move(playerVelocity * Time.deltaTime);
    //}
}
