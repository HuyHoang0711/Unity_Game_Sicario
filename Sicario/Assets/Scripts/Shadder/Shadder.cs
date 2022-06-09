using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadder : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(collision.gameObject);
    }
}
