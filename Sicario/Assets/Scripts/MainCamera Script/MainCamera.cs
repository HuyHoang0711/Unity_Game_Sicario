using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform spaceship;
    
    // Start is called before the first frame update
    private void Awake()
    {
        spaceship = GameObject.Find("spaceship").transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            Vector3 pos = transform.position;
            // pos.x = spaceship.transform.position.x;
            pos.y = spaceship.position.y;
            pos.x = spaceship.position.x;
            transform.position = pos;
        
    }
}
