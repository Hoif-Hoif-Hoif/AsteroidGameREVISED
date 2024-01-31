using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public Entity entity;
    private int hitPoints;

    public Rigidbody2D body;
    public Cannon cannon;

    Vector2 direction;
    Vector2 mousePosition;

    void Start()
    {
        hitPoints = entity.hitPoints;
    }

    public void ReceiveDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints < 0)
        {
            Explode();
            hitPoints = 0;
        }
    }

    private void Explode()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            cannon.Shoot();
        }

        direction = new Vector2(directionX, directionY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(direction.x * entity.speed, direction.y * entity.speed);

        Vector2 shootDirection = mousePosition - body.position;
        float shootAngle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg - 90f;
        body.rotation = shootAngle;
    }
}
