using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCon : MonoBehaviour
{
[SerializeField]
  Transform bulletSpawn = null;
  [SerializeField, Min(1)]
  int damage = 1;
  [SerializeField, Min(1)]
  int maxAmmo = 5;
  [SerializeField, Min(1)]
  float maxRange = 30;
  [SerializeField]
  LayerMask hitLayers = 0;
  [SerializeField, Min(0.01f)]
  float fireInterval = 0.1f;
  bool fireTimerIsActive = false;
  RaycastHit hit;
  WaitForSeconds fireIntervalWait;
  public GameObject paintDecalPrefab;
  public float decalSize = 0.3f;

  void Start()
  {
    fireIntervalWait = new WaitForSeconds(fireInterval);
  }
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Fire();
    }
  }
  // 弾の発射処理
  void Fire()
  {
    if (/*fireTimerIsActive && */0 < this.maxAmmo)
    {
      maxAmmo = this.maxAmmo - 1;
      Debug.Log(maxAmmo);
    }

    if(Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, maxRange, hitLayers, QueryTriggerInteraction.Ignore))
    {
      BulletHit();
    }
    StartCoroutine(nameof(FireTimer));
    //CreatePaintDecal(hit);
  }
  // 弾がヒットしたときの処理
  void BulletHit()
  {
    GameObject paintDecal = Instantiate(paintDecalPrefab, hit.point, (Quaternion.LookRotation(hit.normal)));
    Debug.Log("弾が「" + hit.collider.gameObject.name + "」にヒットしました。");
  }
  // 弾を発射する間隔を制御するタイマー
  IEnumerator FireTimer()
  {
    fireTimerIsActive = true;
    yield return fireIntervalWait;
    fireTimerIsActive = false;
  }
}
