using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField] string nameItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            Destroy(gameObject);
        }
    }
    public string GetNameItem()
    {
        return nameItem;
    }    
}
