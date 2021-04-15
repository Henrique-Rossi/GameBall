using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER instance;

    public int numChutesTotais;
    //public int  numJogadas;//vida da bola
    public int numBallLife; 
    [SerializeField]
    private Transform ballPositionStart;
    [SerializeField]
    private Transform ballPosition;
    //Qtd Vidas bola
    public Text txtBallLife;
    public Text txtPassesCount;
    public GameObject ballPrefab;
    private bool bolaDeath=false;
    public bool bolaEmCena;
    public GameObject particulaLiberaChute;
    
    //ui
    public bool win=false;
  //  public int queFaseEstou;
    public bool jogoComecou;


    

    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += Carrega;
        
        
        txtBallLife=GameObject.Find("BallLifesTxt").GetComponent<Text>();
        txtPassesCount=GameObject.Find("PassesCounttxt").GetComponent<Text>();
        ballPositionStart=GameObject.Find("posStart").GetComponent<Transform>();
    
           

            
        

        
    }

    void Carrega(Scene cena,LoadSceneMode modo){
        if (QueFaseEstou.instance.fase != 2)
        {                    
            //ballPositionStart= GameObject.FindWithTag("CheckPoint").GetComponent<Transform>();
            txtBallLife=GameObject.Find("BallLifesTxt").GetComponent<Text>();
            txtPassesCount=GameObject.Find("PassesCounttxt").GetComponent<Text>();
            ballPositionStart=GameObject.Find("posStart").GetComponent<Transform>();
            // ballPosition=GameObject.Find("Ball").GetComponent<Transform>();
            //queFaseEstou=SceneManager.GetActiveScene().buildIndex;            
           StartGame();
        }
    }
    // Start is called before the first frame update
    void Start()
    {   
        StartGame();
        ScoreManager.instance.GameStartScoreM();
        numBallLife=1;
       // numJogadas=1;
        numChutesTotais=2;
        
       //SpawnBall();
        
      
    }
    void Update() {
        ScoreManager.instance.UpdateScore();
        UiManager.instance.UpdateUI();
        //txtBallLife.text=numJogadas.ToString();
        txtBallLife.text=numBallLife.ToString();
        txtPassesCount.text=numChutesTotais.ToString();
        if (numBallLife <= 0 || numChutesTotais <= 0)
        {
            GameOver();
            
        }
        if (win == true)
        {
           WinGame();
        }
            if(jogoComecou == true && bolaEmCena == true){
                ballPosition=GameObject.Find("ball").GetComponent<Transform>();
            }
    }
  
    
    public void SpawnBall(){
       // Instantiate(ballPrefab, new Vector2(ballPositionStart.position.x,ballPositionStart.position.y),Quaternion.identity);
       //por algum motivo dependendo do vector z a bola fica lenta
       if (bolaEmCena==false)
       {      
           Instantiate(ballPrefab, new Vector3(ballPositionStart.position.x,ballPositionStart.position.y,0f),Quaternion.identity);               
            bolaEmCena=true;
            
       }
       
    }
    void GameOver(){
        UiManager.instance.GameOverUI();
        jogoComecou=false;
        

    }
    void WinGame(){
         UiManager.instance.WinGameUI();
         jogoComecou=false;
    }
    void StartGame(){
         jogoComecou=true;
         numBallLife=1;
         numChutesTotais=2;
         bolaEmCena=false;
         win=false;
         UiManager.instance.StartUI();
    }

    public void EfeitoParticulaParaChutarNovamente(){
       Instantiate(particulaLiberaChute, new Vector3(ballPosition.position.x,ballPosition.position.y,0f),Quaternion.identity);
        
   }
}
