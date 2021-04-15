using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public Text txtFinal;
    public Animator animator;

     public static Finish instance;
      private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }
    public void AtivaAnim(){
         animator.SetBool("-1passo", true);
    }
/*
    void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.CompareTag("Player")){
            //txtFinal.text="Goal";
            //animator.SetTrigger("AtivaAnimGol");
            animator.SetBool("AtivaAnimGol", true);
             
          
        }
    }*/
    /*void OnTriggerExit2D(Collider2D other) {
        
        animator.SetBool("AtivaAnimGol", false);
    }*/
    
}
