using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 firstPos;
    int typeShoot = 0;
    void Awake()
    {
        typeShoot = Random.Range(1, 7);
    }
    void Start()
    {
        if (FindObjectOfType<spaceship>() != null)
            firstPos = FindObjectOfType<spaceship>().transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectsOfType<BossX>().Length > 0)
        {
            if (FindObjectOfType<spaceship>() != null)
            {
                    ShootToSpaceship();           
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (FindObjectOfType<BossX>() == null)
            Destroy(gameObject);
    }
    public void ShootToSpaceship()
    {
        transform.position = Vector2.MoveTowards(transform.position, firstPos + new Vector2(0f, -50f), FindObjectOfType<BossX>().GetBulletSpeed() * Time.deltaTime);    
    }
    public void SetTypeShoot(int type)
    {
        typeShoot = type;    
    }
}
