//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/Input/PlayerInputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputMap"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""314fa8fa-a212-499b-8395-4af7d461fc98"",
            ""actions"": [
                {
                    ""name"": ""PlayerMovement"",
                    ""type"": ""Value"",
                    ""id"": ""1006a21c-3d2b-42c4-b115-fb38462bfa32"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ClawMovement"",
                    ""type"": ""Value"",
                    ""id"": ""4bf2bae1-3c93-431a-9b8f-33c2586da89e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9c99da62-c609-433a-9d01-8aac6c048696"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PickObject"",
                    ""type"": ""Button"",
                    ""id"": ""2a33d474-e4a6-4ad7-926c-d88d261e4793"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DropObject"",
                    ""type"": ""Button"",
                    ""id"": ""77c67071-7c9e-440b-b4be-2799eece4dd7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThrowObject"",
                    ""type"": ""Button"",
                    ""id"": ""9b4cf7ef-6745-415f-b44a-079434d0234f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ProcessTrash"",
                    ""type"": ""Button"",
                    ""id"": ""ff5e7454-9352-4171-bef3-136f9f5c5a25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""9d2cd550-1635-466d-b93b-c0b1626e31f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0cedd9a9-ead8-4356-8d92-15a56c177853"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a8ec41b0-6c82-486a-820a-280c677318f8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0d436c6a-8294-4f8c-8a71-1a1ffda31d82"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d97c0193-1225-434b-a1a3-fb483db1d3d3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9d6058d2-fea8-42db-b909-877fcc4d4564"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""e2229831-89fe-4571-be7a-a8f62e8bfa13"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d2d713d7-f36d-414d-ab7a-6d332b9c12d2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""92752d07-67c0-4acb-a644-9ce2b14dee8e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6c79928d-68bb-4ac1-869b-792b91b0f210"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b8dbcb4b-faef-4a41-a052-b7cb346a30e7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a587dfe4-97b2-42b8-85ae-502edaf6cf05"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""ClawMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26137ecb-d73a-4d42-b030-6816798d90e5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d71bb22-006d-41a5-a415-43023459e240"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ab3cebf-a740-4a53-bc24-95a2dd9b8303"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""PickObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b71a9981-5208-4f40-950c-0f08d233ff8f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""DropObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63ffe173-c38a-4577-9049-82d7e722f970"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""ThrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86a77768-60b2-49da-b85d-dc0cecc3766b"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""ProcessTrash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause"",
            ""id"": ""b3052f9d-87d3-4818-9bbd-247ce90a8fa7"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""82d743de-d889-4da0-b007-233fbade0814"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa9e98d7-db3a-4505-8f96-f0e4e1a2a275"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""88d56b3e-a8e6-4f62-9a2a-d6564ac5a5f1"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""8da9ea22-71af-4036-a294-b325ad027cdd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""050f65c4-5617-41c6-8f11-aa6d9cbe20f4"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
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
            ""name"": ""Keyboard And Mouse"",
            ""bindingGroup"": ""Keyboard And Mouse"",
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
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_PlayerMovement = m_Gameplay.FindAction("PlayerMovement", throwIfNotFound: true);
        m_Gameplay_ClawMovement = m_Gameplay.FindAction("ClawMovement", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_PickObject = m_Gameplay.FindAction("PickObject", throwIfNotFound: true);
        m_Gameplay_DropObject = m_Gameplay.FindAction("DropObject", throwIfNotFound: true);
        m_Gameplay_ThrowObject = m_Gameplay.FindAction("ThrowObject", throwIfNotFound: true);
        m_Gameplay_ProcessTrash = m_Gameplay.FindAction("ProcessTrash", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        // Pause
        m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
        m_Pause_Newaction = m_Pause.FindAction("New action", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Newaction = m_MainMenu.FindAction("New action", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_PlayerMovement;
    private readonly InputAction m_Gameplay_ClawMovement;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_PickObject;
    private readonly InputAction m_Gameplay_DropObject;
    private readonly InputAction m_Gameplay_ThrowObject;
    private readonly InputAction m_Gameplay_ProcessTrash;
    private readonly InputAction m_Gameplay_Pause;
    public struct GameplayActions
    {
        private @PlayerInputMap m_Wrapper;
        public GameplayActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerMovement => m_Wrapper.m_Gameplay_PlayerMovement;
        public InputAction @ClawMovement => m_Wrapper.m_Gameplay_ClawMovement;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @PickObject => m_Wrapper.m_Gameplay_PickObject;
        public InputAction @DropObject => m_Wrapper.m_Gameplay_DropObject;
        public InputAction @ThrowObject => m_Wrapper.m_Gameplay_ThrowObject;
        public InputAction @ProcessTrash => m_Wrapper.m_Gameplay_ProcessTrash;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @PlayerMovement.started += instance.OnPlayerMovement;
            @PlayerMovement.performed += instance.OnPlayerMovement;
            @PlayerMovement.canceled += instance.OnPlayerMovement;
            @ClawMovement.started += instance.OnClawMovement;
            @ClawMovement.performed += instance.OnClawMovement;
            @ClawMovement.canceled += instance.OnClawMovement;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @PickObject.started += instance.OnPickObject;
            @PickObject.performed += instance.OnPickObject;
            @PickObject.canceled += instance.OnPickObject;
            @DropObject.started += instance.OnDropObject;
            @DropObject.performed += instance.OnDropObject;
            @DropObject.canceled += instance.OnDropObject;
            @ThrowObject.started += instance.OnThrowObject;
            @ThrowObject.performed += instance.OnThrowObject;
            @ThrowObject.canceled += instance.OnThrowObject;
            @ProcessTrash.started += instance.OnProcessTrash;
            @ProcessTrash.performed += instance.OnProcessTrash;
            @ProcessTrash.canceled += instance.OnProcessTrash;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @PlayerMovement.started -= instance.OnPlayerMovement;
            @PlayerMovement.performed -= instance.OnPlayerMovement;
            @PlayerMovement.canceled -= instance.OnPlayerMovement;
            @ClawMovement.started -= instance.OnClawMovement;
            @ClawMovement.performed -= instance.OnClawMovement;
            @ClawMovement.canceled -= instance.OnClawMovement;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @PickObject.started -= instance.OnPickObject;
            @PickObject.performed -= instance.OnPickObject;
            @PickObject.canceled -= instance.OnPickObject;
            @DropObject.started -= instance.OnDropObject;
            @DropObject.performed -= instance.OnDropObject;
            @DropObject.canceled -= instance.OnDropObject;
            @ThrowObject.started -= instance.OnThrowObject;
            @ThrowObject.performed -= instance.OnThrowObject;
            @ThrowObject.canceled -= instance.OnThrowObject;
            @ProcessTrash.started -= instance.OnProcessTrash;
            @ProcessTrash.performed -= instance.OnProcessTrash;
            @ProcessTrash.canceled -= instance.OnProcessTrash;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Pause
    private readonly InputActionMap m_Pause;
    private List<IPauseActions> m_PauseActionsCallbackInterfaces = new List<IPauseActions>();
    private readonly InputAction m_Pause_Newaction;
    public struct PauseActions
    {
        private @PlayerInputMap m_Wrapper;
        public PauseActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Pause_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Pause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
        public void AddCallbacks(IPauseActions instance)
        {
            if (instance == null || m_Wrapper.m_PauseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PauseActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IPauseActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IPauseActions instance)
        {
            if (m_Wrapper.m_PauseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPauseActions instance)
        {
            foreach (var item in m_Wrapper.m_PauseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PauseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PauseActions @Pause => new PauseActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private List<IMainMenuActions> m_MainMenuActionsCallbackInterfaces = new List<IMainMenuActions>();
    private readonly InputAction m_MainMenu_Newaction;
    public struct MainMenuActions
    {
        private @PlayerInputMap m_Wrapper;
        public MainMenuActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_MainMenu_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void AddCallbacks(IMainMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_MainMenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainMenuActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IMainMenuActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainMenuActions instance)
        {
            foreach (var item in m_Wrapper.m_MainMenuActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainMenuActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard And Mouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnPlayerMovement(InputAction.CallbackContext context);
        void OnClawMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPickObject(InputAction.CallbackContext context);
        void OnDropObject(InputAction.CallbackContext context);
        void OnThrowObject(InputAction.CallbackContext context);
        void OnProcessTrash(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IPauseActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}