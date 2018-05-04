using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevador : MonoBehaviour {

    public float velocidade;
    public Vector2 destinoCima;
    public Vector2 destinoBaixo;

    public bool Subindo = false;
    public bool Descendo = true;

    public void Update()
    {
        Andar();
    }

    public void Andar()
    {
        if (Subindo)
        {
            Subindo = true;
            Descendo = false;

       
             transform.position = Vector2.MoveTowards(transform.position, destinoCima, velocidade * Time.deltaTime);
             if (transform.position.y == destinoCima.y)
             {
                StartCoroutine(EsperarParaDescer());
                    
             }
        }

        if (Descendo)
        {
            Descendo = true;
            Subindo = false;


            transform.position = Vector2.MoveTowards(transform.position, destinoBaixo, velocidade * Time.deltaTime);
            if (transform.position.y == destinoBaixo.y)
            {
                StartCoroutine(EsperarParaSubir());

            }
        }

    }
    private IEnumerator EsperarParaSubir()
    {
        yield return new WaitForSeconds(2f);
        Subindo = true;
        Descendo = false;
    }

    private IEnumerator EsperarParaDescer()
    {
        yield return new WaitForSeconds(2f);
        Descendo = true;
        Subindo = false;
    }
}
