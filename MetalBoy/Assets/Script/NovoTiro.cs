using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovoTiro : MonoBehaviour {

    public float m_velocidade;

	void Update ()
    {
        transform.Translate(Vector2.right * m_velocidade * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
