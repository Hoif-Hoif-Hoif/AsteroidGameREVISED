using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject prefabLazer;
    public Transform muzzle;
    public float projectileSpeed = 7f;

    public void Shoot()
    {
        GameObject instanceLaser = Instantiate(prefabLazer, muzzle.position, muzzle.rotation);
        instanceLaser.GetComponent<Rigidbody2D>().AddForce(muzzle.up * projectileSpeed, ForceMode2D.Impulse);
    }
}
