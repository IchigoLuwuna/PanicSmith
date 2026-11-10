using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float m_TimerMax;

    [SerializeField]
    private bool m_TimerEnable = true;

    private float m_Timer;

    public float time
    {
        get { return m_Timer; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Timer = m_TimerMax;
    }

    void FixedUpdate()
    {
        if (!m_TimerEnable)
        {
            return;
        }

        m_Timer -= Time.deltaTime;
        m_Timer = Mathf.Clamp(m_Timer, 0f, m_TimerMax);
    }
}
