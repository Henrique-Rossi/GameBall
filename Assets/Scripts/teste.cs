using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
   
     Vector2 startPos, endPos, direction;
     Rigidbody2D myRigidbody2D;
     public  float shootPower = 10f;
 
     void Start()
     {
         myRigidbody2D = GetComponent<Rigidbody2D> ();
     }
    void Update() {
        FaceMouse();
    }
    void OnMouseDown (){
        if (Input.GetMouseButtonDown (0)) {
            startPos = Input.mousePosition;
        }
    }

    void OnMouseUp (){
        if (Input.GetMouseButtonUp (0)) {
            endPos = Input.mousePosition;
            direction = startPos - endPos;
            myRigidbody2D.isKinematic = false;
            myRigidbody2D.AddForce (direction * shootPower);
        }
    }
    void FaceMouse(){
    var dir=Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    var angle=Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
    transform.rotation=Quaternion.AngleAxis(angle,Vector3.forward);
}
}
