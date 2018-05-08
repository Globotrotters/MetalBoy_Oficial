using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
   
    public float m_Velocidade;
    public float vidaUtilTiro = 3f;
    float tempoNascimento;
    public Transform posPlayer;
    private Vector3 posPlayerQuandoAtirou;
    


    void Start()
    {
        tempoNascimento = Time.time;
        posPlayerQuandoAtirou = posPlayer.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, posPlayerQuandoAtirou, m_Velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Inimigo")
        {
            Destroy(gameObject);
        }   
    }

    public void FixedUpdate()
    {
        if (transform.position == posPlayerQuandoAtirou)
        {
            Destroy(gameObject);
        }

        if (Time.time >= tempoNascimento + vidaUtilTiro)
        {
            Destroy(gameObject);
        }
    }
}
