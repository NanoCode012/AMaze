using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Character character;

    private bool held = false;

    private Vector2 currentMovement;

    private void Awake() 
    {
        character = new Character();

        character.PlayerKeyboard.Walk.performed += ctx => {
            print(ctx.ReadValueAsObject());
            currentMovement = ctx.ReadValue<Vector2>();
        };
    }

    private void OnEnable() {
        character.PlayerKeyboard.Enable();
    }

    private void OnDisable() {
        character.PlayerKeyboard.Disable();
    }
}
