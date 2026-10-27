using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool m_HasBlade;
    private int m_BladeQuality;

    private bool m_HasHandle;
    private int m_HandleColorID;

    private bool m_HasSword;
    private int m_SwordBladeQuality;
    private int m_SwordHandleColorID;

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
}
