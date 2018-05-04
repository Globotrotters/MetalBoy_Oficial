using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

    public GameObject item2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Personagem")) 
        {
            Destroy(gameObject);
        }
    }


   
}
