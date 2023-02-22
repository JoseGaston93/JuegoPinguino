using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//SI EL CHECKPOINT TOCA A LA COSA CON TAG PLAYER
        {
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x,transform.position.y);//CAMBIA LAS DOS COORDENADAS DEL METODO REACHEDCHEKPOINT, OSEA, LAS GUARDA.

            GetComponent<Animator>().enabled = true;

        }
    }




}
