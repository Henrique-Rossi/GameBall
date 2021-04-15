using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
     public static UiManager instance;
     public Text scoreUI;
     [SerializeField]
     private GameObject losePanel,winPanel,pausePanel;
       //pause
     [SerializeField]
     private Button pauseBTN,pauseBTNReturn,pauseMenuBtn,pauseReload;
      //lose botoes
     [SerializeField]
     private Button novamenteBTN,levelMenuBTN;
     //wIn botoes
     [SerializeField]
     private Button btnLevelWin,btnNovamenteWin,btnAvancaWin;
     //moedas
      [SerializeField]
     public int moedasNumAntes,moedasNumDepois,moedasResultados;
  

     void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
            else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += Carrega;
        PegarDadosUI();
    }

    void PegarDadosUI(){
        if (QueFaseEstou.instance.fase != 2)
        {     
            scoreUI=GameObject.Find("ScoreUI").GetComponent<Text>();
            winPanel=GameObject.Find("WinPanel");
            pausePanel=GameObject.Find("Pause");
            losePanel=GameObject.Find("LosePanel");


        //========================Botões=================================================================//
            //pause       
            pauseBTN        = GameObject.Find("PauseBTN").GetComponent<Button>();
            pauseBTNReturn  = GameObject.Find("pauseBTNReturn").GetComponent<Button>();
            pauseMenuBtn      = GameObject.Find("MenuBtnPause").GetComponent<Button>();
            pauseReload  = GameObject.Find("ReloadBTNReturn").GetComponent<Button>();
            //lose
            novamenteBTN    = GameObject.Find("JogarNovamenteBTN").GetComponent<Button>();
            levelMenuBTN    = GameObject.Find("MenuBtnLose").GetComponent<Button>();

            //win
            btnNovamenteWin = GameObject.Find("btnNovamenteWin").GetComponent<Button>();
            btnLevelWin     = GameObject.Find("btnLevelWin").GetComponent<Button>();
            btnAvancaWin    = GameObject.Find("btnAvancaWin").GetComponent<Button>();



        //========================AddListener=================================================================//
            //pause
            pauseBTN.onClick.AddListener(Pause);
            pauseBTNReturn.onClick.AddListener(PauseReturn);
            pauseMenuBtn.onClick.AddListener(Levels);
            pauseReload.onClick.AddListener(JogarNovamente);
            //lose
            novamenteBTN.onClick.AddListener(JogarNovamente);
            levelMenuBTN.onClick.AddListener(Levels);

            //win
            btnNovamenteWin.onClick.AddListener(JogarNovamente);
            btnLevelWin.onClick.AddListener(Levels);
            btnAvancaWin.onClick.AddListener(ProximaFase);


            //moedas
            moedasNumAntes= PlayerPrefs.GetInt("moedasSave");
        }
    }


    void Carrega(Scene cena,LoadSceneMode modo){
        PegarDadosUI();
    }




    public void StartUI(){
        LigaDesligaPainel();
       /* if (GAMEMANAGER.instance != null && GAMEMANAGER.instance.numJogadas > 0)
           {
               GAMEMANAGER.instance.SpawnBall();
           }*/
            if (GAMEMANAGER.instance != null && GAMEMANAGER.instance.numBallLife > 0)
           {
               GAMEMANAGER.instance.SpawnBall();
           }
    }




    public void UpdateUI(){
        scoreUI.text= ScoreManager.instance.moedas.ToString();
        moedasNumDepois = ScoreManager.instance.moedas;
    }




    public void GameOverUI(){
       
        losePanel.SetActive(true);
         
    }




    public void WinGameUI(){
        winPanel.SetActive(true);
    }




    //pause
    void Pause(){
        pausePanel.SetActive(true);
        pausePanel.GetComponent<Animator>().Play("pause");
        Time.timeScale=0;
    }
    void PauseReturn(){
      
        pausePanel.GetComponent<Animator>().Play("pauseR");
        Time.timeScale=1;
        StartCoroutine(EsperaPause());
    }
    

    void Despausar(){
        Time.timeScale=1;
        StartCoroutine(EsperaPause());
    }



    //lose
    void JogarNovamente(){
       Time.timeScale=1;
        if (GAMEMANAGER.instance.win == false)
        {
            SceneManager.LoadScene(QueFaseEstou.instance.fase); 
            moedasResultados = moedasNumDepois-moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(moedasResultados);
            moedasResultados=0;
            
        }else{
            SceneManager.LoadScene(QueFaseEstou.instance.fase); 
            moedasResultados=0;
        }
    }




    void Levels(){
        if(Time.timeScale==0){
            Despausar();
        }
         
        if (GAMEMANAGER.instance.win == false)
        {
            moedasResultados = moedasNumDepois-moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(moedasResultados);
            moedasResultados=0;
            SceneManager.LoadScene(2);//4 é build seting  da cena do menu de leveis
        }
        else
        {
            moedasResultados=0;
            SceneManager.LoadScene(2);
        }
    }



    void ProximaFase(){
        if (GAMEMANAGER.instance.win == true)
        {
            int temp=QueFaseEstou.instance.fase + 1;
            SceneManager.LoadScene(temp);
        }
    }


    void LigaDesligaPainel(){
        StartCoroutine(tempo());
    }
    IEnumerator EsperaPause(){
        yield return new WaitForSeconds(0.8f);
        pausePanel.SetActive(false);
    }
   //desliga rapidamente ao ligar o jogo
    IEnumerator tempo(){
       yield return new WaitForSeconds(0.001f);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
}
