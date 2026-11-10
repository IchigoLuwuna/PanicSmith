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
        m_LevelTimer = FindFirstObjectByType<Timer>();
    }

    void FixedUpdate()
    {
        Sync();
    }

    private void Sync()
    {
        if (m_LevelTimer == null)
        {
            return;
        }

        SetTime(m_LevelTimer.time);
        return;
    }

    private void SetTime(float time)
    {
        int minutes = (int)time / 60;
        float seconds = time - 60 * minutes;

        if (m_TimerLabel != null)
        {
            m_TimerLabel.text =
                $"Shift time left\n{minutes.ToString("00")}:{seconds.ToString("00.0")}";
        }
    }
}
