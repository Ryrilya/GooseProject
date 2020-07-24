using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("References")]
    public Transform interactionTransform;          // The transform position from where we interact with the object
    public Quest quest;                             // The quest that the Interactable has
    [Header("Settings")]
    public float radius = 3f;    // How close do we need to be interactable?

    private bool _hasInteracted = false;            // Have we already interacted with the object?
    private bool _isFocused;                        // Is this interactable currently being focused?

    private void Start()
    {
        interactionTransform = transform;
    }

    private void Update()
    {
        // If we are currently being focused and we haven't already interacted with the object
        if (!_hasInteracted && _isFocused)
        {
            // If we are close enough
            float distance = Vector3.Distance(Player.Instance.transform.position, interactionTransform.position);
            if (distance <= radius)
            {
                // Interact with the object
                Interact();
                _hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        QuestManager.Instance.currentActiveInteractable = this;
    }

    // Called when the object is focused by the player
    public void OnFocused()
    {
        _isFocused = true;
        _hasInteracted = false;
    }

    // Called when the object is no longer focused
    public void OnDefocused()
    {
        _isFocused = false;
        _hasInteracted = false;
    }

    // Draw our radius in the editor
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
