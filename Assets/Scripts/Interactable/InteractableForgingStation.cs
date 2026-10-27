using UnityEngine;

public class InteractableForgingStation : MonoBehaviour, IInteractable
{
    private GameState m_GameState;
    private Inventory m_Inventory;

    public void Start()
    {
        m_GameState = FindFirstObjectByType<GameState>();
        if (m_GameState == null)
        {
            Debug.Log("Could not find game state");
        }

        m_Inventory = FindFirstObjectByType<Inventory>();
    }

    public void Interact()
    {
        if (m_GameState == null)
        {
            return;
        }

        m_Inventory.RemoveMoney(1);

        m_GameState.state = GameState.State.ForgingStation;
    }
}
