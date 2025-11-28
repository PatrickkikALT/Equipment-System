using UnityEngine;

public class EquipmentManager : MonoBehaviour {
  [Header("Socket Transforms")] 
  public Transform leftHandSocket;
  public Transform rightHandSocket;
  public Transform headSocket;

  private GameObject _leftHandItemInstance;
  private GameObject _rightHandItemInstance;
  private GameObject _headItemInstance;

  public GameObject leftHandWorldItem;
  public GameObject rightHandWorldItem;
  public GameObject headWorldItem;

  public GameObject GetItemInstance(EquipmentSlot slot) {
    return slot switch {
      EquipmentSlot.LeftHand => _leftHandItemInstance,
      EquipmentSlot.RightHand => _rightHandItemInstance,
      EquipmentSlot.Head => _headItemInstance,
      _ => null
    };
  }

  public void Equip(EquipmentItem item, EquipmentSlot slot) {
    Unequip(slot);

    Transform socket = slot switch {
      EquipmentSlot.LeftHand => leftHandSocket,
      EquipmentSlot.RightHand => rightHandSocket,
      EquipmentSlot.Head => headSocket,
      _ => null
    };

    if (item.prefab && socket) {
      GameObject instance = Instantiate(item.prefab, socket);
      instance.transform.localPosition = Vector3.zero;
      instance.transform.localRotation = Quaternion.identity;

      switch (slot) {
        case EquipmentSlot.LeftHand:
          _leftHandItemInstance = instance;
          break;

        case EquipmentSlot.RightHand:
          _rightHandItemInstance = instance;
          break;

        case EquipmentSlot.Head:
          _headItemInstance = instance;
          break;
      }
    }
  }

  public void Unequip(EquipmentSlot slot, bool thrown = false) {
    GameObject target = GetItemInstance(slot);
    if (target) {
      if (!thrown) {
        Destroy(target);
      }
      switch (slot) {
        case EquipmentSlot.LeftHand:
          _leftHandItemInstance = null;
          if (!thrown) {
            leftHandWorldItem.SetActive(true);
            leftHandWorldItem.transform.position = leftHandSocket.position - transform.up / 2;
            leftHandWorldItem = null;
          }
          break;

        case EquipmentSlot.RightHand:
          _rightHandItemInstance = null;
          if (!thrown) {
            rightHandWorldItem.SetActive(true);
            rightHandWorldItem.transform.position = rightHandSocket.position - transform.up / 2;
            rightHandWorldItem = null;
          }
          break;

        case EquipmentSlot.Head:
          _headItemInstance = null;
          headWorldItem.SetActive(true);
          headWorldItem.transform.position = headSocket.position - transform.up / 2;
          headWorldItem = null;
          break;
      }
    }
  }

  public void UnequipFromInstance(GameObject instance, bool thrown = false) {
    if (_leftHandItemInstance == instance) {
      Unequip(EquipmentSlot.LeftHand, thrown);
    }
    else if (_rightHandItemInstance == instance) {
      Unequip(EquipmentSlot.RightHand, thrown);
    }
    else if (_headItemInstance == instance) {
      Unequip(EquipmentSlot.Head);
    }
  }


  public IUsableItem GetUsableItemInSlot(EquipmentSlot slot) {
    GameObject instance = GetItemInstance(slot);
    return instance ? instance.GetComponent<IUsableItem>() : null;
  }
}