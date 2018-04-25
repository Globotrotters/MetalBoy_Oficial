﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPersonagem : MonoBehaviour {

    public GameObject efeitoTiro;
    private GameObject efeitoTiroInstanciado;


    public float velocidadeProjetil;
    private float tempoProjetil;
    public float delayEfeito, inicialTempoEfeito, delayTiro, inicialTempoTiro;

    
     


    void Start ()
    {
        efeitoTiroInstanciado = Instantiate(efeitoTiro, transform.position, transform.rotation);
        inicialTempoEfeito = Time.time;
        inicialTempoTiro = Time.time;
       
        
        
    }
	
	
	void Update ()
    {
        transform.Translate((Vector2.right * velocidadeProjetil) * Time.deltaTime);

        
    }

    private void FixedUpdate()
    {
        if (Time.time >= inicialTempoEfeito + delayEfeito)
        {
            Destroy(efeitoTiroInstanciado.gameObject);
        }

        if(Time.time >= inicialTempoTiro + delayTiro)
        {
            Destroy(gameObject);
        }
              

    }
}
