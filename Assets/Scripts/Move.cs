using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Move : MonoBehaviour
{
    public float speed;
    public float height;
    public Rigidbody2D rb;
    public bool isground = false;
    public bool facingright = true;
    //public Animator anim;
    public string jumpButton = "Jump";
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {

        float x = SimpleInput.GetAxis("Horizontal");


        transform.Translate(Vector2.right * x * speed * Time.deltaTime);
        if (x > 0.0f && facingright == false)
        {

            flip = false;
        }
        else if (x < 0.0f && facingright == true)
        {
            flip = true;
        }
        //if (x == 0)
        //    anim.SetTrigger("idle");
        //else if (x >= 0.1 || x < -0.1)
        //    anim.SetTrigger("run");
    }
    private void Update()
    {
        

        FlipPlayer();
        if (SimpleInput.GetKeyDown(KeyCode.Space) && isground == true)
        {

            rb.AddForce(Vector2.up * height);
            //anim.SetBool("jump", true);
            isground = false;

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
            //anim.SetBool("jump", false);
            isground = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 10;
          
        }

    }
    bool flip;
    void FlipPlayer()
    {

        facingright = !facingright;
        Vector2 localScale = gameObject.transform.localScale;
        GetComponent<SpriteRenderer>().flipX = flip;
        transform.localScale = localScale;
    }

}
