// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/EditorScene/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""fa76ed1e-0494-4237-941d-0f8819e91115"",
            ""actions"": [
                {
                    ""name"": ""FirstFinger"",
                    ""type"": ""Value"",
                    ""id"": ""fd3c094a-967b-4ebc-911d-593564ff20d9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondFinger"",
                    ""type"": ""Value"",
                    ""id"": ""4ba43310-fc36-4334-81fb-56f396dbee5b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondFingerContact"",
                    ""type"": ""Button"",
                    ""id"": ""a2e2310d-acb7-44f5-89af-14d19027c58c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8b27f07-d236-43da-8291-c1da33e3e2ae"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstFinger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b00c6b90-be5d-4b76-9189-3a11a122ec6c"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondFinger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5310a93-ae45-4144-bfaf-021b28ecefd0"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondFingerContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_FirstFinger = m_Touch.FindAction("FirstFinger", throwIfNotFound: true);
        m_Touch_SecondFinger = m_Touch.FindAction("SecondFinger", throwIfNotFound: true);
        m_Touch_SecondFingerContact = m_Touch.FindAction("SecondFingerContact", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_FirstFinger;
    private readonly InputAction m_Touch_SecondFinger;
    private readonly InputAction m_Touch_SecondFingerContact;
    public struct TouchActions
    {
        private @TouchControls m_Wrapper;
        public TouchActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @FirstFinger => m_Wrapper.m_Touch_FirstFinger;
        public InputAction @SecondFinger => m_Wrapper.m_Touch_SecondFinger;
        public InputAction @SecondFingerContact => m_Wrapper.m_Touch_SecondFingerContact;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @FirstFinger.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstFinger;
                @FirstFinger.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstFinger;
                @FirstFinger.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstFinger;
                @SecondFinger.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondFinger;
                @SecondFinger.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondFinger;
                @SecondFinger.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondFinger;
                @SecondFingerContact.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondFingerContact;
                @SecondFingerContact.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondFingerContact;
                @SecondFingerContact.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondFingerContact;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FirstFinger.started += instance.OnFirstFinger;
                @FirstFinger.performed += instance.OnFirstFinger;
                @FirstFinger.canceled += instance.OnFirstFinger;
                @SecondFinger.started += instance.OnSecondFinger;
                @SecondFinger.performed += instance.OnSecondFinger;
                @SecondFinger.canceled += instance.OnSecondFinger;
                @SecondFingerContact.started += instance.OnSecondFingerContact;
                @SecondFingerContact.performed += instance.OnSecondFingerContact;
                @SecondFingerContact.canceled += instance.OnSecondFingerContact;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnFirstFinger(InputAction.CallbackContext context);
        void OnSecondFinger(InputAction.CallbackContext context);
        void OnSecondFingerContact(InputAction.CallbackContext context);
    }
}
