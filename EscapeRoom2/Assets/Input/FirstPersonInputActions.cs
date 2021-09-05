// GENERATED AUTOMATICALLY FROM 'Assets/Input/FirstPersonInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FirstPersonInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FirstPersonInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FirstPersonInputActions"",
    ""maps"": [
        {
            ""name"": ""Player (Keyboard and Mouse)"",
            ""id"": ""e337916b-004e-4912-8802-3f0f6941d95c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""a0b5bb65-d7b2-4f57-992d-386b2036ff31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""c9504440-667f-48bc-926c-15b32965efb1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""43fefbdf-69d1-46e9-978c-64102dcfd37a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""dc5e3d90-ffb4-4eb8-ae9a-b242b3ecaca0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d2b6997a-a182-4253-8f19-8307af410fba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e07e1af0-1225-4151-bd8f-a0e266468b60"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""daf24648-7f19-462f-8c19-4ea2ed5cb0df"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1636d358-a1c6-4fe9-be63-5fe1683e0264"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3ea44580-ca31-4497-9817-9e8faf9f760a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77e8fa3a-c802-4b64-84cc-05baca115d2f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player (Gamepad)"",
            ""id"": ""064dad6e-f695-4c98-8ec4-8e97d00b371a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""bd4e7bdd-0291-4a0d-9869-86ab299aa902"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""6401bf5f-6fb0-427b-b9a5-3214d4997e4c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""127d6e6f-4989-42d1-a5bd-ae50b4c4461a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""b667d59d-c44d-4e72-8c2f-f7332411117a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b21461a2-f428-43f3-abf5-45648c3b3a51"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2a32b95c-e691-4854-9a5f-bba145d8c564"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6b99ad33-1d32-48d1-8310-428fbd27e9e2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c9043322-b1d9-44f2-8374-f042e473175a"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c366ee20-908a-42b8-affe-161f3731d6c5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ad43d29-2338-4ddd-9cf1-7e8f3cd83e7e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player (Keyboard and Mouse)
        m_PlayerKeyboardandMouse = asset.FindActionMap("Player (Keyboard and Mouse)", throwIfNotFound: true);
        m_PlayerKeyboardandMouse_Move = m_PlayerKeyboardandMouse.FindAction("Move", throwIfNotFound: true);
        m_PlayerKeyboardandMouse_Look = m_PlayerKeyboardandMouse.FindAction("Look", throwIfNotFound: true);
        m_PlayerKeyboardandMouse_Select = m_PlayerKeyboardandMouse.FindAction("Select", throwIfNotFound: true);
        // Player (Gamepad)
        m_PlayerGamepad = asset.FindActionMap("Player (Gamepad)", throwIfNotFound: true);
        m_PlayerGamepad_Move = m_PlayerGamepad.FindAction("Move", throwIfNotFound: true);
        m_PlayerGamepad_Look = m_PlayerGamepad.FindAction("Look", throwIfNotFound: true);
        m_PlayerGamepad_Select = m_PlayerGamepad.FindAction("Select", throwIfNotFound: true);
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

    // Player (Keyboard and Mouse)
    private readonly InputActionMap m_PlayerKeyboardandMouse;
    private IPlayerKeyboardandMouseActions m_PlayerKeyboardandMouseActionsCallbackInterface;
    private readonly InputAction m_PlayerKeyboardandMouse_Move;
    private readonly InputAction m_PlayerKeyboardandMouse_Look;
    private readonly InputAction m_PlayerKeyboardandMouse_Select;
    public struct PlayerKeyboardandMouseActions
    {
        private @FirstPersonInputActions m_Wrapper;
        public PlayerKeyboardandMouseActions(@FirstPersonInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerKeyboardandMouse_Move;
        public InputAction @Look => m_Wrapper.m_PlayerKeyboardandMouse_Look;
        public InputAction @Select => m_Wrapper.m_PlayerKeyboardandMouse_Select;
        public InputActionMap Get() { return m_Wrapper.m_PlayerKeyboardandMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerKeyboardandMouseActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerKeyboardandMouseActions instance)
        {
            if (m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface.OnLook;
                @Select.started -= m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_PlayerKeyboardandMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public PlayerKeyboardandMouseActions @PlayerKeyboardandMouse => new PlayerKeyboardandMouseActions(this);

    // Player (Gamepad)
    private readonly InputActionMap m_PlayerGamepad;
    private IPlayerGamepadActions m_PlayerGamepadActionsCallbackInterface;
    private readonly InputAction m_PlayerGamepad_Move;
    private readonly InputAction m_PlayerGamepad_Look;
    private readonly InputAction m_PlayerGamepad_Select;
    public struct PlayerGamepadActions
    {
        private @FirstPersonInputActions m_Wrapper;
        public PlayerGamepadActions(@FirstPersonInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerGamepad_Move;
        public InputAction @Look => m_Wrapper.m_PlayerGamepad_Look;
        public InputAction @Select => m_Wrapper.m_PlayerGamepad_Select;
        public InputActionMap Get() { return m_Wrapper.m_PlayerGamepad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerGamepadActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerGamepadActions instance)
        {
            if (m_Wrapper.m_PlayerGamepadActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerGamepadActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerGamepadActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerGamepadActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerGamepadActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerGamepadActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerGamepadActionsCallbackInterface.OnLook;
                @Select.started -= m_Wrapper.m_PlayerGamepadActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerGamepadActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerGamepadActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_PlayerGamepadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public PlayerGamepadActions @PlayerGamepad => new PlayerGamepadActions(this);
    public interface IPlayerKeyboardandMouseActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IPlayerGamepadActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
