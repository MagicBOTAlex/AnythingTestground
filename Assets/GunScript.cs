using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public Text ReloadToolTip;

    public GameObject BulletPrefab;
    public Transform BulletSpawner;
    public float BulletSpeed = 100f;

    public float ShootingIntervalDelay = 1f;

    public int BulletsLeft = 17;
    private int magSize;

    // Start is called before the first frame update
    void Start()
    {
        magSize = BulletsLeft;
        StartCoroutine(StartShootingLoop());
    }

    IEnumerator StartShootingLoop()
    {
        while (true)
        {
            ReloadToolTip.enabled = false;
            while (BulletsLeft > 0)
            {
                yield return new WaitUntil(() => Input.GetKey(KeyCode.Mouse0));
                BulletsLeft--;
                var bullet = Instantiate(BulletPrefab, BulletSpawner.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = BulletSpawner.forward.normalized * BulletSpeed;
                yield return new WaitForSecondsRealtime(ShootingIntervalDelay);
            }
            ReloadToolTip.enabled = true;
            yield return new WaitUntil(() => Input.GetKey(KeyCode.R));
            BulletsLeft = magSize;
        }
    }
}
