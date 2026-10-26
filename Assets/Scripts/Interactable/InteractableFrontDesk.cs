using UnityEngine;

public class InteractableFrontDesk : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Front Desk Interacted");

        FindFirstObjectByType<GameState>().gameObject.GetComponent<GameState>().gameWon = true;
    }
}
