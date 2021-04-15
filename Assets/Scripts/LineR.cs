using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineR : MonoBehaviour
{
    public Transform p2,p3;

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        //colcoa em updtae para atualziar cosntantimente
        LinhaR();
    }
    void LinhaR(){
         //index da lista 0 a 2  
        gameObject.GetComponent<LineRenderer>().SetPosition(0,transform.position) ;
        gameObject.GetComponent<LineRenderer>().SetPosition(1,p2.transform.position) ;
        gameObject.GetComponent<LineRenderer>().SetPosition(2,p3.transform.position) ;
    }
}
