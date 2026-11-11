using System.Collections.Generic;
using UnityEngine;

public class OrderQueue : MonoBehaviour
{
    [SerializeField]
    private DataPasser m_DataPasser;

    public class Order
    {
        public enum OrderType
        {
            slow,
            normal,
            fast,
            rush,
        }

        public int expectedColor;
        public OrderType orderType;
        public float expectedDue;
        public float activeTime;
    }

    private List<Order> m_Orders;
    public List<Order> orders
    {
        get { return m_Orders; }
    }

    private float m_TimeUntilNextOrder = 3f;

    [SerializeField]
    private bool m_AllowNewOrders = true;
    public bool allowNewOrders
    {
        set { m_AllowNewOrders = value; }
    }

    void Start()
    {
        m_Orders = new List<Order>();
    }

    void FixedUpdate()
    {
        const float minTimeUntilNextOrder = 5f;
        const float maxTimeUntilNextOrder = 10f;
        m_TimeUntilNextOrder -= Time.deltaTime;

        for (int idx = 0; idx < m_Orders.Count; ++idx)
        {
            m_Orders[idx].activeTime += Time.deltaTime;
        }

        if (m_TimeUntilNextOrder <= 0.001f && m_AllowNewOrders)
        {
            m_TimeUntilNextOrder = Random.Range(minTimeUntilNextOrder, maxTimeUntilNextOrder);

            m_Orders.Add(MakeNewOrder());
        }
    }

    public void AddOrder(int color, Order.OrderType type)
    {
        float expectedDue = GetExpectedDueFromType(type);

        Order newOrder = new Order()
        {
            expectedColor = color,
            orderType = type,
            expectedDue = expectedDue,
        };

        m_Orders.Add(newOrder);
    }

    public float CompleteOrderAndGetBonusMult(int colorID)
    {
        int idx = m_Orders.FindIndex(item => item.expectedColor == colorID);

        // Wrong order
        if (idx == -1)
        {
            // No money for you
            return 0f;
        }

        Order completedOrder = m_Orders[idx];
        m_Orders.RemoveAt(idx);

        // Too late
        if (completedOrder.activeTime >= 2f * completedOrder.expectedDue)
        {
            return 0f;
        }

        if (m_DataPasser != null)
        {
            ++m_DataPasser.ordersCompleted;
        }

        float multiplier = 1f;

        multiplier *= CalculateTimeBonus(completedOrder.activeTime, completedOrder.expectedDue);

        Debug.Log($"{multiplier}");

        const float redBonus = 1.5f;
        const float blueBonus = 1.2f;
        const float greenBonus = 0.8f;

        switch (completedOrder.expectedColor)
        {
            case 0:
            {
                multiplier *= redBonus;
                break;
            }
            case 1:
            {
                multiplier *= greenBonus;
                break;
            }
            case 2:
            {
                multiplier *= blueBonus;
                break;
            }
            default:
            {
                break;
            }
        }

        Debug.Log(
            $"Handed in order after {completedOrder.activeTime} seconds with a multiplier of {multiplier}"
        );

        return multiplier;
    }

    private float CalculateTimeBonus(float activeTime, float expectedTime)
    {
        float multCap = (40f - expectedTime) / 30f + 1f;

        return Mathf.Clamp(expectedTime / activeTime, 0f, multCap);
    }

    private Order MakeNewOrder()
    {
        // the int version is max exclusive for some reason
        int expectedColor = Random.Range(0, 3);
        var orderTypeValues = Order.OrderType.GetValues(typeof(Order.OrderType));
        Order.OrderType orderType = (Order.OrderType)
            orderTypeValues.GetValue(Random.Range(0, orderTypeValues.Length));
        float expectedDue = GetExpectedDueFromType(orderType);

        Order newOrder = new Order()
        {
            expectedColor = expectedColor,
            orderType = orderType,
            expectedDue = expectedDue,
        };

        return newOrder;
    }

    private float GetExpectedDueFromType(Order.OrderType orderType)
    {
        const float slowBase = 40f;
        const float normalBase = 30f;
        const float fastBase = 20f;
        const float rushBase = 10f;

        switch (orderType)
        {
            case Order.OrderType.slow:
            {
                return slowBase;
            }
            case Order.OrderType.normal:
            {
                return normalBase;
            }
            case Order.OrderType.fast:
            {
                return fastBase;
            }
            case Order.OrderType.rush:
            {
                return rushBase;
            }
            default:
            {
                return 0f;
            }
        }
    }
}
