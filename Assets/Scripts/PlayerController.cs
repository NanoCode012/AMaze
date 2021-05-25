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

    private float hp = 1.0f;
    private float stamina = 1.0f;

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
    private Item.ItemType interactingObjectType = Item.ItemType.None;
    private bool interactPressed;


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

        character.Player.Interact.performed += ctx =>
        {
            interactPressed = true;
        };

        character.Player.Run.performed += ctx =>
        {
            isRunning = ctx.ReadValueAsButton();
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

        handleBars();
    }

    private void handleMovement()
    {
        // speed = animator.GetFloat(speedHash);

        if (movementPressed)
        {
            var maxSpeed = Mathf.Max(Mathf.Abs(currentMovement.x), Mathf.Abs(currentMovement.y));
            var newSpeed = moveSpeed * maxSpeed;
            if (isRunning) newSpeed += 2.0f;

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

    private void handleInteraction()
    {
        if (interactPressed)
        {
            print("interact pressed");

            if (interactingObjectType != Item.ItemType.None)
            {
                Destroy(interactingObject);
                inventory.AddItem(new Item("Key", Item.ItemType.Key));
                UpdateInventory();
                print("picked up key");
                ShowInteractMessage(false);
            }

            interactPressed = false;
        }
    }

    private void handleBars()
    {
        hpBar.value = hp;
        staminaBar.value = stamina;
    }

    private void OnEnable()
    {
        character.Player.Enable();
    }

    private void OnDisable()
    {
        character.Player.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            print("Got item");
            interactingObject = other.gameObject;
            ShowInteractMessage();

            if (other.GetComponent<Key>())
            {
                interactingObjectType = Item.ItemType.Key;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            print("Leaving item");
            ShowInteractMessage(false);
            interactingObject = null;
            interactingObjectType = Item.ItemType.None;
        }

    }

    private void UpdateInventory()
    {
        var temp = inventory.GetInventory();
        string text = "";

        foreach (var item in temp)
        {
            text += "- " + item + "\n";
        }

        var inventoryObject = playerCanvas.transform.Find("Inventory");
        inventoryObject.GetComponent<Text>().text = text;

        print("item " + text);
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
