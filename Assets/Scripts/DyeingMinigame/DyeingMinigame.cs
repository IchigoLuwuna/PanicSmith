using UnityEngine;

public class DyeingMinigame : MonoBehaviour
{
    private GameState m_GameState;

    void Start()
    {
        m_GameState = FindFirstObjectByType<GameState>();
    }

    void FixedUpdate()
    {
        ;
    }

    public void PrimaryAction()
    {
        Debug.Log("1");
    }

    public void SecondaryAction()
    {
        Debug.Log("2");
    }

    public void TertiaryAction()
    {
        Debug.Log("3");
    }

    public void ExitAction()
    {
        m_GameState.state = GameState.State.WorkShop;
    }
}
