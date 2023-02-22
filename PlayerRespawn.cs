using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    private float checkPointPositionX, checkPointPositionY;

    public Animator animator;


    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)//PREGUNTA SI LAS POSICIONES DEL PERSONAJE GUARDADAS NO SON 0
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"),PlayerPrefs.GetFloat("checkPointPositionY")));//MUEVE AL PERSONAJE A LAS POSICIONES GUARDADAS
        }
    }

    public void ReachedCheckPoint(float x, float y)//PARA CUANDO USAS CHECKPOINT
    {
        PlayerPrefs.SetFloat("checkPointPositionX",x);//GUARDA LA POSICION NUEVA X
        PlayerPrefs.SetFloat("checkPointPositionY", y);//GUARDA LA POSICION NUEVA Y
    }


    public void PlayerDamaged() //CUANDO NOS HACEN DAÑO
    {
        animator.Play("Hit");//ACTIVA ANIMACION HIT
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//SE CARGA LA ESCENA EN LA QUE ESTAMOS OSEA RESPAWN


        
    
    }
    
}
