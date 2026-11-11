using UnityEngine;

public class DataPasser : MonoBehaviour
{
    private static int m_Money;
    public int money
    {
        get { return m_Money; }
        set { m_Money = value; }
    }

    private static int m_OrdersCompleted;
    public int ordersCompleted
    {
        get { return m_OrdersCompleted; }
        set { m_OrdersCompleted = value; }
    }

    private static int m_Quota;
    public int quota
    {
        get { return m_Quota; }
        set { m_Quota = value; }
    }
}
