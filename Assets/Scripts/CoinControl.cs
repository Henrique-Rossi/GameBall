using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ColetaMoedas(1);//quantidade do valor da moeda
            AudioManager.instance.SonsFxToca(0);
            Destroy(this.gameObject);
        }
    }
}
