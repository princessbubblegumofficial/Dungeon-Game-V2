using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 2.0f;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb.linearVelocity = new Vector2(moveH, moveV);

        animator.SetFloat("Horizontal", moveH);
        animator.SetFloat("Vertical", moveV);
        animator.SetFloat("Speed", rb.linearVelocity.magnitude);

        transform.localScale = new Vector3(moveH < 0 ? -1 : 1, 1, 1);
    }

}
