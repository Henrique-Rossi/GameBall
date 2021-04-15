using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{   
    public static BallControl instance;
    [SerializeField] private Transform forceTransform;
    private SpriteMask forceSpriteMask;
    public const float MAX_FORCE = 200f;
    private float holdDownStartTime;
    public bool liberaShow;
    public bool liberaChute=false;
    [SerializeField]  private GameObject rangeTouch;
    public bool passeTocou = false;

    private Rigidbody2D bolaRB;
    public bool  contatoComFisica=false;

    public bool liberaProximoChute=true;

   
  
//fazer um codigo separado do rangetouch para nao dar conflit com colider da ball
//animação trava qualquer modificação feita apos ela entao fizque atento a isso


//jogo vai ser girtado em torno dos PASSES  duas vidas uma se errrar outra pra tentar de novo acertar os passes

    private void Awake()
    {
        //pode bugar isso na frente qualquer cosia da uma olhada aqui

            instance = this;
            DontDestroyOnLoad(this.gameObject);


        forceSpriteMask = forceTransform.Find("mask").GetComponent<SpriteMask>();
        rangeTouch=GameObject.Find("RageTouch");
         HideForce();


        bolaRB=GetComponent<Rigidbody2D>();
        liberaProximoChute=true;
        

        
    }
    

    private void HideForce(){
        forceSpriteMask.alphaCutoff = 1;
    }
   
    private void Update()
    {

       

        if (liberaProximoChute == true)
        { 
             forceTransform.position = transform.position;
             Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
             forceTransform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
             //funçoes do mouse
             MouseTouchs();
            
        }
      
            
        //desativar fisica passe
        DesativaFisica();  
        //desativar fisisca e rativar  para bola parada    
        PararBolaParaAtivarNovaJogada(); 
        
    }
    
    void MouseTouchs(){
        if (Input.GetMouseButtonDown(0)) {
            // Mouse Down, start holding
            holdDownStartTime = Time.time;
        }

        if (Input.GetMouseButton(0)) {
            // Mouse still down, show force
            float holdDownTime = Time.time - holdDownStartTime;      
            ShowForce(CalculateHoldDownForce(holdDownTime));
         
           
        }

        if (Input.GetMouseButtonUp(0)) {
            // Mouse Up, Launch!
            
              float holdDownTime = Time.time - holdDownStartTime;   
            Launch(CalculateHoldDownForce(holdDownTime));   
           
             
                 
        }
    }
    
    
    private float CalculateHoldDownForce(float holdTime) {
        float maxForceHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        float force = holdTimeNormalized * MAX_FORCE;
        //Debug.Log(force);
        return force;
        
    }
       
   
    public void Launch(float force)
    { 
        if (liberaChute == true)
        {
            AudioManager.instance.SonsFxToca(1);
            Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * -1f;//direção 
            transform.GetComponent<Rigidbody2D>().velocity =dir * force;
            
        //Debug.Log(transform.GetComponent<Rigidbody2D>().velocity);
            HideForce();
            liberaProximoChute=false;
            liberaChute=false;
        }
        
    }

    public void ShowForce(float force)
    {
          if (liberaShow == true)
            {
               forceSpriteMask.alphaCutoff = 1 - force / MAX_FORCE * 1 ;//aqui velocidade que aparece o power
               liberaChute=true;
               
            }    
    }
        
    
    //Angulo
    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
      
    }
//repara se o rage nao ta colidino antes pra nao dar problema
    /*void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("RaioDaFisica")){
            contatoComFisica=true;
        }
    }
     void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("RaioDaFisica")){
            contatoComFisica=false;
        }
    }*/
    /*
                    //por causa do range pra executar a froça ele colide e da erro
                    void OnTriggerEnter2D(Collider2D other) {
                        if(other.gameObject.CompareTag("Win")){
                            GAMEMANAGER.instance.win=true;
                            int temp=QueFaseEstou.instance.fase+1;
                            temp++;
                            PlayerPrefs.SetInt("Level"+temp,1);
                            
                        }

                        if (other.gameObject.CompareTag("Desativa")) //tag rage que ta epgando
                        {
                            StartCoroutine(LateCall());
                            Destroy(other.gameObject);
                        }
                    }
*/
 

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall")){
            AudioManager.instance.SonsFxToca(2);
            
        }
        
       
    }
    

    void OnMouseDown() {
      liberaShow=true;
     
    }
    void OnMouseUp() {
     liberaShow=false;
    

    //rangeTouch.SetActive(false);
    }
 






    void DesativaFisica(){      
        if(passeTocou == true){
           passeTocou=false;
           StartCoroutine(DesativaFisicaAoTocar()); 
        }     
     }

    IEnumerator DesativaFisicaAoTocar() {
        // yield return new WaitForSeconds(0.001f); funciona se nao ter problema com range
        yield return new WaitForSeconds(0.001f);
        //Debug.Log("ativo");
        GetComponent<Rigidbody2D>().isKinematic = true;
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(DesaCall());
    }
    IEnumerator DesaCall(){
        yield return new WaitForSeconds(0.001f);
        //Debug.Log("ativo de novo");
        GetComponent<Rigidbody2D>().isKinematic = false;
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        liberaProximoChute=true;
    }
    public void DesativaTudoAoVencer(){  
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<CircleCollider2D>().enabled=false;
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }



////////////////////////////////////////////////////////////////////////////////






    //Sistema de Chutar novamente
     void PararBolaParaAtivarNovaJogada(){
        //desativar fisica tbm quando acabar os chutes pois  ainda da pra jogar mesmo assim
       if (bolaRB.velocity.magnitude < 1.5f && bolaRB.velocity.magnitude > 0f &&  contatoComFisica==false  )
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine( LiberaNovoChute());
       
            Debug.Log("Liberado");
            if (GAMEMANAGER.instance.numChutesTotais >1)
            {
                 GAMEMANAGER.instance.EfeitoParticulaParaChutarNovamente();
                  AudioManager.instance.SonsFxToca(3);
                  //Finish.instance.AtivaAnim();
            }
           
            liberaProximoChute=true;
                /*
                if(bolaRB.IsSleeping()){
                    Debug.Log("Dormiu");
                }*/  
            VerificaChute(); 
        }
     }
     IEnumerator LiberaNovoChute()
     {
          yield return new WaitForSeconds(0.0001f);
          //Debug.Log("ativo de novo");
          GetComponent<Rigidbody2D>().isKinematic = false;
          transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
      
     }




     void VerificaChute(){
        // GAMEMANAGER.instance.bolaEmCena = false;    
        // DestroyGameObjectsWithTag("Player"); 
       
            GAMEMANAGER.instance.numChutesTotais --;
           
           if (GAMEMANAGER.instance != null && GAMEMANAGER.instance.numChutesTotais > 0)
           {
               GAMEMANAGER.instance.SpawnBall();               
           }
    }
   



   

}
