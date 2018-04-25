using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject m_tiroPrefab;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(m_tiroPrefab, transform.position, transform.rotation);
	}
}
