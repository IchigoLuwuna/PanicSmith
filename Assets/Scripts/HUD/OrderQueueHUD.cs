using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderQueueHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_QueueLabel;

    private OrderQueue m_OrderQueue;

    private int m_PreviousOrderCount;

    void Start()
    {
        m_OrderQueue = FindFirstObjectByType<OrderQueue>();
    }

    void FixedUpdate()
    {
        if (m_PreviousOrderCount == m_OrderQueue.orders.Count)
        {
            return;
        }

        m_PreviousOrderCount = m_OrderQueue.orders.Count;

        Debug.Log("Updated orders display");

        string displayString = "";

        if (m_OrderQueue.orders.Count == 0)
        {
            m_QueueLabel.text = displayString;
            return;
        }

        for (int idx = 0; idx < m_OrderQueue.orders.Count - 1; ++idx)
        {
            displayString += MakeStringFromOrder(m_OrderQueue.orders[idx]);
            displayString += " | ";
        }

        displayString += MakeStringFromOrder(m_OrderQueue.orders[m_OrderQueue.orders.Count - 1]);

        m_QueueLabel.text = displayString;
    }

    string MakeStringFromOrder(OrderQueue.Order order)
    {
        string returnString = "";

        switch (order.expectedColor)
        {
            case 0:
            {
                returnString += "<color=#FF0000>red";
                break;
            }
            case 1:
            {
                returnString += "<color=#00FF00>green";
                break;
            }
            case 2:
            {
                returnString += "<color=#0000FF>blue";
                break;
            }
            default:
            {
                returnString += "NONE";
                break;
            }
        }

        returnString += " - ";

        switch (order.orderType)
        {
            case OrderQueue.Order.OrderType.slow:
            {
                returnString += "slow";
                break;
            }
            case OrderQueue.Order.OrderType.normal:
            {
                returnString += "normal";
                break;
            }
            case OrderQueue.Order.OrderType.fast:
            {
                returnString += "fast";
                break;
            }
            case OrderQueue.Order.OrderType.rush:
            {
                returnString += "rush";
                break;
            }
            default:
            {
                returnString += "NONE";
                break;
            }
        }

        returnString += "<color=#FFFFFF>";

        return returnString;
    }
}
