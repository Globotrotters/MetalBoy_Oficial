using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour {

    //Atributos da Porta
    private int vida = 10;
	
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TiroPersonagem")
        {
            vida--;
            if (vida == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
