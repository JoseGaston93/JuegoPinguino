using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;

    public float startWaitTime;

    private float waitedTime;


    void Start()
    {
        effector= GetComponent<PlatformEffector2D>();//NOMBRAMOS EL COMPONENTE DE LA PLATAFORMA


        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            waitedTime = startWaitTime;


        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))//SI PULSA ABAJO O "s"
        {
            if (waitedTime <= 0)//ESPERA UN TIEMPO PARA BAJARNOS PARA MEJOR SENSACION UN RATO PULSADO EL ABAJO PARA BAJAR

            {
                effector.rotationalOffset = 180f;//CAMBIA EL AREA DE USAR LA PLATFORMA
                waitedTime = startWaitTime;//ESPERA UN TIEMPO PARA BAJARNOS PARA MEJOR SENSACION


            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }

            if (Input.GetKey("space"))
            {
                effector.rotationalOffset = 0;


            }




    }
}
