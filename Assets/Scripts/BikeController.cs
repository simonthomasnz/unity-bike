using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{

    private float speed = 1.0f;

    private float x = 0;
    private float y = 0;
    private float z = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        z += Time.deltaTime * speed;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (x, y, z);
    }
}
