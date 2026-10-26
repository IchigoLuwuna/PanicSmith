using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForgingMinigameProgressUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_ProgressLabel;

    private ForgingMinigameBarHitChecker m_ForgingMinigame;

    void Start()
    {
        m_ForgingMinigame = FindFirstObjectByType<ForgingMinigameBarHitChecker>();
    }

    void FixedUpdate()
    {
        Sync();
    }

    private void Sync()
    {
        if (m_ForgingMinigame == null)
        {
            return;
        }

        SetProgress(m_ForgingMinigame.accumulatedPoints, m_ForgingMinigame.completeThreshold);
    }

    private void SetProgress(int amount, int needed)
    {
        if (m_ProgressLabel != null)
        {
            m_ProgressLabel.text = $"{amount}/{needed}";
        }
    }
}
