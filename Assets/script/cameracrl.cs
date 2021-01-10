using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracrl : MonoBehaviour
{

    public Transform target;

    private Vector3 came;

    // Start is called before the first frame update
    void Start()
    {
        came = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, came.z);
    }
}
