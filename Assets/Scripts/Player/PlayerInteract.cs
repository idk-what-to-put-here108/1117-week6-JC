using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float interactRange = 1.5f; // how close I need to be to interact
    [SerializeField] private LayerMask interactableLayer; //insuring that I can interact with only interactable layer objects

    //
    public void OnInteract(InputAction.CallbackContext context)
    {
        //fire once when pressed
        if (context.started)
        {
            //preform interaction
            PreformInteraction();
        }
    }

    private void PreformInteraction()
    {
        //find everything around fox on interactable layer
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRange, interactableLayer);

        //check if hit anything
        if(hit != null)
        {
            //hit something in interactable layer
            if(hit.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact();
                Debug.Log($"Interacted with {hit.name}");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
