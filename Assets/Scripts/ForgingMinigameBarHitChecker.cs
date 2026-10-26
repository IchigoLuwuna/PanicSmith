using UnityEngine;

public class ForgingMinigameBarHitChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject m_TimingBar;

    [SerializeField]
    private GameObject m_Bar;

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
    private float countdown = 1f;
    private float m_Countdown;

    private bool m_CountdownStarted = false;

    private GameState m_GameState;

    void Start()
    {
        m_GameState = FindFirstObjectByType<GameState>();
    }

    private void OnEnable()
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
            Check();
            m_CountdownStarted = false;
        }
    }

    public void StartCheck()
    {
        m_CountdownStarted = true;
    }

    private void Reset()
    {
        m_Countdown = countdown;
        m_CountdownStarted = false;
    }

    private void Check()
    {
        RectTransform barRectTrans = m_Bar.GetComponent<RectTransform>();
        Rect barRect = new Rect(
            barRectTrans.localPosition.x + barRectTrans.rect.x,
            barRectTrans.localPosition.y + barRectTrans.rect.y,
            barRectTrans.rect.width,
            barRectTrans.rect.height
        );

        RectTransform[] timingBarRectTranses = m_TimingBar.GetComponentsInChildren<RectTransform>();

        GameObject barHit = null;

        foreach (RectTransform timingBarRectTrans in timingBarRectTranses)
        {
            Rect timingRect = new Rect(
                timingBarRectTrans.rect.x,
                timingBarRectTrans.rect.y,
                timingBarRectTrans.rect.width,
                timingBarRectTrans.rect.height
            );

            if (barRect.Overlaps(timingRect))
            {
                barHit = timingBarRectTrans.gameObject;
            }
        }

        // Miss
        if (barHit == null)
        {
            m_GameState.state = GameState.State.WorkShop;
            return;
        }

        int barHitValue = barHit.gameObject.GetComponent<ForgingMinigameTimingBarValue>().value;
        Debug.Log(barHitValue);
        m_AccumulatedPoints += barHitValue;

        // Completed
        if (m_AccumulatedPoints >= m_CompleteThreshold)
        {
            m_GameState.state = GameState.State.WorkShop;
            return;
        }

        Reset();
        m_Bar.gameObject.GetComponent<ForgingMinigameBarMovement>().Reset();
    }
}
