using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class EquipmentItem : ScriptableObject {
  public string itemName;
  public GameObject prefab;
  public bool isUsable;
  public ItemType itemType;
}
