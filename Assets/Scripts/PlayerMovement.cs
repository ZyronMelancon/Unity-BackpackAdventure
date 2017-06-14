using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float m_Acceleration = 5;
    public float m_MaxSpeed = 7.5f;
    public float m_JumpForce = 1000;
    public float m_JumpCooldown = 1.5f;

    Rigidbody2D body;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(Jump());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
            if (Mathf.Abs(body.velocity.x) < m_MaxSpeed)
                body.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * m_Acceleration * body.mass, 0));
            else { }
        else
            body.velocity = new Vector2(body.velocity.x * 0.9f, body.velocity.y);
	}

    IEnumerator Jump()
    {
        while (true)
        {
            if (Input.GetAxisRaw("Jump") == 1)
            {
                body.AddForce(new Vector2(0, m_JumpForce));
                yield return new WaitForSeconds(m_JumpCooldown);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
