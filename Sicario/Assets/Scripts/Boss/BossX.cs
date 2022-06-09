using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossX : MonoBehaviour
{
    // Start is called before the first frame update
    List<Transform> pathBoss;
    [SerializeField] GameObject wayBoss;
    int currentPath = 0;
    [SerializeField] float speedMove = 5f;
    [SerializeField] List<GameObject> listOfBullets;
    [SerializeField] AudioClip shootSound;
    [SerializeField] GameObject destroyEffect;
    private float durationOfEffect = 0.7f;
    [SerializeField] float shootSoundVolumn = 0.5f;
    [SerializeField]
    int health = 0;
    [SerializeField] float timeWaitNextShoot = 0.5f;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolumn = 0.7f;
    private DamageDealer dealer;
    Coroutine firing;
    [SerializeField] int scoreValue = 500;
    
    Text textHealth;
    float heSo = 0;
    
   
    private void Awake()
    {
       
        pathBoss = new List<Transform>();
        foreach (Transform item in wayBoss.transform)
        {
            pathBoss.Add(item);
        }
    }
    void Start()
    {
        Fire();
      //  health = Random.Range(1500, 3000);
        textHealth = GetComponentInChildren<Text>();
        textHealth.text = "HP: " + health;

       
    }

    // Update is called once per frame
    void Update()
    {

        BossMove();
      

    }
    public void BossMove()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = pathBoss[currentPath].position;
        if(currentPath < pathBoss.Count - 1)
        {
            transform.position = Vector2.MoveTowards(currentPos, targetPos, speedMove * Time.deltaTime);
            Vector2 current = transform.position;
            
            if (current == targetPos)
                currentPath++;
        }
        else
        {
          pathBoss.Reverse();
            currentPath = 0;
        }
       

    }
    public void Fire()
    {

        firing = StartCoroutine(ShootContinuous());
    }
    IEnumerator ShootContinuous()
    {
        while (true)
        {
            Vector2 left = transform.position;
            foreach (var item in listOfBullets)
            {
                
                GameObject bullet = Instantiate(item, left + new Vector2(heSo, 0), Quaternion.identity) as GameObject;
               
                //GameObject bulletL = Instantiate(bulletLeft, left + new Vector2(1f, 0), Quaternion.identity) as GameObject;
              //  GameObject bulletR = Instantiate(bulletRight, left + new Vector2(-1f, 0), Quaternion.identity) as GameObject;
                //bullet.transform.Rotate(new Vector3(0, 0, 1), 90f);
              //  AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolumn);
              //  bulletL.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
              //  bulletR.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                heSo += Random.Range(-2f, 2f); 
              
                
            }
            yield return new WaitForSeconds(timeWaitNextShoot);
            heSo = 0;
          

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("RedBullet") || collision.tag.Equals("Rocket") || collision.tag.Equals("Rocket"))
        {
            dealer = collision.GetComponent<DamageDealer>();
            ExecuteHit();
            textHealth.text = "HP: " + health;

        }
        if (collision.tag.Equals("Player"))
        {
            DestroyEnemy();
        }
    }
    public void ExecuteHit()

    {
        health -= dealer.GetDamage();
        
        if (health <= 0)
        {
            DestroyEnemy();
            FindObjectOfType<Level>().SetLoadLevel(true);

        }
    }
   
    public void DestroyEnemy()
    {
        FindObjectOfType<GameSession>().SetScore(scoreValue);

        Destroy(gameObject);

        GameObject explo = Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(explo, durationOfEffect);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolumn);




    }
    public float GetBulletSpeed()
    {
        return this.bulletSpeed;
    }
}
