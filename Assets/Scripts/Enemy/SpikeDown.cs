using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDown : MonoBehaviour
{
    private Rigidbody2D spikeRB;
    public int atrito;
    public int atritoMaximo=50;
     public int atritominimo=30;
    public Vector3 pos;
    public GameObject spikePrefab;


    void Start()
    {
        spikeRB=GetComponent<Rigidbody2D>();
        atrito = Random.Range(atritominimo,atritoMaximo);
        spikeRB.drag=atrito;
        pos=transform.position;
    }
  /*  void OnBecameInvisible() {
        Instantiate(spikePrefab,pos,transform.localRotation);  
        Destroy(this.gameObject);
    }*/
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall"))
        {
            StartCoroutine(DistroySpike());
        }
        
    }

    
     IEnumerator DistroySpike()
     {
          yield return new WaitForSeconds(1f);
            Instantiate(spikePrefab,pos,transform.localRotation);  
         Destroy(this.gameObject);
     }
}
