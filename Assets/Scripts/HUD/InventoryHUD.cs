using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_InventoryLabel;

    private Inventory m_Inventory;

    void Start()
    {
        m_Inventory = FindFirstObjectByType<Inventory>();
    }

    void FixedUpdate()
    {
        string displayString = "";

        if (m_Inventory.hasBlade)
        {
            displayString += $"Blade: {m_Inventory.bladeQuality}\n";
        }

        if (m_Inventory.hasHandle)
        {
            displayString += $"Handle: {ColorIDToString(m_Inventory.handleColorID)}\n";
        }

        if (m_Inventory.hasSword)
        {
            displayString =
                $"Sword\n{m_Inventory.swordBladeQuality} - {ColorIDToString(m_Inventory.swordHandleColorID)}";
        }

        if (m_InventoryLabel != null)
        {
            m_InventoryLabel.text = displayString;
        }
    }

    private string ColorIDToString(int ID)
    {
        switch (ID)
        {
            case 0:
            {
                return "red";
            }
            case 1:
            {
                return "green";
            }
            case 2:
            {
                return "blue";
            }
            default:
            {
                return "";
            }
        }
    }
}
