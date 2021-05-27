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
            ""name"": ""Player"",
            ""id"": ""68f81195-0bc9-4f68-8a45-287fadc77f84"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""11e04f5d-cd31-4986-8932-f29ef3587c5c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""245467ea-5895-4c79-a323-e34370e8af7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""2941b68d-f7a7-4f55-836a-4cedc52c5b4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""7823957d-0415-458b-9ded-0ba08d8fc87e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateItem"",
                    ""type"": ""Button"",
                    ""id"": ""81610206-077a-4ee2-8ab2-a9295d487a87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DropItem"",
                    ""type"": ""Button"",
                    ""id"": ""7d4e9293-2851-4c22-8ec3-abb2e6eb30b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
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
                },
                {
                    ""name"": """",
                    ""id"": ""842db708-71eb-4800-a958-67da1e0e57c2"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,ScaleVector2(x=0.6)"",
                    ""groups"": ""Controller"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fab1e929-ad58-4d0d-80f1-21acb1f4acd1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""453587e0-09fb-4375-8b3e-de5c6069a0e4"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c684014-fe99-47e4-aae6-d592fd54e350"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e8cd54e-9a0e-45f0-b4e0-84bddad3e79e"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ac3c9e0-c703-4f81-8c0d-5b4958e2e38a"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8abfccc9-362d-4beb-b519-c7d387b29a1c"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button5"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff6924bf-b631-4ab0-979e-ecb13b4ab99e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RotateItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d1849f2-8725-4e66-8310-60269f1b44f5"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""RotateItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5700d77-2477-42ab-8b61-b5664c86c282"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e96db381-829b-4919-b55c-8aa6f65aadb9"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player1"",
            ""id"": ""1decff64-4f41-4fd4-83fb-866a204645f0"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""859d90e6-956c-44e0-a5f6-dac61e6f65d7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""be1b0b67-30b6-40e7-b9a0-5a85fc3f9c94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7ad0c3c8-79a2-488c-bf1c-cedf489f219e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""204de353-5014-4951-b652-c8cf4fc65e86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateItem"",
                    ""type"": ""Button"",
                    ""id"": ""b31a55a3-4c01-494c-8b14-2efe0ac61c09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DropItem"",
                    ""type"": ""Button"",
                    ""id"": ""dd990eeb-def4-4df3-8b20-67c5f602754b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9e6e1cc9-f5a5-46a1-ae4c-73c1847f0071"",
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
                    ""id"": ""b8f8928c-3d54-4606-9348-d79bb1ce1fc1"",
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
                    ""id"": ""91d3e8c2-6852-4c79-aeda-6438bd4c828d"",
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
                    ""id"": ""db8105de-ceea-4102-8691-593b8c4d858a"",
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
                    ""id"": ""21c35178-ceec-44f1-b648-681a21c2ed40"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""99b11c8b-eb95-4bf5-bf00-631b6cb1ca86"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1469f338-29ca-4563-a533-f95f356754bb"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca8294d2-a4a0-455e-aa57-07630b5fe41a"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d38469c-de11-4770-8281-730642be5da2"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RotateItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cc52e5c-d47c-494a-86d4-b841a06c333f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""de38faa2-7144-4934-b896-a60ce70de7a2"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""14c4188a-38c5-4318-ac39-5635807e207c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""f384d4a3-6933-4067-bd8c-e7f8008b5404"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c16fc130-822b-4424-a2be-a0dfdb4e9314"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""5c6302f9-7c4c-47fd-93b5-203ee28ad2cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateItem"",
                    ""type"": ""Button"",
                    ""id"": ""01b44785-bd60-41a1-afc8-f5f377ca42b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DropItem"",
                    ""type"": ""Button"",
                    ""id"": ""a8643b13-ddc6-462c-9dd8-5fbdcc3ea147"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""597c594b-b70d-4e3d-9be3-84c28aec3f95"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,ScaleVector2(x=0.6)"",
                    ""groups"": ""Controller"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5582b19-a51d-441b-9d28-45b6e939bfbe"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b774a769-4229-4f2f-9c3b-d95b243654f7"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68d9e597-5617-434b-927a-d85b101e7c0a"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button5"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbd8d5ef-c544-472d-8250-24b436cdae58"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""RotateItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d64cf56-989b-4784-88ff-63e1ec500e9a"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Walk = m_Player.FindAction("Walk", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Use = m_Player.FindAction("Use", throwIfNotFound: true);
        m_Player_RotateItem = m_Player.FindAction("RotateItem", throwIfNotFound: true);
        m_Player_DropItem = m_Player.FindAction("DropItem", throwIfNotFound: true);
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Walk = m_Player1.FindAction("Walk", throwIfNotFound: true);
        m_Player1_Run = m_Player1.FindAction("Run", throwIfNotFound: true);
        m_Player1_Interact = m_Player1.FindAction("Interact", throwIfNotFound: true);
        m_Player1_Use = m_Player1.FindAction("Use", throwIfNotFound: true);
        m_Player1_RotateItem = m_Player1.FindAction("RotateItem", throwIfNotFound: true);
        m_Player1_DropItem = m_Player1.FindAction("DropItem", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Walk = m_Player2.FindAction("Walk", throwIfNotFound: true);
        m_Player2_Run = m_Player2.FindAction("Run", throwIfNotFound: true);
        m_Player2_Interact = m_Player2.FindAction("Interact", throwIfNotFound: true);
        m_Player2_Use = m_Player2.FindAction("Use", throwIfNotFound: true);
        m_Player2_RotateItem = m_Player2.FindAction("RotateItem", throwIfNotFound: true);
        m_Player2_DropItem = m_Player2.FindAction("DropItem", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Walk;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Use;
    private readonly InputAction m_Player_RotateItem;
    private readonly InputAction m_Player_DropItem;
    public struct PlayerActions
    {
        private @Character m_Wrapper;
        public PlayerActions(@Character wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Player_Walk;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Use => m_Wrapper.m_Player_Use;
        public InputAction @RotateItem => m_Wrapper.m_Player_RotateItem;
        public InputAction @DropItem => m_Wrapper.m_Player_DropItem;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Use.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @RotateItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateItem;
                @RotateItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateItem;
                @RotateItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateItem;
                @DropItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropItem;
                @DropItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropItem;
                @DropItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropItem;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @RotateItem.started += instance.OnRotateItem;
                @RotateItem.performed += instance.OnRotateItem;
                @RotateItem.canceled += instance.OnRotateItem;
                @DropItem.started += instance.OnDropItem;
                @DropItem.performed += instance.OnDropItem;
                @DropItem.canceled += instance.OnDropItem;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Walk;
    private readonly InputAction m_Player1_Run;
    private readonly InputAction m_Player1_Interact;
    private readonly InputAction m_Player1_Use;
    private readonly InputAction m_Player1_RotateItem;
    private readonly InputAction m_Player1_DropItem;
    public struct Player1Actions
    {
        private @Character m_Wrapper;
        public Player1Actions(@Character wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Player1_Walk;
        public InputAction @Run => m_Wrapper.m_Player1_Run;
        public InputAction @Interact => m_Wrapper.m_Player1_Interact;
        public InputAction @Use => m_Wrapper.m_Player1_Use;
        public InputAction @RotateItem => m_Wrapper.m_Player1_RotateItem;
        public InputAction @DropItem => m_Wrapper.m_Player1_DropItem;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnWalk;
                @Run.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRun;
                @Interact.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInteract;
                @Use.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUse;
                @RotateItem.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRotateItem;
                @RotateItem.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRotateItem;
                @RotateItem.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRotateItem;
                @DropItem.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDropItem;
                @DropItem.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDropItem;
                @DropItem.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDropItem;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @RotateItem.started += instance.OnRotateItem;
                @RotateItem.performed += instance.OnRotateItem;
                @RotateItem.canceled += instance.OnRotateItem;
                @DropItem.started += instance.OnDropItem;
                @DropItem.performed += instance.OnDropItem;
                @DropItem.canceled += instance.OnDropItem;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Walk;
    private readonly InputAction m_Player2_Run;
    private readonly InputAction m_Player2_Interact;
    private readonly InputAction m_Player2_Use;
    private readonly InputAction m_Player2_RotateItem;
    private readonly InputAction m_Player2_DropItem;
    public struct Player2Actions
    {
        private @Character m_Wrapper;
        public Player2Actions(@Character wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Player2_Walk;
        public InputAction @Run => m_Wrapper.m_Player2_Run;
        public InputAction @Interact => m_Wrapper.m_Player2_Interact;
        public InputAction @Use => m_Wrapper.m_Player2_Use;
        public InputAction @RotateItem => m_Wrapper.m_Player2_RotateItem;
        public InputAction @DropItem => m_Wrapper.m_Player2_DropItem;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnWalk;
                @Run.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRun;
                @Interact.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnInteract;
                @Use.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnUse;
                @RotateItem.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRotateItem;
                @RotateItem.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRotateItem;
                @RotateItem.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRotateItem;
                @DropItem.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDropItem;
                @DropItem.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDropItem;
                @DropItem.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDropItem;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @RotateItem.started += instance.OnRotateItem;
                @RotateItem.performed += instance.OnRotateItem;
                @RotateItem.canceled += instance.OnRotateItem;
                @DropItem.started += instance.OnDropItem;
                @DropItem.performed += instance.OnDropItem;
                @DropItem.canceled += instance.OnDropItem;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
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
    public interface IPlayerActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnRotateItem(InputAction.CallbackContext context);
        void OnDropItem(InputAction.CallbackContext context);
    }
    public interface IPlayer1Actions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnRotateItem(InputAction.CallbackContext context);
        void OnDropItem(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnRotateItem(InputAction.CallbackContext context);
        void OnDropItem(InputAction.CallbackContext context);
    }
}
