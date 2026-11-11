using UnityEngine;

public class OnNextDayScript : MonoBehaviour
{
    [SerializeField]
    private DataPasser m_DataPasser;

    private static int m_QuotaAccumulation;

    void Start()
    {
        ApplyQuotaToMoney();
        AccumulateQuota();
    }

    private void ApplyQuotaToMoney()
    {
        m_DataPasser.money -= m_DataPasser.quota;
    }

    private void AccumulateQuota()
    {
        const int quotaIncrease = 50;

        ++m_QuotaAccumulation;
        m_DataPasser.quota += quotaIncrease * m_QuotaAccumulation;
    }
}
