using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public GameObject cameraObj;
    private Transform cameraTarget;
    private CameraController cameraController;

    private float rotSpeed = 1.5f;
    private float moveSpeed = 0.75f;

    private Animator animator;
    private Character character;

    private Vector2 currentMovement;
    private bool movementPressed;
    private int speedHash;
    private float speed;


    private void Awake()
    {
        character = new Character();

        character.Player.Walk.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
        };

        character.Player.Walk.canceled += ctx =>
        {
            currentMovement = Vector2.zero;
        };

        // character.PlayerKeyboard.Walk.performed += ctx => {
        //     print(ctx.ReadValueAsObject());
        //     currentMovement = ctx.ReadValue<Vector2>();
        //     movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        // };
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

        speedHash = Animator.StringToHash("Speed_f");

        if (cameraObj == null)
        {
            throw new System.Exception("Camera cannot be empty");
        }
        else
        {
            cameraTarget = cameraObj.transform;
            cameraController = cameraObj.GetComponent<CameraController>();
        }
    }

    private void Update()
    {
        movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        handleMovement();
        handleRotation();
    }

    private void handleMovement()
    {
        // speed = animator.GetFloat(speedHash);

        if (movementPressed)
        {
            var maxSpeed = Mathf.Max(Mathf.Abs(currentMovement.x), Mathf.Abs(currentMovement.y));
            var newSpeed = moveSpeed * maxSpeed;
            animator.SetFloat(speedHash, newSpeed);

            // cameraController.AdjustDistance(newSpeed);
        }
        else
        {
            animator.SetFloat(speedHash, 0f);
        }
    }

    private void handleRotation()
    {
        if (movementPressed)
        {
            //Not allow backward movement
            if (currentMovement.y < 0) return;

            Vector3 dir = new Vector3(currentMovement.x * rotSpeed, 0, currentMovement.y);

            // this is the direction in the world space we want to move
            var desiredMoveDirection = cameraTarget.TransformDirection(dir);
            desiredMoveDirection.y = 0; //don't move in y dir

            // lerp rotation into at direction
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(desiredMoveDirection),
                Time.deltaTime * rotSpeed
            );


        }
    }

    private void OnEnable()
    {
        character.Player.Enable();
    }

    private void OnDisable()
    {
        character.Player.Disable();
    }
}
