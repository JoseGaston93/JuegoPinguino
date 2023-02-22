using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.CompareTag("Player"))//SI EL PLAYER TOCA LA FRUTA

        {
           GetComponent<SpriteRenderer>().enabled = false;//DESACTIVA EL RENDER
            gameObject.transform.GetChild(0).gameObject.SetActive(true);//ACTIVA EL HIJO EN LA POSICION (0), EN ESTE CASO ANIMACION DE COGER FRUTA
            Destroy(gameObject,0.5f);//DESTRUYE LA FRUTA UNA VEZ LA TOCAS
        }
    }
}
