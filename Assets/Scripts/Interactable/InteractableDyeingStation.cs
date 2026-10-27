using UnityEngine;

public class InteractableDyeingStation : MonoBehaviour, IInteractable
{
    private GameState m_GameState;

    public void Start()
    {
        m_GameState = FindFirstObjectByType<GameState>();
        if (m_GameState == null)
        {
            Debug.Log("Could not find game state");
        }
    }

    public void Interact()
    {
        if (m_GameState == null)
        {
            return;
        }

        m_GameState.state = GameState.State.DyeingStation;
    }
}
