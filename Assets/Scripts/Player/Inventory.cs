using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private DataPasser m_DataPasser;

    private bool m_HasBlade;
    private int m_BladeQuality;

    private bool m_HasHandle;
    private int m_HandleColorID;

    private bool m_HasSword;
    private int m_SwordBladeQuality;
    private int m_SwordHandleColorID;

    private int m_Money = 5;
    private int m_MoneyDiff;

    public bool hasBlade
    {
        get { return m_HasBlade; }
    }
    public int bladeQuality
    {
        get { return m_BladeQuality; }
    }

    public bool hasHandle
    {
        get { return m_HasHandle; }
    }
    public int handleColorID
    {
        get { return m_HandleColorID; }
    }

    public bool hasSword
    {
        get { return m_HasSword; }
    }
    public int swordBladeQuality
    {
        get { return m_SwordBladeQuality; }
    }
    public int swordHandleColorID
    {
        get { return m_SwordHandleColorID; }
    }

    public int money
    {
        get { return m_Money; }
    }

    public int moneyDiff
    {
        get { return m_MoneyDiff; }
    }

    void Start()
    {
        if (m_DataPasser == null)
        {
            return;
        }

        if (m_DataPasser.money != 0)
        {
            m_Money = m_DataPasser.money;
        }
    }

    public void AddSword()
    {
        if (!m_HasBlade || !m_HasHandle)
        {
            return;
        }

        m_SwordBladeQuality = m_BladeQuality;
        m_SwordHandleColorID = m_HandleColorID;

        m_HasSword = true;
        m_HasBlade = false;
        m_HasHandle = false;
    }

    public void AddBlade(int quality)
    {
        m_HasBlade = true;
        m_BladeQuality = quality;
    }

    public void AddHandle(int colorID)
    {
        m_HasHandle = true;
        m_HandleColorID = colorID;
    }

    public void RemoveBlade()
    {
        m_HasBlade = false;
    }

    public void RemoveHandle()
    {
        m_HasHandle = false;
    }

    public void RemoveSword()
    {
        m_HasSword = false;
    }

    public void AddMoney(int amount)
    {
        m_Money += amount;

        m_MoneyDiff = amount;

        if (m_DataPasser != null)
        {
            m_DataPasser.money = m_Money;
        }
    }

    public void RemoveMoney(int amount)
    {
        m_Money -= amount;

        if (m_DataPasser != null)
        {
            m_DataPasser.money = m_Money;
        }
    }
}
