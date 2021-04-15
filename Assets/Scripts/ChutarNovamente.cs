using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChutarNovamente : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
             BallControl.instance.contatoComFisica=true;
             
        }
    }
     void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
             BallControl.instance.contatoComFisica=false;
             
        }
    }
}
