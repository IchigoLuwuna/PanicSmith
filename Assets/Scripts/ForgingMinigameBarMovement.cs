using UnityEngine;

public class ForgingMinigameBarMovement : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 1f;

    private float m_Time;

    bool m_Stop = false;

    private Transform m_Transform;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (m_Stop)
        {
            return;
        }

        m_Time += Time.deltaTime;

        float x = -Mathf.Cos(m_Time * m_Speed) * 550f;

        Vector3 localPos = new Vector3(x, 0f, 0f);
        m_Transform.position = m_Transform.parent.position + localPos;
    }

    private void OnEnable()
    {
        m_Time = Random.Range(0f, Mathf.PI * 2f);
        m_Stop = false;
    }

    public void Stop()
    {
        m_Stop = true;
    }
}
