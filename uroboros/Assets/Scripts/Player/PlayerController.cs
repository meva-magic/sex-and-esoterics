using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 forceToApply;
    public Vector2 PlayerInput;
    public float forceDamping;
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        PlayerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Vector2 moveForce = PlayerInput.normalized * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;

        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.linearVelocity = moveForce;
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            forceToApply += new Vector2(-20, 0);
            Destroy(collision.gameObject);
        }
    }
}