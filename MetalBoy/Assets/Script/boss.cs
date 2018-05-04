using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    public Transform bossT;
    public tiro_boss tiroPrefab;
    public float velocidade;
    public float tempoTiro = 1;
    float tempoIniciativa;
    public int vida;

    public Vector2 destinoEsquerda;
    public Vector2 destinoDireita;

    public bool viradoaDireita = false;
    public bool posicaoDireita = true;

    public bool atirando = true;
    public bool andando = true;
    public int tiro = 0;

    void Start()
    {
        bossT = GameObject.FindGameObjectWithTag("boss").transform;
        tiro = 0;
    }

    void Update()
    {
        if (atirando && !andando)
        {
            tempoIniciativa += Time.deltaTime;
            if (tempoIniciativa > tempoTiro)
            {
                Atirar();
                tiro++;

                if (tiro == 5)
                {
                    atirando = false;
                    StartCoroutine(EsperarParaAndar());
                    tiro = 0;
                }

                tempoIniciativa = 0;
            }
        }

        else if(andando && !atirando)
        {
            Andar();
        }
    }

    void Atirar()
    {
        GetComponent<Animator>().SetTrigger("atacando");

        tiro_boss tiro = Instantiate(tiroPrefab, transform.position, transform.rotation);
        tiro.iraDireita = viradoaDireita;
    }

    void Andar()
    {
        GetComponent<Animator>().SetBool("andando", true);

        if (posicaoDireita)
        {
            transform.position = Vector2.MoveTowards(transform.position, destinoEsquerda, velocidade * Time.deltaTime);
                        
            if(transform.position.x == destinoEsquerda.x)
            {
                posicaoDireita = false;

                if (!viradoaDireita)
                {
                    viradoaDireita = true;
                    transform.localScale = new Vector3(5, 5, 1);

                    StartCoroutine(EsperarParaAtirar());
                    andando = false;

                    GetComponent<Animator>().SetBool("andando", false);
                }
            }      
        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, destinoDireita, velocidade * Time.deltaTime);

            if (transform.position.x == destinoDireita.x)
            {
                posicaoDireita = true;

                if (viradoaDireita)
                {
                    viradoaDireita = false;
                    transform.localScale = new Vector3(-5, 5, 1);

                    StartCoroutine(EsperarParaAtirar());
                    andando = false;

                    GetComponent<Animator>().SetBool("andando", false);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "TiroPersonagem")
        {
            vida--;
            if (vida == 0)
                Destroy(gameObject);
        }
    }

    private IEnumerator EsperarParaAndar()
    {
        yield return new WaitForSeconds(2f);
        andando = true;
    }

    private IEnumerator EsperarParaAtirar()
    {
        yield return new WaitForSeconds(2f);
        atirando = true;
    }
}
