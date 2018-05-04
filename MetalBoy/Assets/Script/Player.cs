using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

	// Componentes
	public Rigidbody2D rb;
    public Animator personagem;
    public SpriteRenderer fliparPersonagem;
    public GameObject tiroPersonagem;
    public Transform pontaArma;
    public GameObject painelMorrer;
    public Button[] opcao;
     

    
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
    private float vidaTotal = 20f;
    private float vidaPersonagem = 1f;
    private float escalaPersonagem;

    // private int life = 5;

    

    public void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
        personagem = GetComponent<Animator>();
        fliparPersonagem = GetComponent<SpriteRenderer>();
	}

	public void Start () 
	{
        escalaPersonagem = transform.localScale.x;
    }

	public void Update () 
	{
        // Input.GetAxis("Horizontal"), vai servir para usar o botao Right para aumentar o valor da variavel
		moveHorizontal = Input.GetAxis ("Horizontal") * Time.deltaTime;
        moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject objetoTiro = Instantiate(tiroPersonagem, pontaArma.position , pontaArma.rotation);

            if(transform.localScale.x > 0)
            {
                objetoTiro.GetComponent<TiroPersonagem>().tiroParaDireita = true;
            }
            else if(transform.localScale.x < 0)
            {
                objetoTiro.GetComponent<TiroPersonagem>().tiroParaDireita = false;
            }
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
        posX = Mathf.Clamp(transform.position.x + (moveHorizontal * speed), -2, 337);
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
                //fliparPersonagem.flipX = false;
                transform.localScale = new Vector3(escalaPersonagem, escalaPersonagem, 1);
            }

            else
            {
                //fliparPersonagem.flipX = true;
                transform.localScale = new Vector3(-escalaPersonagem, escalaPersonagem, 1);
            }
            

        }

              
     }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma_Chao")
        {
            estaPulando = false;
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
                personagem.SetBool("Morrer", true);
                

                

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PowerUP")
        {
            vidaPersonagem = vidaTotal;
        }

        if (collision.gameObject.tag == "Fim_Cenario")
        {
            Destroy(gameObject);
        }
    }

    public void ContinuarSim()
    {
        SceneManager.LoadScene("cenario1");
    }

    public void ContinuarNao()
    {
        SceneManager.LoadScene("Menu");
    }

}