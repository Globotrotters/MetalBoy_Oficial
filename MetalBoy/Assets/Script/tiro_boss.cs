using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro_boss : MonoBehaviour
{
    public float velocidade;
    public bool iraDireita = false;
    public float tempoNascimento;
    public float vidaUtilTiro = 3f;

    private void Start()
    {
        tempoNascimento = Time.time;
    }

    void Update()
    {
        if(iraDireita)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (Time.time >= tempoNascimento + vidaUtilTiro)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "player")
        {
            Destroy(gameObject);
        }

    }

}