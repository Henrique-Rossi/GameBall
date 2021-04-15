using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goalkeeper : MonoBehaviour
{
   public SliderJoint2D slider;
   public JointMotor2D aux;
   public Text txtFinal;
  

    void Start()
    {
        aux = slider.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.limitState == JointLimitState2D.LowerLimit)
        {
            aux.motorSpeed = 3.5f;
            slider.motor = aux;
        }
         if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            aux.motorSpeed = -3.5f;
            slider.motor = aux;
        }
    }
     private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.CompareTag("Player")){
//            txtFinal.text="Defesa";      
            //SceneManager.LoadScene("Fase3");
        }
    }

    

}
