using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int m_StartHealth = 1;

    [SerializeField]
    private int m_MaxHealth = 1;

    private int m_CurrentHealth;

    public int health
    {
        get { return m_CurrentHealth; }
    }

    void Start()
    {
        m_CurrentHealth = Mathf.Clamp(m_StartHealth, 0, m_MaxHealth);
    }

    public void ClampHP()
    {
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0, m_MaxHealth);
    }

    public void Damage(int amount)
    {
        m_CurrentHealth -= amount;
        ClampHP();

        // Technically we only need == but you never know :3
        if (m_CurrentHealth <= 0)
        {
            Kill();
        }
    }

    public void Heal(int amount)
    {
        m_CurrentHealth += amount;
        ClampHP();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
