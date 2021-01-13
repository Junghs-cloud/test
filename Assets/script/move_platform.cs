using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_platform : MonoBehaviour
{

    Vector3 position;
    Vector3 ori_position;
    Vector3 target_position;
    public float movepower = 1f;
    public float check_distance = 10f;
    private bool player = false;

    // Start is called before the first frame update
    void Start()
    {
        ori_position = transform.position;
        target_position = ori_position + new Vector3(0 , check_distance * 1 * 1, 0);

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        player = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (player == true)

        {
            position = transform.position;
            position = position + new Vector3(0, 1 * movepower * Time.deltaTime, 0);
            transform.position = position;


            if (position.y >= target_position.y)
            {
                movepower = -1;
            }

            if (position.y <= ori_position.y)
            {
                movepower = 1;
            }

        }
    }

}
