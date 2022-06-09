using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    [SerializeField] GameObject spaceship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
           
            if (FindObjectOfType<spaceship>() != null)
                transform.position = FindObjectOfType<spaceship>().transform.position + new Vector3(0, 0.5f, 0);
          
    }
   
}
