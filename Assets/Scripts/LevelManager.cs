using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class Level{
      public string levelText;
      public bool habilitado;
      public int desbloqueado;
      public bool txtAtivo;
    }
      public GameObject botao;
      public Transform localBtn;
      public List<Level> levelList;
    
    void ListAdd(){
        foreach (Level level in levelList)
        {
           GameObject btnNew= Instantiate (botao) as GameObject; 
            ButtonLevels NovoBtnNew= btnNew.GetComponent<ButtonLevels>();
            NovoBtnNew.levelTxtBTN.text=level.levelText;
          
            if (PlayerPrefs.GetInt("Level"+ NovoBtnNew.levelTxtBTN.text)==1)
            {
                level.desbloqueado=1;
                level.habilitado=true;
                level.txtAtivo=true;
            }
            NovoBtnNew.desbloqueadoBTN = level.desbloqueado;
            NovoBtnNew.GetComponent<Button>().interactable = level.habilitado;
            NovoBtnNew.GetComponentInChildren<Text>().enabled= level.txtAtivo;
            NovoBtnNew.GetComponent<Button>().onClick.AddListener(()=> ClickLevel("level"+NovoBtnNew.levelTxtBTN.text));
            btnNew.transform.SetParent(localBtn,false);
        }
    }

    void ClickLevel(string level){
      SceneManager.LoadScene(level);
    }
    void Awake() {
        Destroy(GameObject.Find("UiManager(Clone)"));
        Destroy(GameObject.Find("GameManager(Clone)"));
    }
    void Start()
    {
        ListAdd();
    }

    

}
