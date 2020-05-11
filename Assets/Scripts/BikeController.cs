using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PedalController;

public class BikeController : MonoBehaviour
{
    
    public enum WheelType {
        Fixed,
        Free
    }
    
    private float x = 0;
    private float y = 0;
    private float z = 0;

    public WheelType wheelType;

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
