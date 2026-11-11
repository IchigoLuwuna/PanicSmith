using UnityEngine;

public class CombiningStation : MonoBehaviour, IInteractable
{
    [SerializeField]
    private AudioSource m_HammerSFX;

    private Inventory m_Inventory;

    void Start()
    {
        m_Inventory = FindFirstObjectByType<Inventory>();
    }

    public void Interact()
    {
        if (m_Inventory.hasBlade && m_Inventory.hasHandle)
        {
            m_HammerSFX.Play();
            m_Inventory.AddSword();
        }
    }
}
