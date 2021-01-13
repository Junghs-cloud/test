using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Vector3 position;

    public float speed = 2.5f;
    public float jump_force = 5f;

    public SpriteRenderer rend;
    Rigidbody2D rigid;
    public Animator animator;
    public bool is_jumping=false;


    public Text cherrycount;
    private int score = 0;



    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        counttext();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        is_jumping = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject,0.1f);
        Debug.Log("체리");
        score++;
        counttext();
    }

    // Update is called once per frame
    void Update()
    {
        move();

        jump();

    }

    void move()
    {
        position = transform.position;
        position.x += speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");

        transform.position = position;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rend.flipX = true;
            animator.SetBool("walk", true);
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rend.flipX = false;
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    void jump()
    {
        if (is_jumping == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                is_jumping = true;
                rigid.AddForce(Vector3.up * jump_force, ForceMode2D.Impulse);
            }
        }
    }

    void counttext()
    {
        cherrycount.text = score.ToString();
    }

}
