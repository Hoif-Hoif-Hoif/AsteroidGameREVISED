using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Entity entity;
    private int hitPoints;
    private float lifeTime = 10f;

    private Vector2 target;

    void Start()
    {
        hitPoints = entity.hitPoints;
    }

    public void InitiateAsteroid(Vector2 spaceshipPosition)
    {
        target = spaceshipPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lazer")
        {
            hitPoints -= 1;
            if (hitPoints < 1)
            {
                hitPoints = 0;
                Destroy(this.gameObject);
            }
            
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Spaceship>().ReceiveDamage(entity.damage);
        }
        
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(target - new Vector2(transform.position.x, transform.position.y) * entity.speed);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
