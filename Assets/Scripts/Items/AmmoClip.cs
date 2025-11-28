using UnityEngine;

public class AmmoClip : MonoBehaviour, IUsableItem {
  public int bullets;

  public void Initialize(AmmoClipItem item) {
    bullets = item.ammoCount;
  }

  public void UsePrimary() {
  }
  public void UsePrimaryStopped() { }
  public void UseSecondary() {
  }
  public void UseSecondaryStopped() { }
}