using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour, IUsableItem {
  public int currentAmmo;
  public bool isFullAuto = false;
  public float fireRate = 0.1f;
  [SerializeField] private Transform shootPos;
  public GameObject bulletPrefab;
  private float _lastFireTime = 0f;
  private GameObject _player;

  private bool _canShoot = true;

  private Coroutine _autoFireCoroutine;

  private void Start() {
    _player = GameManager.Instance.player;
  }

  public void Initialize(GunItem item) {
    currentAmmo = 0;
    fireRate = item.fireRate;
  }

  public void Reload(int bullets) {
    currentAmmo = bullets;
  }

  public void UsePrimary() {
    if (!_canShoot) return;
    if (currentAmmo <= 0) return;

    if (isFullAuto) {
      _autoFireCoroutine ??= StartCoroutine(AutoFire());
    }
    else {
      FireOnce();
    }
  }

  public void UsePrimaryStopped() {
    if (_autoFireCoroutine != null) {
      StopCoroutine(_autoFireCoroutine);
      _autoFireCoroutine = null;
    }
  }

  private IEnumerator AutoFire() {
    while (currentAmmo > 0) {
      FireOnce();
      yield return new WaitForSeconds(fireRate);
    }

    _autoFireCoroutine = null;
  }

  private void FireOnce() {
    if (currentAmmo <= 0) return;

    currentAmmo--;
    _lastFireTime = Time.time;

    GameObject bullet;
    if (PoolManager.TryDequeue(out bullet)) {
      bullet.SetActive(true);
      bullet.transform.position = shootPos.position;
      bullet.transform.rotation = _player.transform.rotation;
    }
    else {
      bullet = Instantiate(bulletPrefab, shootPos.position, _player.transform.rotation);
    }

    if (!isFullAuto) {
      _canShoot = false;
      Invoke(nameof(SetCanShoot), fireRate);
    }
  }


  public void SetCanShoot() {
    _canShoot = true;
  }

  public void UseSecondary() {
    isFullAuto = !isFullAuto;
  }

  public void UseSecondaryStopped() { }
}