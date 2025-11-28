using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
  public GameObject player;

  public static GameManager Instance;

  private void Awake() {
    Instance = this;
  }
}
