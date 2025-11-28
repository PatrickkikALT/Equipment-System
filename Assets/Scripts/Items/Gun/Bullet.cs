using System;
using UnityEngine;

public class Bullet : MonoBehaviour {
  public float speed;

  public void Start() {
    Invoke(nameof(Disable), 10f);
  }

  private void Disable() {
    PoolManager.Enqueue(gameObject);
    gameObject.SetActive(false);
  }

  public void FixedUpdate() {
    transform.Translate(transform.forward * (Time.deltaTime * speed), Space.World);
  }
}
