using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public GameObject playerCanvas;

    public GameObject cameraObj;
    private Transform cameraTarget;
    private CameraController cameraController;

    private float rotSpeed = 1.5f;
    private float moveSpeed = 0.75f;

    private Animator animator;
    private Character character;

    public float Hp
    {
        get { return _hp; }
        set
        {
            _hp = Mathf.Clamp(value, minStats, maxStats);
        }
    }

    public float Stamina
    {
        get { return _stamina; }
        set
        {
            _stamina = Mathf.Clamp(value, minStats, maxStats);
        }
    }

    private float _hp = 1.0f;
    private float _stamina = 0.8f;
    [SerializeField] private float runCost = 0.01f;
    [SerializeField] private float staminaRegen = 0.01f;

    private float minStats = 0f;
    private float maxStats = 1.0f;

    private Text interactTextBox;
    private Text inventoryTextBox;
    private Slider hpBar;
    private Slider staminaBar;

    private Vector2 currentMovement;
    private bool movementPressed;
    private int speedHash;
    private float speed;
    private bool isRunning;

    private Inventory inventory;
    private GameObject interactingObject;
    private bool interactPressed;

    private bool usePressed;

    private ItemController itemController;
    private TrapController trapController;

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

        character.Player.Run.performed += ctx =>
        {
            isRunning = ctx.ReadValueAsButton();
        };

        character.Player.Interact.performed += ctx =>
        {
            interactPressed = true;
        };

        character.Player.Use.performed += ctx =>
        {
            usePressed = true;
        };

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

        inventory = new Inventory();
        itemController = FindObjectOfType<ItemController>();
        trapController = FindObjectOfType<TrapController>();

        interactTextBox = FindCanvasChildren("Interact message").GetComponent<Text>();
        inventoryTextBox = FindCanvasChildren("Inventory").GetComponent<Text>();
        hpBar = FindCanvasChildren("HP bar").GetComponent<Slider>();
        staminaBar = FindCanvasChildren("Stamina bar").GetComponent<Slider>();
    }

    private void Update()
    {
        movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        handleMovement();
        handleRotation();

        handleInteraction();
        handleUse();

        handleBars();
    }

    private void handleMovement()
    {
        if (movementPressed)
        {
            // Get maxspeed across both axis
            var maxSpeed = Mathf.Max(Mathf.Abs(currentMovement.x), Mathf.Abs(currentMovement.y));

            // Scale movespeed by maxspeed
            // Meaning: for analog devices, moving the stick further from the center gives higher speed
            var newSpeed = moveSpeed * maxSpeed;
            if (isRunning)
            {
                newSpeed += 2.0f;
                Stamina -= runCost * Time.deltaTime;
            }

            animator.SetFloat(speedHash, newSpeed);
        }
        else
        {
            animator.SetFloat(speedHash, minStats);
        }

        // Regen stamina if not running but a bit slower
        if (!isRunning) Stamina = Mathf.Lerp(Stamina, maxStats, staminaRegen * Time.deltaTime);
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

    private void handleInteraction()
    {
        if (interactPressed && interactingObject)
        {
            itemController.InteractItem(this, interactingObject);
            UpdateInventory();

            interactPressed = false;
            ShowInteractMessage(false);
        }
    }

    public void AddInventoryItem(Item item) => inventory.AddItem(item);

    private void handleUse()
    {
        if (usePressed && inventory.Size() > 0)
        {
            var item = inventory.Pop();
            itemController.UseItem(this, item);

            UpdateInventory();
            usePressed = false;
        }
    }

    private void handleBars()
    {
        hpBar.value = Hp;
        staminaBar.value = Stamina;
    }

    private void OnEnable()
    {
        character.Player.Enable();
    }

    private void OnDisable()
    {
        character.Player.Disable();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Trap" || hit.transform.root.tag == "Trap")
        {
            trapController.HandleHit(this, hit.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            interactingObject = other.gameObject;
            ShowInteractMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            print("Leaving item");
            ShowInteractMessage(false);
            interactingObject = null;
        }
    }

    private void UpdateInventory()
    {
        if (inventory.Size() > 0)
        {
            var temp = inventory.GetInventory();
            string text = "Press R to use\n";

            foreach (var item in temp)
            {
                text += "- " + item + "\n";
            }

            inventoryTextBox.text = text;
        }
        else
        {
            inventoryTextBox.text = "";
        }
    }

    private void ShowInteractMessage(bool show = true)
    {
        interactTextBox.enabled = show;
    }

    private GameObject FindCanvasChildren(string name)
    {
        return playerCanvas.transform.Find(name).gameObject;
    }
}
