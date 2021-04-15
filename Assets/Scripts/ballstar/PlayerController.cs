using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject mousePointA;
    private GameObject mousePointB;
    private GameObject arrow;
    private GameObject circle;
    //calc distancve
    private float currentDistance;
    public float maxdistance = 3f;
    private float safeSpace;
    private float shootpower;

    private Vector3 shootDirection;

    private void Awake() {
         mousePointA = GameObject.FindGameObjectWithTag("PointA");
         mousePointB = GameObject.FindGameObjectWithTag("PointB");
         circle= GameObject.FindGameObjectWithTag("Circle");
         arrow = GameObject.FindGameObjectWithTag("Arrow");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDrag() {
        currentDistance = Vector3.Distance(mousePointA.transform.position,transform.position);
        if(currentDistance <= maxdistance)
        {
            safeSpace= currentDistance;
        }else{
            safeSpace=maxdistance;
        }

        doArrowAndCicleStuff();

        shootpower = Mathf.Abs(safeSpace) * 13;

        Vector3 dimxy = mousePointA.transform.position - transform.position;
        float difference = dimxy.magnitude;
        mousePointB.transform.position=transform.position + ((dimxy/difference)* currentDistance * -1);
        mousePointB.transform.position = new Vector3(mousePointB.transform.position.x,mousePointB.transform.position.y,-0.5f);

        shootDirection = Vector3.Normalize(mousePointA.transform.position - transform.position);
    }

    
    private void OnMouseUp() {
        arrow.GetComponent<Renderer>().enabled = false;
        circle.GetComponent<Renderer>().enabled =false;

         Vector3 push = shootDirection * shootpower * -1;
        GetComponent<Rigidbody2D>().AddForce(push,ForceMode2D.Impulse);
    }

    private void doArrowAndCicleStuff(){
        arrow.GetComponent<Renderer>().enabled = true;
        circle.GetComponent<Renderer>().enabled = true;

        //calc position
        if (currentDistance <= maxdistance)
        {
            arrow.transform.position = new Vector3((2 * transform.position.x) - mousePointA.transform.position.x,
                                                   (2 * transform.position.y) - mousePointA.transform.position.y,-1.5f);

        }else{
            Vector3 dimxy=mousePointA.transform.position- transform.position;
            float difference = dimxy.magnitude;
            arrow.transform.position=transform.position + ((dimxy/difference)* maxdistance * -1);
            arrow.transform.position = new Vector3(arrow.transform.position.x,arrow.transform.position.y,-1.5f);
        }
        circle.transform.position = transform.position + new Vector3(0,0,0.05f);
        Vector3 dir= mousePointA.transform.position - transform.position;
        float rot;
        if (Vector3.Angle(dir,transform.forward)> 90)
        {
            rot = Vector3.Angle(dir,transform.right);
        }else{
            rot = Vector3.Angle(dir,transform.right)* -1;
        }
        arrow.transform.eulerAngles = new Vector3(0,0,rot);

        float scaleX= Mathf.Log(1 + safeSpace / 2,2) * 2.2f;
        float scaleY= Mathf.Log(1 + safeSpace / 2,2) * 2.2f;

        arrow.transform.localScale = new Vector3(1 + scaleX,1 + scaleY,0.001f);
        circle.transform.localScale = new Vector3(1 + scaleX,1 + scaleY,0.001f);
    }
}
