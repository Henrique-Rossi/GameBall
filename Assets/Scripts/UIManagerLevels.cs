using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerLevels : MonoBehaviour
{[SerializeField]
    private Text moedasLevels;

    // Start is called before the first frame update
    void Start()
    {
        moedasLevels.text=PlayerPrefs.GetInt("moedasSave").ToString();
        
    }

   
}
