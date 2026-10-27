using UnityEngine;

public class ForgingMinigame : MonoBehaviour
{
    private GameState m_GameState;
    private ForgingMinigameBarHitChecker m_ForgingMinigameBarHitChecker;
    private ForgingMinigameBarMovement m_ForgingMinigameBarMovement;

    [SerializeField]
    private int m_CompleteThreshold = 20;
    public int completeThreshold
    {
        get { return m_CompleteThreshold; }
    }

    private int m_AccumulatedPoints;
    public int accumulatedPoints
    {
        get { return m_AccumulatedPoints; }
    }

    [SerializeField]
    private float countdown = 0.5f;
    private float m_Countdown;

    [SerializeField]
    private float m_FinalCountdown = 1.5f;

    private bool m_CountdownStarted = false;

    void Start()
    {
        m_GameState = FindFirstObjectByType<GameState>();
        m_ForgingMinigameBarHitChecker = FindFirstObjectByType<ForgingMinigameBarHitChecker>();
        m_ForgingMinigameBarMovement = FindFirstObjectByType<ForgingMinigameBarMovement>();

        Reset();
    }

    void OnEnable()
    {
        Reset();

        m_AccumulatedPoints = 0;
    }

    void FixedUpdate()
    {
        if (!m_CountdownStarted)
        {
            return;
        }

        m_Countdown -= Time.deltaTime;

        if (m_Countdown < 0.001f)
        {
            m_CountdownStarted = false;

            Reset();
            m_ForgingMinigameBarMovement.Reset();

            if (m_AccumulatedPoints >= m_CompleteThreshold)
            {
                m_GameState.state = GameState.State.WorkShop;
                return;
            }
        }
    }

    private void Reset()
    {
        m_CountdownStarted = false;
        m_Countdown = countdown;
    }

    public void PrimaryAction()
    {
        m_ForgingMinigameBarMovement.Stop();
        int accumulator = m_ForgingMinigameBarHitChecker.Check();

        m_CountdownStarted = true;
        m_Countdown = countdown;

        if (accumulator == 0)
        {
            m_GameState.state = GameState.State.WorkShop;
            return;
        }
        m_AccumulatedPoints += accumulator;

        if (m_AccumulatedPoints >= m_CompleteThreshold)
        {
            m_Countdown = m_FinalCountdown;
        }
    }

    public void ExitAction()
    {
        m_GameState.state = GameState.State.WorkShop;
    }
}
