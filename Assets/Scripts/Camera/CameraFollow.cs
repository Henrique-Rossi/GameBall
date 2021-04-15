using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform ball;
   public float escala=0f;
   
  void Update() {


        if(GAMEMANAGER.instance.jogoComecou == true ){

            if (ball == null  && GAMEMANAGER.instance.bolaEmCena == true)
            {
                ball = GameObject.Find("ball").GetComponent<Transform>();
            }
            else if(GAMEMANAGER.instance.bolaEmCena == true )
            {         
                transform.position = new Vector3(ball.position.x, ball.position.y+escala, transform.position.z);
            }
        }
        


  }

   

     
}
