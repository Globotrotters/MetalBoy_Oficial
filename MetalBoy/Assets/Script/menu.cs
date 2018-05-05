using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	// Tempo para sair a tela de carregamento
	float tempoDeCarregamento = 3f;


	public GameObject telaDeCarregamento;
	public GameObject telaDeCreditos;
	public GameObject menuPrincipal;

	//Botoes
	public Button[] botoes;

	// Metodos Para o Menu Principal
	public void IniciarJogo()
	{
		SceneManager.LoadScene ("cenario1");
	}

	public void Carregarjogo()
	{
		//SceneManager.LoadScene ();
	}

	public void VoltarAoMenu()
	{
		telaDeCreditos.SetActive (false);
		menuPrincipal.SetActive (true);

	}

	public void TelaDeCredito()
	{
		telaDeCreditos.SetActive (true);
	}

	public void SairDoJogo()
	{
		Application.Quit();
	}

	void Start () 
	{
		telaDeCarregamento.SetActive (true);

	}
	

	void Update () 
	{
		tempoDeCarregamento -= Time.deltaTime;

	    if (tempoDeCarregamento < 0.01f)
		{
			telaDeCarregamento.SetActive (false);
			tempoDeCarregamento = 0f;
		}
	}
}
