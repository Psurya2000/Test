using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D player_rb;
    private float x;
    private bool is_ground;
    public float speed = 5f;
    public float height = 50f;
    public bool faceright = true;
    public Animator player;
  
   
    
    public bool facingRight = true;
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        if (x > 0 && !facingRight)
            Flip();
        else if (x < 0 && facingRight)
            Flip();
        player.SetFloat("RunningSpeed", Mathf.Abs(x));
       

        transform.Translate(transform.right * x * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && is_ground == true)
        {
            player.SetBool("Jump", true);
            player_rb.AddForce(Vector2.up * height);
            is_ground = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            player.SetTrigger("attack");
        }
        healthslider.value = health;

        if (health <= 0)
            Destroy(gameObject);
    }
    public int health = 100;
    public Slider healthslider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.SetBool("Jump", false);
            is_ground = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 10;

        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
