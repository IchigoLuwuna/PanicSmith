using UnityEngine;

public class ForgingMinigameBarHitChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject m_TimingBar;

    [SerializeField]
    private GameObject m_Bar;

    [SerializeField]
    private float countDown = 1f;
    private float m_CountDown;

    private bool m_Started = false;

    private GameState m_GameState;

    void Start()
    {
        m_GameState = FindFirstObjectByType<GameState>();
    }

    private void OnEnable()
    {
        m_CountDown = countDown;
        m_Started = false;
    }

    void FixedUpdate()
    {
        if (!m_Started)
        {
            return;
        }

        m_CountDown -= Time.deltaTime;

        if (m_CountDown < 0.001f)
        {
            Check();
            m_Started = false;
        }
    }

    public void StartCheck()
    {
        m_Started = true;
    }

    private void Check()
    {
        m_GameState.state = GameState.State.WorkShop;
    }
}
