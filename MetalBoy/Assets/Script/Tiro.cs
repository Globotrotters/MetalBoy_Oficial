using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
   
    public float m_Velocidade;
    public float vidaUtilTiro = 8f;
    float tempoNascimento;
    


    void Start()
    {
        tempoNascimento = Time.time;
    }

    void Update()
    {
        

        transform.Translate(Vector2.right * m_Velocidade * Time.deltaTime);

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
        if (Time.time >= tempoNascimento + vidaUtilTiro)
        {
            Destroy(gameObject);
        }
    }

}
