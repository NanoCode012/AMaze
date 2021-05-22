// GENERATED AUTOMATICALLY FROM 'Assets/Input/Character.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Character : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Character()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Character"",
    ""maps"": [
        {
            ""name"": ""PlayerKeyboard"",
            ""id"": ""68f81195-0bc9-4f68-8a45-287fadc77f84"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""PassThrough"",
                    ""id"": ""11e04f5d-cd31-4986-8932-f29ef3587c5c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6136d5e0-c9d9-46c2-85d4-9c8b8b2ec400"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8dc5d13b-7bee-4e9b-9fa7-78de5c997009"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2197b765-70a0-47ab-848a-b8b8eca18c6f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d15bcb1d-7f60-44e2-8dab-56e9253056c0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b5177f43-24b6-4c8a-a0d0-f1d99593a414"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerJoystick"",
            ""id"": ""54d5c834-0757-41a7-b8f5-12825be8a433"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""911ef802-dba7-4794-9429-b8823efbe360"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""164780fd-49d7-489e-88db-fff887328db2"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7f614b1f-7d8c-4ee4-9ac2-6d57607ba1e1"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/hat/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""810f494a-6519-40e7-928f-6ace85345c48"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/hat/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""13796ad2-6b92-498b-97a2-dc59867507be"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/hat/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6767d061-c058-40af-993c-3728c63477fa"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/hat/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerKeyboard
        m_PlayerKeyboard = asset.FindActionMap("PlayerKeyboard", throwIfNotFound: true);
        m_PlayerKeyboard_Walk = m_PlayerKeyboard.FindAction("Walk", throwIfNotFound: true);
        // PlayerJoystick
        m_PlayerJoystick = asset.FindActionMap("PlayerJoystick", throwIfNotFound: true);
        m_PlayerJoystick_Walk = m_PlayerJoystick.FindAction("Walk", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerKeyboard
    private readonly InputActionMap m_PlayerKeyboard;
    private IPlayerKeyboardActions m_PlayerKeyboardActionsCallbackInterface;
    private readonly InputAction m_PlayerKeyboard_Walk;
    public struct PlayerKeyboardActions
    {
        private @Character m_Wrapper;
        public PlayerKeyboardActions(@Character wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_PlayerKeyboard_Walk;
        public InputActionMap Get() { return m_Wrapper.m_PlayerKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerKeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerKeyboardActions instance)
        {
            if (m_Wrapper.m_PlayerKeyboardActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnWalk;
            }
            m_Wrapper.m_PlayerKeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
            }
        }
    }
    public PlayerKeyboardActions @PlayerKeyboard => new PlayerKeyboardActions(this);

    // PlayerJoystick
    private readonly InputActionMap m_PlayerJoystick;
    private IPlayerJoystickActions m_PlayerJoystickActionsCallbackInterface;
    private readonly InputAction m_PlayerJoystick_Walk;
    public struct PlayerJoystickActions
    {
        private @Character m_Wrapper;
        public PlayerJoystickActions(@Character wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_PlayerJoystick_Walk;
        public InputActionMap Get() { return m_Wrapper.m_PlayerJoystick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerJoystickActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerJoystickActions instance)
        {
            if (m_Wrapper.m_PlayerJoystickActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_PlayerJoystickActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerJoystickActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerJoystickActionsCallbackInterface.OnWalk;
            }
            m_Wrapper.m_PlayerJoystickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
            }
        }
    }
    public PlayerJoystickActions @PlayerJoystick => new PlayerJoystickActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerKeyboardActions
    {
        void OnWalk(InputAction.CallbackContext context);
    }
    public interface IPlayerJoystickActions
    {
        void OnWalk(InputAction.CallbackContext context);
    }
}
