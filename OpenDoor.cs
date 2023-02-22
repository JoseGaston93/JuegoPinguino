using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Text text;
    public string levelName;
    private bool inDoor = false;




    private void OnTriggerEnter2D(Collider2D collision)//TOCAMOS PUERTA
    {
        if (collision.gameObject.CompareTag("Player"))//SI EL QUE TOCA ES PLAYER
        {
            text.gameObject.SetActive(true);//SALE TEXTO PARA ENTRAR
            inDoor= true;//PERMITE ENTRAR

        }
    }

    private void OnTriggerExit2D(Collider2D collision)//DEJAMOS DE TOCAR PUERTA
    {
        text.gameObject.SetActive(false);//QUITA TEXTO PARA ENTRAR
        inDoor = false;//NO PERMITE ENTRAR
    }

    private void Update()
    {

        if (inDoor && Input.GetKey("e"))
        {
            SceneManager.LoadScene(levelName);


        }

    }




}
