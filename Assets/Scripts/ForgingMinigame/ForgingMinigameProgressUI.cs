using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForgingMinigameProgressUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_ProgressLabel;

    private ForgingMinigame m_ForgingMinigame;

    void Start()
    {
        m_ForgingMinigame = FindFirstObjectByType<ForgingMinigame>();
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

        if (m_ProgressLabel != null)
        {
            m_ProgressLabel.text =
                $"Swings left: {m_ForgingMinigame.swingsLeft}\nQuality: {m_ForgingMinigame.accumulatedPoints}";
        }
    }
}
