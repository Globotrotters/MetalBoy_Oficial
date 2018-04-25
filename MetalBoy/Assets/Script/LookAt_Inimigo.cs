using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt_Inimigo : MonoBehaviour {


    Transform m_Player;
	void Start ()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.right = (m_Player.position - transform.position);
	}
}
