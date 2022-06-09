using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
  
    private Animator anim;
    private Rigidbody2D body;
    private GameSession gs;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = Random.Range(0.2f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Rocket" || target.gameObject.tag.Equals("RedBullet") || target.gameObject.tag.Equals("Player"))
        {

            anim.SetBool("Destroy", true);
            
            GameObject.Find("ExplosionSound").GetComponent<AudioSource>().Play();
            Destroy(gameObject, 1f);
        }
    }

    
}
