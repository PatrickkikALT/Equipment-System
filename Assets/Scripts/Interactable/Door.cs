using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Door : MonoBehaviour, IInteractable {
  public Quaternion open, closed;
  private bool _isOpen;
  private Coroutine _currentRoutine;
  private Transform _hinge;

  private void Start() {
    _hinge = transform.parent;
  }

  public void Interact() {
    _isOpen = !_isOpen;
    if (_currentRoutine != null) {
      StopCoroutine(_currentRoutine);
    }
    _currentRoutine = StartCoroutine(OpenDoor());
  }

  public IEnumerator OpenDoor() {
    print("Started coroutine with bool " + _isOpen);
    var target = _isOpen ? open : closed;
    while (Quaternion.Angle(_hinge.rotation, target) > 1f) {
      _hinge.rotation = Quaternion.Slerp(_hinge.rotation, target, Time.deltaTime);
      yield return null;
    }
    _hinge.rotation = target;
  }

}