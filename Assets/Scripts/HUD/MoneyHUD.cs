using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_MoneyLabel;

    private Inventory m_Inventory;
    private GameState m_GameState;

    private bool m_MoneyGainStarted;

    void Start()
    {
        m_Inventory = FindFirstObjectByType<Inventory>();
        m_GameState = FindFirstObjectByType<GameState>();
    }

    void Update()
    {
        if (m_Inventory == null)
        {
            return;
        }

        if (m_GameState == null)
        {
            return;
        }

        if (m_MoneyLabel == null)
        {
            return;
        }

        string displayString = $"Money\n{m_Inventory.money}/{m_GameState.quota}";

        if (m_Inventory.moneyDiff != 0)
        {
            m_MoneyGainStarted = true;
            displayString += $"\n+{m_Inventory.moneyDiff}";
        }
        if (m_Inventory.moneyDiff == 0 && m_MoneyGainStarted)
        {
            displayString += $"\nOrder Failed";
        }

        m_MoneyLabel.text = displayString;
    }
}
