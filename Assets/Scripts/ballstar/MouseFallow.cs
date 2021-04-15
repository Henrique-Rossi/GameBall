﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFallow : MonoBehaviour
{
    private float offSet= -0.8f;
    private Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,offSet);
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
        transform.position = new Vector3(tempPos.x,tempPos.y,offSet);
    }
}
