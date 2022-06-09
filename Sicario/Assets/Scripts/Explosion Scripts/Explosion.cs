using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private float posX, posY;
    private Vector2 pos;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPos(float x, float y)
    {
        pos = transform.position;
        pos.x = x;
        pos.y = y;
        transform.position = pos;
    }
    public void Des()
    {
        Destroy(gameObject);
    }
}
