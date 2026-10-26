using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_TimerLabel;

    private Timer m_LevelTimer;

    void Start()
    {
        var timer = FindFirstObjectByType<Timer>();
        m_LevelTimer = timer?.gameObject?.GetComponent<Timer>();
    }

    void Update()
    {
        Sync();
    }

    private void Sync()
    {
        if (m_LevelTimer == null)
        {
            return;
        }
        else
        {
            SetTime(m_LevelTimer.time);
        }
    }

    private void SetTime(float time)
    {
        if (m_TimerLabel != null)
        {
            m_TimerLabel.text = $"Time: {time.ToString("#.0")}";
        }
    }
}
