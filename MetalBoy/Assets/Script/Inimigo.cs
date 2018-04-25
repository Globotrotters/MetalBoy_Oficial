using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public Transform playerT;
    public GameObject tiroPrefab;
    public float velocidade;
    public float tempoTiro = 1;
    float tempoIniciativa;
    public Animator inimigo;

    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update ()
    {
        if (playerT != null)
        {
            transform.right = (playerT.position - transform.position);

            float _distancia = Vector2.Distance(transform.position, playerT.position);
            if (_distancia > 1 && _distancia < 3)

                transform.position = Vector2.MoveTowards(transform.position, playerT.position, velocidade * Time.deltaTime);

            if (_distancia < 3)
                Atirar();
        }
    }

    void Atirar()
    {
        tempoIniciativa += Time.deltaTime;
        if (tempoIniciativa > tempoTiro)
        {
            tempoIniciativa = 0;
            inimigo.SetTrigger("Atacando");
            Instantiate(tiroPrefab, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "TiroPlayer")
        {
            Destroy(gameObject);
        }
    }
}
