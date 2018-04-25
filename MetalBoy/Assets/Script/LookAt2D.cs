using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt2D : MonoBehaviour
{
    Vector3 m_mousePosition;

	void Update ()
    {
        m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_mousePosition.z = transform.position.z;
        transform.right = (m_mousePosition - transform.position);
	}
}
