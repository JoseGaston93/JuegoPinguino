using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;//CREAMOS TRIGGER PARA QUE SALGA EL TEXTO
    public GameObject transition;




    private void Update()
    {
        AllFruitsCollected();
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount==0)//SI DENTRO DE FRUIT MANAGER NO HAY HIJOS, OSEA FRUTAS
        {
            Debug.Log("No quedan frutas. Victoria");//MUESTRA ESO
            levelCleared.gameObject.SetActive(true);//ACTIVA EL LEVEL CLEARED OSEA EL TEXTO
            transition.SetActive(true);//ACTIVA LA TRANSICION DE CAMBIO DE ESCENA
            Invoke("ChangeScene", 1);//invoca el cambio de pantalla pero con 1 segundo de espera
            


        }


    }
    void ChangeScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//CAMBIA A SIGUIENTE ESCENA





    }

}
