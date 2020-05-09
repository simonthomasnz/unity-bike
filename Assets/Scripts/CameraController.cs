using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PedalController;

public class CameraController : MonoBehaviour
{
    private float x = 6.82f;
    private float y = 1.09f;
    private float z = -9.13f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        z += Time.deltaTime * PedalController.speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (x, y, z);
    }
}
