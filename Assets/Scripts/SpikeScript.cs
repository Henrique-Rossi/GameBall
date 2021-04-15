using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpikeScript : MonoBehaviour
{
  

    private void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.CompareTag("Player")){
           //SceneManager.LoadScene("Fase3");
         // Destroy(other.gameObject);
         
            
       }
    }
    
}
