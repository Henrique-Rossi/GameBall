using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpikeDeath : MonoBehaviour
{public Rigidbody2D rb; 
  [SerializeField]
  private float lifeBall = 1f;
  [SerializeField]
  private Color cor;
   [SerializeField]
  private Color corT;
  [SerializeField]
  private Renderer ballRender;
  [SerializeField]
  private bool tocouSpike= false;
  [SerializeField]
  private Renderer TrailRender;
//quando morre,ainda ocasiona de interagir com o cenario rever isso para nao acontecer 


   void Start() {
     cor = ballRender.material.GetColor("_Color");  
     corT = TrailRender.material.GetColor("_Color"); 
      rb = GetComponent < Rigidbody2D > (); 
    }
    private void Update() {
      if(tocouSpike == true){
        DeathBall();
      }
    }

    void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.CompareTag("Spike")){         
         tocouSpike=true;
            
       }
       if (other.gameObject.CompareTag("Desativa"))
       {
           /* desativa a fisica
            rb.isKinematic = true;
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("opa");*/
           
       }
      
    }
    void DeathBall(){
     /* if (lifeBall > 0)
      {
        //aqui é uma funçao apenasde fazer animação dela sumindo,quando some ela tiva a segunda função
          lifeBall-= Time.deltaTime;
          
          ballRender.material.SetColor("_Color",new Color(cor.r,cor.g,cor.b,lifeBall));
          TrailRender.material.SetColor("_Color",new Color(cor.r,cor.g,cor.b,lifeBall));
      }
      if (lifeBall <= 0)
      {   
           GAMEMANAGER.instance.bolaEmCena = false;
           //SceneManager.LoadScene("Fase3");
           DestroyGameObjectsWithTag("Player"); 
           // Destroy(gameObject);
           GAMEMANAGER.instance.numJogadas --;
           
           if (GAMEMANAGER.instance != null && GAMEMANAGER.instance.numJogadas > 0)
           {
               GAMEMANAGER.instance.SpawnBall();               
           }
          
      }*/
      GAMEMANAGER.instance.bolaEmCena = false;
           //SceneManager.LoadScene("Fase3");
           DestroyGameObjectsWithTag("Player"); 
           // Destroy(gameObject);
           GAMEMANAGER.instance.numBallLife--;
           AudioManager.instance.SonsFxToca(5);
           
           if (GAMEMANAGER.instance != null && GAMEMANAGER.instance.numBallLife  > 0)
           {
               GAMEMANAGER.instance.SpawnBall();               
           }
    }
    public static void DestroyGameObjectsWithTag(string tag)
    {
      GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
      foreach (GameObject target in gameObjects) {
          GameObject.Destroy(target);
      }
    }
}
