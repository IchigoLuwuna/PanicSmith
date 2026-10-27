using UnityEngine;

public class DyeingMinigame : MonoBehaviour
{
    private GameState m_GameState;
    private Inventory m_Inventory;

    void Start()
    {
        m_GameState = FindFirstObjectByType<GameState>();
        m_Inventory = FindFirstObjectByType<Inventory>();
    }

    public void PrimaryAction()
    {
        m_Inventory.AddHandle(0);
    }

    public void SecondaryAction()
    {
        m_Inventory.AddHandle(1);
    }

    public void TertiaryAction()
    {
        m_Inventory.AddHandle(2);
    }

    public void ExitAction()
    {
        m_GameState.state = GameState.State.WorkShop;
    }
}
