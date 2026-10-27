using UnityEngine;

public class InteractableFrontDesk : MonoBehaviour, IInteractable
{
    private Inventory m_Inventory;

    void Start()
    {
        m_Inventory = FindFirstObjectByType<Inventory>();
    }

    public void Interact()
    {
        if (!m_Inventory.hasSword)
        {
            return;
        }

        int quality = m_Inventory.swordBladeQuality;

        m_Inventory.RemoveSword();
        m_Inventory.AddMoney(quality);
    }
}
