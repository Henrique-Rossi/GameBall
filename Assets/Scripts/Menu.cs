using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ChangeMenuScene(string scene)
    {
      /*  Application.LoadLevel(scene);*/
        SceneManager.LoadScene(scene);
    }
    public void Jogar(){
      SceneManager.LoadScene(2);
    }
}
