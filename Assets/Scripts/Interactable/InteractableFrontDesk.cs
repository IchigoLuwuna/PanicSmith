using UnityEngine;

public class InteractableFrontDesk : MonoBehaviour, IInteractable
{
    private Inventory m_Inventory;
    private OrderQueue m_OrderQueue;

    void Start()
    {
        m_Inventory = FindFirstObjectByType<Inventory>();
        m_OrderQueue = FindFirstObjectByType<OrderQueue>();
    }

    public void Interact()
    {
        if (!m_Inventory.hasSword)
        {
            return;
        }

        int quality = m_Inventory.swordBladeQuality;

        int money = (int)
            Mathf.Round(
                quality * m_OrderQueue.CompleteOrderAndGetBonusMult(m_Inventory.swordHandleColorID)
            );

        m_Inventory.RemoveSword();
        m_Inventory.AddMoney(money);
    }
}
