using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    public float forceY = 0.5f;
    private bool isInBigRocket = false;
    private float heSo = 0f;
    private float previousPosX = 0f;
    private float stepX = 0f;
    [SerializeField] float speed = 10f;
    //private GameObject explosion;
    //private Vector2 pos;
    // Start is called before the first frame update
    private void Awake()
    {
       transform.position = GameObject.Find("spaceship").transform.position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (FindObjectOfType<BossX>() != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, FindObjectOfType<BossX>().transform.position, speed * Time.deltaTime);
        }
        else
        {
            if (FindObjectsOfType<Enemy>().Length != 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, FindObjectsOfType<Enemy>()[0].transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        }  

        

    }
    public void SetIsInBigRocket(bool inBig)
    {
        this.isInBigRocket = inBig;
    }
    public void SetHeSo(float heSo)
    {
        this.heSo = heSo;
    }
    public float GetHeSo()
    {
        return this.heSo;
    }
    public void SetStepX(float stepX)
    {
        this.stepX = stepX;
    }    
    public void SetPreviousPosX(float prePosX)
    {
        this.previousPosX = prePosX;
    }    
    
    public void OnTriggerEnter2D(Collider2D target)
    { 
        
        if (target.gameObject.tag.Equals("Enemy") || target.gameObject.tag.Equals("Boss"))
        {            
            Destroy(gameObject);

        }
        
        
        
    }
    





}
