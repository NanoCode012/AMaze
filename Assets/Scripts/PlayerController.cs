using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float rotSpeed = 15.0f;
    public float moveSpeed = 6.0f;

    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10f;
    public float minFall = -1.5f;

    [SerializeField] private Transform target;

    private ControllerColliderHit _contact;
    //private Animator //_animator;

    private CharacterController _charController;

    private float _vertSpeed;

    private bool held = false;
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _vertSpeed = minFall;

        //_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        /*
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0) {
            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;

            // transform.rotation = Quaternion.LookRotation(movement);
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }

        //_animator.SetFloat("Speed", movement.sqrMagnitude);

        if (_charController.isGrounded) {
            if (Input.GetButtonDown("Jump")) {
                _vertSpeed = jumpSpeed;
            } else {
                _vertSpeed = minFall;
                //_animator.SetBool("Jumping", false);
            }
        } else {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity) {
                _vertSpeed = terminalVelocity;
            }

            if (_contact != null) {
                //_animator.SetBool("Jumping", true);
            }
        }
        

        movement.y = _vertSpeed;

        movement *= Time.deltaTime;
        _charController.Move(movement);*/
    }

    IEnumerator RenderHeldAnimation(System.Single horInput, System.Single vertInput)
    {
        while (held)
        {
            // held animation 
            Move(horInput, vertInput);
            // yield return new WaitForFixedUpdate(); /* Will block until next fixed frame right after FixedUpdate() function */
            yield return null; /* Will block until next next frame right after Update() function */
        }
    }

    IEnumerator RenderIdleAnimation()
    {
        while (!held)
        {
            // idle animation 
            // yield return new WaitForFixedUpdate(); /* Will block until next fixed frame right after FixedUpdate() function */
            yield return null; /* Will block until next next frame right after Update() function */
        }
    }

    void OnWalk(InputValue value)
    {
        var dir = value.Get<Vector2>();

        var horInput = dir[0];
        var vertInput = dir[1];

        if (horInput != 0 || vertInput != 0) {
            held = true;
            StartCoroutine(RenderHeldAnimation(horInput, vertInput));
        } else {
            held = false;
            // StartCoroutine(RenderIdleAnimation());
        }

        // print(dir);
    }

    void Move(System.Single horInput, System.Single vertInput) {
        Vector3 movement = Vector3.zero;
        movement.x = horInput * moveSpeed;
        movement.z = vertInput * moveSpeed;
        movement = Vector3.ClampMagnitude(movement, moveSpeed);

        Quaternion tmp = target.rotation;
        target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
        movement = target.TransformDirection(movement);
        target.rotation = tmp;

        Quaternion direction = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        
        movement.y = _vertSpeed;

        movement *= Time.deltaTime;
        _charController.Move(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit){
        _contact = hit;
    }
}
