using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour {

    // Componentes
    public Rigidbody2D easterEgg;
    public Animator eE;

    // Atributos
    public float velocidade;
    public float delayAnimacao;
    private float tempoAnimacao;


	void Start ()
    {
        easterEgg = GetComponent<Rigidbody2D>();
        tempoAnimacao = Time.time;
        
	}
	
	
	public void FixedUpdate ()
    {
               
        if (Time.time >= tempoAnimacao + delayAnimacao )
        {
            easterEgg.AddForce(Vector2.up * velocidade);
            if (transform.position.y >= -15)
            {
                Destroy(easterEgg.gameObject);
            }
        }
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma_Chao")
        {
            eE.SetBool("Delay", true);
        }
    }
}
