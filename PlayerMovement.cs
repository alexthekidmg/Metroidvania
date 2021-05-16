using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    private bool facingRight = true;

    public float speed = 2.0f;
    public float hMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        hMovement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(hMovement * speed, rb2D.velocity.y);
        Flip();
        myAnimator.SetFloat("speed", Mathf.Abs(hMovement));
    }

    private void Flip()
    {
        if (hMovement < 0 && facingRight || hMovement > 0 && !facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
