using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadShiftStats : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_StatsLabel;

    [SerializeField]
    private DataPasser m_DataPasser;

    private float m_Time;

    private int m_StatsShown;

    void Start()
    {
        m_StatsLabel.text = "";
    }

    void Update()
    {
        m_Time += Time.deltaTime;

        const float timeBetweenStats = 0.5f;

        if (m_Time >= timeBetweenStats * 1 && m_StatsShown == 0)
        {
            ++m_StatsShown;
            m_StatsLabel.text = $"Profit: {m_DataPasser.money}";
        }
        if (m_Time >= timeBetweenStats * 2 && m_StatsShown == 1)
        {
            ++m_StatsShown;
            m_StatsLabel.text =
                $"Profit: {m_DataPasser.money}\nOrders Completed: {m_DataPasser.ordersCompleted}";
        }
        if (m_Time >= timeBetweenStats * 3 && m_StatsShown == 2)
        {
            ++m_StatsShown;
            m_StatsLabel.text =
                $"Profit: {m_DataPasser.money}\nOrders Completed: {m_DataPasser.ordersCompleted}\nNew Quota: {m_DataPasser.quota}";
        }
    }
}
