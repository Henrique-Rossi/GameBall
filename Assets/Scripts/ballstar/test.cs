using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
     public Vector3 startPos;
    public  Vector3 endPos;
  public    Camera camera;
   public   LineRenderer lr;
 
    Vector3 camOffset = new Vector3(0, 0, 10);
 
    [SerializeField] AnimationCurve ac;
 
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lr == null)
            {
                lr = gameObject.AddComponent<LineRenderer>();
            }
            lr.enabled = true;
            lr.positionCount = 2;

            startPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            
            lr.SetPosition(0, startPos);
            lr.useWorldSpace = true;
            lr.widthCurve = ac;
            lr.numCapVertices = 10;
        }
        if (Input.GetMouseButton(0))
        {
            endPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;
            
            lr.SetPosition(1, endPos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
        }
    }
}
