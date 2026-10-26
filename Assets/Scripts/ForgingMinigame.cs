using UnityEngine;
using UnityEngine.InputSystem;

public class ForgingMinigame : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset m_InputAsset;

    private InputAction m_PrimaryAction;
    private InputAction m_ExitAction;

    private GameState m_GameState;
    private ForgingMinigameBarHitChecker m_ForgingMinigameBarHitChecker;
    private ForgingMinigameBarMovement m_ForgingMinigameBarMovement;

    void Start()
    {
        m_GameState = FindFirstObjectByType<GameState>();
        m_ForgingMinigameBarHitChecker = FindFirstObjectByType<ForgingMinigameBarHitChecker>();
        m_ForgingMinigameBarMovement = FindFirstObjectByType<ForgingMinigameBarMovement>();

        m_PrimaryAction = m_InputAsset.FindActionMap("Generic").FindAction("Primary");
        if (m_ExitAction == null)
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
        m_ForgingMinigameBarMovement.Stop();
        m_ForgingMinigameBarHitChecker.Check();
    }

    private void HandleExitAction(InputAction.CallbackContext context)
    {
        m_GameState.state = GameState.State.WorkShop;
    }
}
