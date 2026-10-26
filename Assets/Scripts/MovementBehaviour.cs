using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float m_MovementSpeed = 5f;

    public Vector3 desiredMovementDirection = Vector3.zero;

    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 movement = desiredMovementDirection.normalized;
        movement *= m_MovementSpeed;
        //transform.position += movement;
        m_Rigidbody.linearVelocity = movement;
    }
}
