using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public Transform cameraTarget;
    
    private float rotSpeed = 5.0f;
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

        character.Player.Walk.performed += ctx => {
            // print(ctx.ReadValueAsObject());
            currentMovement = ctx.ReadValue<Vector2>();
        };

        character.Player.Walk.canceled += ctx => {
            currentMovement = Vector2.zero;
        };

        // character.PlayerKeyboard.Walk.performed += ctx => {
        //     print(ctx.ReadValueAsObject());
        //     currentMovement = ctx.ReadValue<Vector2>();
        //     movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        // };
    }

    private void Start() {
        animator = GetComponent<Animator>();

        speedHash = Animator.StringToHash("Speed_f");

        if (cameraTarget == null) {
            throw new System.Exception("Camera cannot be empty");
        }
    }

    private void Update() {
        movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        handleMovement();
        handleRotation();
    }

    private void handleMovement() {
        // speed = animator.GetFloat(speedHash);

        if (movementPressed) {
            var maxSpeed = Mathf.Max(Mathf.Abs(currentMovement.x), Mathf.Abs(currentMovement.y));
            var newSpeed = moveSpeed*maxSpeed;
            print(newSpeed);
            animator.SetFloat(speedHash, newSpeed);
        } else {
            animator.SetFloat(speedHash, 0f);
        }
    }

    private void handleRotation() {
        // Vector3 currentPosition = transform.position;

        
        // Vector3 positionToLookAt = cameraTarget.transform.position + newPosition;

        // Quaternion tmp = cameraTarget.rotation;
        // tmp.eulerAngles = new Vector3(0, cameraTarget.eulerAngles.y, 0);
        
        if (movementPressed) {
            Vector3 dir = new Vector3(currentMovement.x, 0, currentMovement.y);

            // this is the direction in the world space we want to move
            var desiredMoveDirection = cameraTarget.TransformDirection(dir);

            // lerp rotation into at direction
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(desiredMoveDirection),
                Time.deltaTime * rotSpeed
            );
        }
    }

    private void OnEnable() {
        character.Player.Enable();
    }

    private void OnDisable() {
        character.Player.Disable();
    }
}
