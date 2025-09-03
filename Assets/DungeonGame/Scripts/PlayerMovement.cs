using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    public Animator animator;

    private void Start()
    {
        //Ao iniciar o jogo, acessa o Rigidbody2D do personagem
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
              


        // Responsável por ativar as animações
        animator.SetFloat("Horizontal", moveH);
        animator.SetFloat("Vertical", moveV);
        animator.SetFloat("Speed", rb.linearVelocity.magnitude);

        // Vira o personagem baseado no movimento
        transform.localScale = new Vector3(moveH < 0 ? -1 : 1, 1, 1);
    }


}
