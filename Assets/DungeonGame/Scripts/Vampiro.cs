using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampiro : Enemy
{
    private float moveRate = 2.1f;
    private float moveTimer;
    private float shotRate = 2f;
    private float shotTimer;

    [SerializeField] private float minX, maxX, minY, maxY;
    public GameObject projectile;

    protected override void Move()
    {
        //base.Move();
        RandomMove();
    }

    private void RandomMove()
    {
        moveTimer += Time.deltaTime;

        if(moveTimer > moveRate)
        {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            moveTimer = 0;
        }
    }


    protected override void Attack()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > shotRate)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotTimer = 0f;
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
