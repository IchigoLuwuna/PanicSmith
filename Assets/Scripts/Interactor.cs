using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private float m_InteractRange = 1f;

    private Transform m_InteractorTransform;

    private GameObject m_InteractableObjectGroup;

    void Start()
    {
        m_InteractorTransform = gameObject.GetComponent<Transform>();
        m_InteractableObjectGroup = GameObject.Find("Interactable");
    }

    public void Interact()
    {
        if (m_InteractableObjectGroup == null)
        {
            Debug.Log("No interactable group found");
            return;
        }

        Transform[] interactables = m_InteractableObjectGroup.GetComponentsInChildren<Transform>();

        IInteractable closestInteractable = null;
        float closestInteractableSquareDistance = m_InteractRange * m_InteractRange;

        foreach (Transform interactableTransform in interactables)
        {
            float deltaX = interactableTransform.position.x - m_InteractorTransform.position.x;
            float deltaZ = interactableTransform.position.z - m_InteractorTransform.position.z;

            float squareDist = deltaX * deltaX + deltaZ * deltaZ;

            if (squareDist < closestInteractableSquareDistance)
            {
                if (
                    interactableTransform.gameObject.TryGetComponent(
                        out IInteractable interactObject
                    )
                )
                {
                    closestInteractable = interactObject;
                    closestInteractableSquareDistance = squareDist;
                }
            }
        }

        if (closestInteractable == null)
        {
            Debug.Log("No interactable found");
            return;
        }

        closestInteractable.Interact();

        /*
          // Temporary solution; replace later with sphere or cylinder instead of 4 raycasts
          Ray rUp = new Ray(m_InteractorTransform.position, new Vector3(0f, 0f, 1f));
          Ray rDown = new Ray(m_InteractorTransform.position, new Vector3(0f, 0f, -1f));
          Ray rLeft = new Ray(m_InteractorTransform.position, new Vector3(-1f, 0f, 0f));
          Ray rRight = new Ray(m_InteractorTransform.position, new Vector3(1f, 0f, 0f));
  
          if (Physics.Raycast(rUp, out RaycastHit hitInfoUp, m_InteractRange))
          {
              if (hitInfoUp.collider.gameObject.TryGetComponent(out IInteractable interactObject))
              {
                  interactObject.Interact();
              }
              return;
          }
          if (Physics.Raycast(rDown, out RaycastHit hitInfoDown, m_InteractRange))
          {
              if (hitInfoDown.collider.gameObject.TryGetComponent(out IInteractable interactObject))
              {
                  interactObject.Interact();
              }
              return;
          }
          if (Physics.Raycast(rLeft, out RaycastHit hitInfoLeft, m_InteractRange))
          {
              if (hitInfoLeft.collider.gameObject.TryGetComponent(out IInteractable interactObject))
              {
                  interactObject.Interact();
              }
              return;
          }
          if (Physics.Raycast(rRight, out RaycastHit hitInfoRight, m_InteractRange))
          {
              if (hitInfoRight.collider.gameObject.TryGetComponent(out IInteractable interactObject))
              {
                  interactObject.Interact();
              }
              return;
          }
          */
    }
}
