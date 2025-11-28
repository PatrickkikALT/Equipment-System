using UnityEngine;

public class PickupItem : MonoBehaviour {
  public EquipmentItem itemData;

  public void OnPickedUp(out GameObject worldObject) {
    worldObject = gameObject;
    gameObject.SetActive(false);
  }
}