using UnityEngine;

public class Inimigo : MonoBehaviour
{
    //Atributos
    public Transform playerT;
    public GameObject tiroPrefab;
    public float velocidade;
    public float tempoTiro = 1;
    float tempoIniciativa;
    public Animator inimigo;
    public float vidaInimigo = 7f;

    private bool viradoDiretia = true;

    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("Personagem").transform;
    }

    void Update ()
    {
        if (playerT != null)
        {
            float _distancia = Vector2.Distance(transform.position, playerT.position);
            if (_distancia > 5 && _distancia < 10)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerT.position, velocidade * Time.deltaTime);

                //player na esquerda
                if (playerT.position.x < transform.position.x)
                {
                    viradoDiretia = false;
                    GetComponent<SpriteRenderer>().flipX = true;
                }

                //player na direita
                if (playerT.position.x > transform.position.x)
                {
                    viradoDiretia = true;
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }               

            if (_distancia < 10)
            {
                Atirar();
            }
        }
    }

    void Atirar()
    {
        tempoIniciativa += Time.deltaTime;
        if (tempoIniciativa > tempoTiro)
        {
            tempoIniciativa = 0;
            inimigo.SetTrigger("Atacando");
            
            GameObject tiroObjeto = Instantiate(tiroPrefab, transform.position, transform.rotation);
            tiroObjeto.GetComponent<Tiro>().posPlayer = playerT;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "TiroPersonagem")
        {
            vidaInimigo--;

            if (vidaInimigo == 0)
            {
                Destroy(gameObject);
            }

            Destroy(col.gameObject);
        }
    }
}


