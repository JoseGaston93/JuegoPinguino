using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Declaramos Variables, nos las muestra en Unity, se pueden modificar desde allí.
    public float runSpeed = 2;

    public float jumpSpeed = 3;

    public float doubleJumpSpeed = 2.5f;

    private bool canDoubleJump;


    Rigidbody2D rb2d;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;




    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey("space"))         //SI PULSA ESPACIO
        {
            if (CheckGround.isGrounded)//SI ESTA TOCANDO SUELO
            {
                canDoubleJump= true;//PUEDE SALTO DOBLE
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);//LA VELOCIDAD DE Y CAMBIA A LA VARIABLE PORQUE SALTAMOS

            }
            else
            {
                if (Input.GetKeyDown("space"))//SI PULSAS ESPACIO
                {
                    if (canDoubleJump)//Y ADEMAS PUEDES DOBLE SALTAR
                    {
                        animator.SetBool("DoubleJump", true);//ACTIVA ANIMACION
                        rb2d.velocity = new Vector2(rb2d.velocity.x, doubleJumpSpeed);//LA VELOCIDAD DE Y CAMBIA A LA VARIABLE PORQUE SALTAMOS
                        canDoubleJump= false;//YA NO PODEMOS SALTAR MAS
                    }
                }
            }

        }



        if (CheckGround.isGrounded == false)//SI NO ESTAMOS TOCANDO SUELO
        {
            animator.SetBool("Jump", true);//ESTAMOS EN EL AIRE ASI QUE "JUMP" TRUE "ES UNA VARIABLE DE LA ANIMACION"
            animator.SetBool("Run", false);//ESTAMOS EN EL AIRE ASI QUE "RUN" FALSE "ES UNA VARIABLE DE LA ANIMACION"
        }
        if (CheckGround.isGrounded == true)//SI ESTAMOS TOCANDO SUELO
        {
            animator.SetBool("DoubleJump", false);//ESTAMOS EN SUELO ASI QUE "DOUBLEJUMP" FALSE
            animator.SetBool("Falling", false);//ESTAMOS EN SUELO ASI QUE "FALLING" FALSE
            animator.SetBool("Jump", false);//ESTAMOS EN SUELO ASI QUE "JUMP" FALSE
        }

        if (rb2d.velocity.y<0)
        {
            animator.SetBool("Falling", true);
        }
        if (rb2d.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }


    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {      //SI PULSA "D" O "DERECHA"
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);//MOVIMIENTO VARIABLE EN EJE HORIZONTAL(X) Y NO TOCAMOS VERTICAL(Y)
            spriteRenderer.flipX = false;                          //LLAMAMOS A SPRITE RENDER PARA QUE NO HAGA FLIP, SE QUEDA IGUAL
            animator.SetBool("Run", true);                         //DECIMOS A LA ANIMACION QUE PONGA "RUN" EN TRUE

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {      //SI PULSA "A" O "IZQUIERDA"
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);//MOVIMIENTO IGUAK QUE OTRO PERO A LA IZQUIERDA
            spriteRenderer.flipX = true;                            //DECIMOS QUE HAGA FLIP EL RENDER PARA QUE MIRE A IZQUIERDA
            animator.SetBool("Run", true);                          //DECIMOS A ANIMACION QUE PONGA "RUN" EN TRUE

        }
        else
        {       //SI NO PULSA NADA
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);//SI NO NOS MOVEMOS DEJA LAS VELOCIDADES IGUAL
            animator.SetBool("Run", false);                 //NO APRETA NADA ASI QUE NO ESTA "RUN"

        }
 
        if (betterJump)//PARA QUE SALTE MAS O MENOS SEGUN LO QUE APRETEMOS EL ESPACIO
        {
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;

            }
            if (rb2d.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;

            }
        }


    }
}
