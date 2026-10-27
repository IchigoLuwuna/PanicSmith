using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public enum State
    {
        WorkShop,
        ForgingStation,
        DyeingStation,
    }

    private State m_State = State.WorkShop;
    public State state
    {
        get { return m_State; }
        set
        {
            OnExit();
            m_State = value;
            OnEnter();
        }
    }

    private Timer m_LevelTimer;
    private PlayerCharacter m_PlayerCharacterController;
    private Health m_PlayerHealth;

    [SerializeField]
    private GameObject m_ForgingMinigame;

    [SerializeField]
    private GameObject m_DyeingMinigame;

    private bool m_GameWon = false;
    public bool gameWon
    {
        set { m_GameWon = value; }
    }

    void Start()
    {
        m_LevelTimer = FindFirstObjectByType<Timer>();
        if (m_LevelTimer == null)
        {
            Debug.Log("Could not find timer");
        }

        m_PlayerCharacterController = FindFirstObjectByType<PlayerCharacter>();
        if (m_PlayerCharacterController == null)
        {
            Debug.Log("Could not find player character controller");
        }
        m_PlayerHealth = m_PlayerCharacterController.gameObject.GetComponent<Health>();
        if (m_PlayerHealth == null)
        {
            Debug.Log("Could not find health");
        }
    }

    // On entering new state
    void OnEnter()
    {
        switch (state)
        {
            case State.WorkShop:
            {
                break;
            }
            case State.ForgingStation:
            {
                m_ForgingMinigame.SetActive(true);
                m_PlayerCharacterController.enabled = false;
                break;
            }
            case State.DyeingStation:
            {
                m_DyeingMinigame.SetActive(true);
                m_PlayerCharacterController.enabled = false;
                break;
            }
        }
    }

    // On exiting old state
    void OnExit()
    {
        switch (state)
        {
            case State.WorkShop:
            {
                break;
            }
            case State.ForgingStation:
            {
                m_ForgingMinigame.SetActive(false);
                m_PlayerCharacterController.enabled = true;
                break;
            }
            case State.DyeingStation:
            {
                m_DyeingMinigame.SetActive(false);
                m_PlayerCharacterController.enabled = true;
                break;
            }
        }
    }

    void FixedUpdate()
    {
        if (m_PlayerHealth == null)
        {
            return;
        }
        if (m_LevelTimer == null)
        {
            return;
        }

        if (m_GameWon)
        {
            SceneManager.LoadScene("WinScene");
        }

        if (m_LevelTimer.time <= 0.001f)
        {
            m_PlayerHealth.Kill();

            SceneManager.LoadScene("GameOverScene");
        }
    }
}
