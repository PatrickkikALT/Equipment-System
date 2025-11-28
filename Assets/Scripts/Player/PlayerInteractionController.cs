using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour {
  public float maxDistance = 3f;
  public Camera playerCamera;

  public void Interact(InputAction.CallbackContext ctx) {
    if (ctx.started) {
      TryInteract();
    }
  }

  private void TryInteract() {
    Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

    if (Physics.Raycast(ray, out RaycastHit hit, maxDistance)) {
      if (hit.collider.TryGetComponent(out IInteractable interactable)) {
        interactable.Interact();
      }
    }
  }
}