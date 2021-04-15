using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWall : MonoBehaviour
{
 
    void OnCollisionEnter2D(Collision2D other) {
     if (other.gameObject.CompareTag("Player"))
        {
           AudioManager.instance.SonsFxToca(2);
        }
    }

    
}
