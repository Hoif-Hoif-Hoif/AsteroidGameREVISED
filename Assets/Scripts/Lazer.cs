using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private float lifeTime = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
