using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    protected MovementBehaviour m_MovementBehaviour;

    protected virtual void Awake()
    {
        m_MovementBehaviour = GetComponent<MovementBehaviour>();
    }
}
