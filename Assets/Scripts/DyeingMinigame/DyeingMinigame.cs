using UnityEngine;

public class DyeingMinigame : MonoBehaviour
{
    private GameState m_GameState;
    private Inventory m_Inventory;

    [SerializeField]
    private float m_RedDyeTime = 1f;
    private float m_RedDyeTimer;
    public float redDyeFilled
    {
        get { return (m_RedDyeTime - m_RedDyeTimer) / m_RedDyeTime; }
    }

    [SerializeField]
    private float m_GreenDyeTime = 1f;
    private float m_GreenDyeTimer;
    public float greenDyeFilled
    {
        get { return (m_GreenDyeTime - m_GreenDyeTimer) / m_GreenDyeTime; }
    }

    [SerializeField]
    private float m_BlueDyeTime = 1f;
    private float m_BlueDyeTimer;
    public float blueDyeFilled
    {
        get { return (m_BlueDyeTime - m_BlueDyeTimer) / m_BlueDyeTime; }
    }

    private float m_LastFrameTime;

    void Start()
    {
        m_GameState = FindFirstObjectByType<GameState>();
        m_Inventory = FindFirstObjectByType<Inventory>();

        m_LastFrameTime = Time.time;
    }

    void FixedUpdate()
    {
        float time = Time.time;
        float timeSinceLastUpdate = time - m_LastFrameTime;
        m_LastFrameTime = time;

        m_RedDyeTimer = Mathf.Clamp(m_RedDyeTimer - timeSinceLastUpdate, 0f, m_RedDyeTime);
        m_GreenDyeTimer = Mathf.Clamp(m_GreenDyeTimer - timeSinceLastUpdate, 0f, m_GreenDyeTime);
        m_BlueDyeTimer = Mathf.Clamp(m_BlueDyeTimer - timeSinceLastUpdate, 0f, m_BlueDyeTime);
    }

    public void PrimaryAction()
    {
        if (m_RedDyeTimer > 0.01f)
        {
            return;
        }

        m_Inventory.AddHandle(0);
        m_RedDyeTimer = m_RedDyeTime;
    }

    public void SecondaryAction()
    {
        if (m_GreenDyeTimer > 0.01f)
        {
            return;
        }

        m_Inventory.AddHandle(1);
        m_GreenDyeTimer = m_GreenDyeTime;
    }

    public void TertiaryAction()
    {
        if (m_BlueDyeTimer > 0.01f)
        {
            return;
        }

        m_Inventory.AddHandle(2);
        m_BlueDyeTimer = m_BlueDyeTime;
    }

    public void ExitAction()
    {
        m_GameState.state = GameState.State.WorkShop;
    }
}
