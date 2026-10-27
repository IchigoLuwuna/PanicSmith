using UnityEngine;
using UnityEngine.InputSystem;

public class ForgingMinigameInput : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset m_InputAsset;

    private InputAction m_PrimaryAction;
    private InputAction m_ExitAction;

    private ForgingMinigame m_ForgingMinigame;

    void Start()
    {
        m_ForgingMinigame = gameObject.GetComponent<ForgingMinigame>();
        if (m_ForgingMinigame == null)
        {
            Debug.Log("Could not find forging minigame component");
        }

        m_PrimaryAction = m_InputAsset.FindActionMap("Generic").FindAction("Primary");
        if (m_PrimaryAction == null)
        {
            Debug.Log("Could not find primary action");
        }
        m_PrimaryAction.performed += HandlePrimaryAction;

        m_ExitAction = m_InputAsset.FindActionMap("Generic").FindAction("Exit");
        if (m_ExitAction == null)
        {
            Debug.Log("Could not find exit action");
        }
        m_ExitAction.performed += HandleExitAction;
    }

    protected void OnDestroy()
    {
        m_ExitAction.performed -= HandleExitAction;
        m_PrimaryAction.performed -= HandlePrimaryAction;
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

    private void HandlePrimaryAction(InputAction.CallbackContext context)
    {
        m_ForgingMinigame.PrimaryAction();
    }

    private void HandleExitAction(InputAction.CallbackContext context)
    {
        m_ForgingMinigame.ExitAction();
    }
}
