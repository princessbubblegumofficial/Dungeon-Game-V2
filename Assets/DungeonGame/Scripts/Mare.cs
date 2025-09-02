using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mare : Enemy
{
    public Transform waypoint01, waypoint02;
    private Transform wayPointTarget;

    void Awake()
    {
        wayPointTarget = waypoint02;
    }
    protected override void Introduction()
    {
        base.Introduction();
        Debug.Log("I am a Mare, a type of enemy that haunts dreams.");
    }

    protected override void Move()
    {
        base.Move();

        if (Vector2.Distance(transform.position, target.position) > distance)
        {
            if (Vector2.Distance(transform.position, waypoint01.position) < 0.1f)
            {
                wayPointTarget = waypoint02;
                spriteRenderer.flipX = false;

            }
            if (Vector2.Distance(transform.position, waypoint02.position) < 0.1f)
            {
                wayPointTarget = waypoint01;
                spriteRenderer.flipX = true;

            }
            transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);
        }

    }

    protected override void TurnDirection()
    {
        if (Vector2.Distance(transform.position, target.position) < distance)
        { 
            base.TurnDirection();
        }
        
    }
}
