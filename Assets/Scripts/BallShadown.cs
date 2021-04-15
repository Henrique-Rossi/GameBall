using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallShadown : MonoBehaviour
{
    public Vector3 Offset = new Vector3(-0.1f,-0.1f);
    GameObject _shadown;
    public Material Material;
    // Start is called before the first frame update
    void Start()
    {
         _shadown = new GameObject("Shadow");
         _shadown.transform.parent=transform;

         _shadown.transform.localPosition = Offset;
          _shadown.transform.localRotation= Quaternion.identity;
          SpriteRenderer renderer=GetComponent<SpriteRenderer>();
          SpriteRenderer sr = _shadown.AddComponent<SpriteRenderer> ();
          sr.sprite=renderer.sprite;
          sr.material = Material;

          sr.sortingLayerName=renderer.sortingLayerName;
          sr.sortingOrder=renderer.sortingOrder -1;
    }

    
     private void LateUpdate() {
    _shadown.transform.localPosition = Offset;    
    }
}
