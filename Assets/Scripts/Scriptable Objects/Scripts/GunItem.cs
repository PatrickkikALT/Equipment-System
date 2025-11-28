using UnityEngine;

[CreateAssetMenu(menuName = "Items/Gun")]
public class GunItem : EquipmentItem {
  public int maxAmmo = 30;
  public float fireRate = 0.1f;
}
