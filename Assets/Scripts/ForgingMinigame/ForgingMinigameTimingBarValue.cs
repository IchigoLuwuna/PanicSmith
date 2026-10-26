using UnityEngine;

public class ForgingMinigameTimingBarValue : MonoBehaviour
{
    [SerializeField]
    private int m_Value = 0;
    public int value
    {
        get { return m_Value; }
    }
}
