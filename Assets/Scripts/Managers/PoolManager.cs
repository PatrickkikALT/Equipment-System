using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


public static class PoolManager {
  private static Queue<GameObject> _bulletPool = new();

  private const int PoolSize = 100;

  public static void Enqueue(GameObject bullet) {
    if (_bulletPool.Count < PoolSize) {
      bullet.SetActive(false);
      _bulletPool.Enqueue(bullet);
    }
    else {
      Object.Destroy(bullet);
    }
  }

  public static bool TryDequeue(out GameObject bullet) {
    
    if (_bulletPool == null || _bulletPool.Count == 0) {
      bullet = null;
      return false;
    }

    var obj = _bulletPool.Dequeue();

    if (!obj) {
      bullet = null;
      return false;
    }

    obj.SetActive(true);
    bullet = obj;
    return true;
  }
}