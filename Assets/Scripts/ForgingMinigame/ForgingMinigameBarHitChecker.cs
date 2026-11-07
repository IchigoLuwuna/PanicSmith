using UnityEngine;

public class ForgingMinigameBarHitChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject m_TimingBar;

    [SerializeField]
    private GameObject m_Bar;

    public int Check()
    {
        RectTransform barRectTrans = m_Bar.GetComponent<RectTransform>();
        Rect barRect = new Rect(
            barRectTrans.localPosition.x + barRectTrans.rect.x,
            barRectTrans.localPosition.y + barRectTrans.rect.y,
            barRectTrans.rect.width,
            barRectTrans.rect.height
        );

        RectTransform[] timingBarRectTranses = m_TimingBar.GetComponentsInChildren<RectTransform>();

        GameObject barHit = null;

        foreach (RectTransform timingBarRectTrans in timingBarRectTranses)
        {
            Rect timingRect = new Rect(
                timingBarRectTrans.rect.x,
                timingBarRectTrans.rect.y,
                timingBarRectTrans.rect.width,
                timingBarRectTrans.rect.height
            );

            if (barRect.Overlaps(timingRect))
            {
                barHit = timingBarRectTrans.gameObject;
            }
        }

        // Miss
        if (barHit == null)
        {
            return 0;
        }

        int barHitValue = barHit.gameObject.GetComponent<ForgingMinigameTimingBarValue>().value;
        return barHitValue;
    }
}
