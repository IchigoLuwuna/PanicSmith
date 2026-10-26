using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : BasicCharacter
{
    [SerializeField]
    private InputActionAsset m_InputAsset;

    [SerializeField]
    private InputActionReference m_MovementAction;

    private InputAction m_InteractAction;

    private Interactor m_Interactor;

    protected override void Awake()
    {
        base.Awake();

        if (m_InputAsset == null)
        {
            return;
        }

        m_Interactor = gameObject.GetComponent<Interactor>();

        m_InteractAction = m_InputAsset.FindActionMap("Gameplay").FindAction("Interact");
        m_InteractAction.performed += HandleInteractInput;
    }

    protected void OnDestroy()
    {
        m_InteractAction.performed -= HandleInteractInput;
    }

    private void FixedUpdate()
    {
        HandleMovementInput();
    }

    private void OnEnable()
    {
        if (m_InputAsset == null)
        {
            return;
        }

        m_InputAsset.Enable();
    }

    private void OnDisable()
    {
        if (m_InputAsset == null)
        {
            return;
        }

        m_InputAsset.Disable();
    }

    private void HandleMovementInput()
    {
        if (m_MovementBehaviour == null || m_MovementAction == null)
        {
            return;
        }

        Vector2 movementInput = m_MovementAction.action.ReadValue<Vector2>();

        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);

        m_MovementBehaviour.desiredMovementDirection = movement;
    }

    private void HandleInteractInput(InputAction.CallbackContext context)
    {
        if (m_Interactor == null)
        {
            return;
        }

        m_Interactor.Interact();
    }
}
