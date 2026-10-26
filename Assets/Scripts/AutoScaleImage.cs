using UnityEngine;

public class AutoScale : MonoBehaviour
{
    [SerializeField]
    private float m_Scale = 1f;

    [SerializeField]
    private bool m_UseCustomRatio = false;

    [SerializeField]
    private float m_ScaleRatio = 16f / 9f;

    private RectTransform m_RectTransform;

    void Start()
    {
        m_RectTransform = gameObject.GetComponent<RectTransform>();

        m_RectTransform.sizeDelta = NewSize();
    }

    private Vector2 NewSize()
    {
        if (m_UseCustomRatio)
        {
            return new Vector2(Screen.height * m_ScaleRatio, Screen.height) * m_Scale;
        }
        else
        {
            return new Vector2(Screen.width, Screen.height) * m_Scale;
        }
    }
}
