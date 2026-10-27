using UnityEngine;
using UnityEngine.InputSystem;

public class DyeingMinigameInput : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset m_InputAsset;

    private InputAction m_PrimaryAction;
    private InputAction m_SecondaryAction;
    private InputAction m_TertiaryAction;
    private InputAction m_ExitAction;

    private DyeingMinigame m_DyeingMinigame;

    void Start()
    {
        m_DyeingMinigame = gameObject.GetComponent<DyeingMinigame>();
        if (m_DyeingMinigame == null)
        {
            Debug.Log("Could not find dyeing minigame component");
        }

        m_PrimaryAction = m_InputAsset.FindActionMap("Generic").FindAction("Primary");
        if (m_PrimaryAction == null)
        {
            Debug.Log("Could not find primary action");
        }

        m_SecondaryAction = m_InputAsset.FindActionMap("Generic").FindAction("Secondary");
        if (m_SecondaryAction == null)
        {
            Debug.Log("Could not find secondary action");
        }

        m_TertiaryAction = m_InputAsset.FindActionMap("Generic").FindAction("Tertiary");
        if (m_TertiaryAction == null)
        {
            Debug.Log("Could not find tertiary action");
        }

        m_ExitAction = m_InputAsset.FindActionMap("Generic").FindAction("Exit");
        if (m_ExitAction == null)
        {
            Debug.Log("Could not find exit action");
        }
    }

    private void OnEnable()
    {
        if (m_InputAsset == null)
        {
            return;
        }

        m_InputAsset.Enable();

        Start();

        m_PrimaryAction.performed += HandlePrimaryAction;
        m_SecondaryAction.performed += HandleSecondaryAction;
        m_TertiaryAction.performed += HandleTertiaryAction;
        m_ExitAction.performed += HandleExitAction;
    }

    private void OnDisable()
    {
        if (m_InputAsset == null)
        {
            return;
        }

        m_InputAsset.Disable();

        m_ExitAction.performed -= HandleExitAction;
        m_TertiaryAction.performed -= HandleTertiaryAction;
        m_SecondaryAction.performed -= HandleSecondaryAction;
        m_PrimaryAction.performed -= HandlePrimaryAction;
    }

    private void HandlePrimaryAction(InputAction.CallbackContext context)
    {
        m_DyeingMinigame.PrimaryAction();
    }

    private void HandleSecondaryAction(InputAction.CallbackContext context)
    {
        m_DyeingMinigame.SecondaryAction();
    }

    private void HandleTertiaryAction(InputAction.CallbackContext context)
    {
        m_DyeingMinigame.TertiaryAction();
    }

    private void HandleExitAction(InputAction.CallbackContext context)
    {
        m_DyeingMinigame.ExitAction();
    }
}
