using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testetime : MonoBehaviour
{  
    private bool liberaNovaColisao  =false;

    private PointEffector2D pointEf;
    //private GameObject passeItem;
    private CircleCollider2D coliders;
    private void Start() {

     pointEf=GetComponent<PointEffector2D>();   
     coliders=GetComponent<CircleCollider2D>();   
     //passeItem=this.gameObject; funciona mas o fiz de outra maneira 
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && liberaNovaColisao==false)
        {         
            BallControl.instance.passeTocou= true;
             AudioManager.instance.SonsFxToca(4);
              GAMEMANAGER.instance.EfeitoParticulaParaChutarNovamente();
           //this.gameObject.SetActive(false);
           //Destroy(this.gameObject);
           
           liberaNovaColisao=true;
           pointEf.enabled=false;
           //coliders.enabled=false;
        }


    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            liberaNovaColisao=false;
            
          StartCoroutine(ReativaFisicaPoint());
        }
    }
     IEnumerator ReativaFisicaPoint()
     {
          yield return new WaitForSeconds(0.0008f);
          
          //this.gameObject.SetActive(true);
          //Debug.Log("ativo a fisica");
          pointEf.enabled=true;
          //coliders.enabled=true;
          
          
     }
    


}
