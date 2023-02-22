using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)//CUANDO EL OBJETO TOCA CON ALGO
    {
        if (collision.transform.CompareTag("Player"))//SI LO QUE TOCA ES LA COSA CON EL TAG "PLAYER"
        {
            Debug.Log("Player Damage");//LA CONSOLA NOS DICE ESO
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();//Activamos player damaged





        }


    }
}
