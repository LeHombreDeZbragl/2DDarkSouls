// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""5a386114-0a11-42ad-9574-c1060eeb8ada"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e84abd84-7743-4ba9-9eb4-047c9c7c9411"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ed04d9a6-192a-4be6-9142-c9e5f4b86cc2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""27bb23d0-f005-4ac5-a6f9-224f879078fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""ddcdeb1e-0423-4eea-8bc0-d2f927c8ba34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""4411b41f-8bf7-4a7b-be8f-dd60482b59b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f3c5a4ae-b1c4-4f2c-8799-58bbaa672499"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c71ac1d1-ea88-41fe-aaa1-764af1a54dfb"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae91856a-9d2e-4bca-ae09-8d8675d01f51"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80c7273d-53e0-43d6-9448-bd3023ac7339"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7378631e-0fd4-43e5-977a-3884fb11b925"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox Control Scheme"",
            ""bindingGroup"": ""Xbox Control Scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Rotation = m_Gameplay.FindAction("Rotation", throwIfNotFound: true);
        m_Gameplay_SecondaryWeapon = m_Gameplay.FindAction("SecondaryWeapon", throwIfNotFound: true);
        m_Gameplay_PrimaryWeapon = m_Gameplay.FindAction("PrimaryWeapon", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Rotation;
    private readonly InputAction m_Gameplay_SecondaryWeapon;
    private readonly InputAction m_Gameplay_PrimaryWeapon;
    private readonly InputAction m_Gameplay_Dash;
    public struct GameplayActions
    {
        private @InputMaster m_Wrapper;
        public GameplayActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Rotation => m_Wrapper.m_Gameplay_Rotation;
        public InputAction @SecondaryWeapon => m_Wrapper.m_Gameplay_SecondaryWeapon;
        public InputAction @PrimaryWeapon => m_Wrapper.m_Gameplay_PrimaryWeapon;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Rotation.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                @SecondaryWeapon.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryWeapon;
                @SecondaryWeapon.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryWeapon;
                @SecondaryWeapon.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryWeapon;
                @PrimaryWeapon.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryWeapon;
                @PrimaryWeapon.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryWeapon;
                @PrimaryWeapon.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryWeapon;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @SecondaryWeapon.started += instance.OnSecondaryWeapon;
                @SecondaryWeapon.performed += instance.OnSecondaryWeapon;
                @SecondaryWeapon.canceled += instance.OnSecondaryWeapon;
                @PrimaryWeapon.started += instance.OnPrimaryWeapon;
                @PrimaryWeapon.performed += instance.OnPrimaryWeapon;
                @PrimaryWeapon.canceled += instance.OnPrimaryWeapon;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_XboxControlSchemeSchemeIndex = -1;
    public InputControlScheme XboxControlSchemeScheme
    {
        get
        {
            if (m_XboxControlSchemeSchemeIndex == -1) m_XboxControlSchemeSchemeIndex = asset.FindControlSchemeIndex("Xbox Control Scheme");
            return asset.controlSchemes[m_XboxControlSchemeSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnSecondaryWeapon(InputAction.CallbackContext context);
        void OnPrimaryWeapon(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
