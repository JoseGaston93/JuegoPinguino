using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;


    private void OnTriggerEnter2D(Collider2D collision)//SI EL CHECKGROUND TOCA ALGO

    {
        if (collision.CompareTag("Ground"))
        {

            isGrounded = true;//TOCAMOS SUELO 

        }


    }
    private void OnTriggerExit2D(Collider2D collision)//SI EL CHECKGROUND NO TOCA NADA
    {

        if (collision.CompareTag("Ground"))//SI DEJAMOS DE TOCAR SUELO
        {

            isGrounded = false;//NO TOCAMOS SUELO

        }
    }
}
