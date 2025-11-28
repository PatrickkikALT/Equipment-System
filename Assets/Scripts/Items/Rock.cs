using UnityEngine;
using UnityEngine.Serialization;

public class Rock : MonoBehaviour, IUsableItem {
  public float throwForce = 10f;
  private Rigidbody _rb;
  private EquipmentManager _manager;
  private Collider _col;
  private void Start() {
    _rb = GetComponent<Rigidbody>();
    _col = GetComponent<Collider>();
    _manager = GameManager.Instance.player.GetComponent<EquipmentManager>();
  }

  public void UsePrimary() {
    transform.parent = null;
    _col.enabled = true;
    _rb.isKinematic = false;
    _rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    _manager.UnequipFromInstance(gameObject, true);
  }
  
  public void UsePrimaryStopped() {}
  public void UseSecondary() {}
  public void UseSecondaryStopped() {}
  
}