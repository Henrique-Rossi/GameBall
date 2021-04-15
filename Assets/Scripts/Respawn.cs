using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold=-50f;

    void FixedUpdate()
    {
        if (transform.position.y < threshold || transform.position.x < -150f)
            transform.position = new  Vector3(-3, 0, 0);

    }
     
}
