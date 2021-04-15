using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){


            
            BallControl.instance.DesativaTudoAoVencer();
            GAMEMANAGER.instance.win=true;
             int temp=QueFaseEstou.instance.fase+1;
             temp++;
             PlayerPrefs.SetInt("Level"+temp,1);
            
        }
    }
}
