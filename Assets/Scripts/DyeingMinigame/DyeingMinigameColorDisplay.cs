using UnityEngine;

public class DyeingMinigameColorDisplay : MonoBehaviour
{
    [SerializeField]
    private int m_ColorID;

    private DyeingMinigame m_DyeingMinigame;
    private RectTransform m_RectTrans;

    void Start()
    {
        m_DyeingMinigame = FindFirstObjectByType<DyeingMinigame>();
        m_RectTrans = gameObject.GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        const float squareSize = 150f;

        float scale = GetScale();

        m_RectTrans.sizeDelta = new Vector2(scale, scale) * squareSize;
    }

    float GetScale()
    {
        switch (m_ColorID)
        {
            case 0:
            {
                return m_DyeingMinigame.redDyeFilled;
            }
            case 1:
            {
                return m_DyeingMinigame.greenDyeFilled;
            }
            case 2:
            {
                return m_DyeingMinigame.blueDyeFilled;
            }
            default:
            {
                return 0f;
            }
        }
    }
}
