using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Vector3 position;

    public float speed = 2f;
    public float jump_force = 5f;

    public SpriteRenderer rend;
    Rigidbody2D rigid;
    public bool is_jumping=false;


    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        is_jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        position.x += speed*Time.deltaTime*Input.GetAxisRaw("Horizontal");

        transform.position = position;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rend.flipX = true;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rend.flipX = false;
        }

        if (is_jumping ==false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                is_jumping = true;
                rigid.AddForce(Vector3.up * jump_force, ForceMode2D.Impulse);
            }
        }

    }

}
