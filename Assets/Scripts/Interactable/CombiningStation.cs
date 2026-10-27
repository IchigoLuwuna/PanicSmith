using UnityEngine;

public class CombiningStation : MonoBehaviour, IInteractable
{
    private Inventory m_Inventory;

    void Start()
    {
        m_Inventory = FindFirstObjectByType<Inventory>();
    }

    public void Interact()
    {
        m_Inventory.AddSword();
    }
}
