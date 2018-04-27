using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Componentes
	public Rigidbody2D rb;
    public Animator personagem;
    public SpriteRenderer fliparPersonagem;
    public GameObject tiroPersonagem;
    public Transform pontaArma;

    
	// Transform
	public float moveHorizontal;
	public float moveVertical;

	// Propriedade para Posição
	public float posX;
	public float posY;

	//Atributos
	public float speed;
	public float jump;
    public bool estaPulando = false;
    private float vidaPersonagem = 10f;
    // private int life = 5;

    

    public void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
        personagem = GetComponent<Animator>();
        fliparPersonagem = GetComponent<SpriteRenderer>();
	}

	public void Start () 
	{
        
    }

	public void Update () 
	{
        // Input.GetAxis("Horizontal"), vai servir para usar o botao Right para aumentar o valor da variavel
		moveHorizontal = Input.GetAxis ("Horizontal") * Time.deltaTime;
        moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(tiroPersonagem, pontaArma.position , pontaArma.rotation);
            
        }


	}

	public void FixedUpdate()
	{
        if (!estaPulando && moveVertical > 0)
        {
            estaPulando = true;
            rb.AddForce(Vector2.up * jump);

            if (estaPulando == true)
            {
                personagem.SetBool("Pular", true);
            }
        }

        else if (estaPulando == false)
        {
            personagem.SetBool("Pular", false);
        }

        // comando para movimentar na direção em X.
        posX = transform.position.x + (moveHorizontal * speed);
        // para pular.
        //posY = transform.position.y + (moveVertical * jump);
        transform.position = new Vector2(posX, transform.position.y);
        
        // posY = transform.position.y + (moveVertical * jump);
        // transform.position = new Vector2(posX, posY);

        if (moveHorizontal == 0)
        {
            personagem.SetBool("Andar", false);
        }

        else
        {
            personagem.SetBool("Andar", true);
            if (moveHorizontal > 0)
            {
                fliparPersonagem.flipX = false;
            }

            else
            {
                fliparPersonagem.flipX = true;
            }
            

        }

     }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma_Chao")
        {
            {
                estaPulando = false;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tiro")
        {
            vidaPersonagem--;
            Debug.Log(vidaPersonagem);
            if (vidaPersonagem == 0)
            {
                Destroy(gameObject);
            }
        }
    }

} 