using UnityEngine;

public class Flashlight : MonoBehaviour, IUsableItem
{
    public Light lightComponent;
    public void UsePrimary() {
        lightComponent.enabled = !lightComponent.enabled;
    }
    public void UsePrimaryStopped() {}
    public void UseSecondary() { }
    public void UseSecondaryStopped() { }
}
