using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminoCenario : MonoBehaviour
{

    public GameObject painelTermino;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Personagem")
        {
          painelTermino.SetActive(true);
        }
    }
}