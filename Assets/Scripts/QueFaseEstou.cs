using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QueFaseEstou : MonoBehaviour
{
    public int fase=-1;
    public static QueFaseEstou instance;
     [SerializeField]
    private GameObject UIManagerGO,GameManagerGO;

    private float orthoSize=40;
     [SerializeField]
    private float aspect=1.66f;
    
    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += VerificaFase;
    }

    void VerificaFase(Scene cena, LoadSceneMode modo)
    {
        fase=SceneManager.GetActiveScene().buildIndex;

        if (fase != 2 && fase !=1  && fase !=0)
        {
            Instantiate(UIManagerGO);
            Instantiate(GameManagerGO);

           // Camera.main.projectionMatrix=Matrix4x4.Ortho(-orthoSize * aspect, orthoSize*aspect ,-orthoSize,orthoSize,Camera.main.nearClipPlane,Camera.main.farClipPlane);
        }
    }
}
