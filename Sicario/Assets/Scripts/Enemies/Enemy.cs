using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Status")]
    [SerializeField] int scoreValue = 150;
    [SerializeField] int health = 5;
    private DamageDealer dealer;
    [Header("Enemy Shoot")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;

    [Header("Enemy Effects")]
    [SerializeField] GameObject destroyEffect;
    [SerializeField] float durationOfEffect = 1f;

    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolumn = 0.7f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolumn = 0.25f;

    [Header("Items")]
    [SerializeField]
    List<GameObject> items;
    [SerializeField] static int numberOfEnemies = 20;
     static int currentNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShot();
    }
    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Shoot();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }    
    private void Shoot()
    {
        GameObject protile = Instantiate(projectile,  transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolumn);  
        protile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Shadder")
        {
            if (collision.tag.Equals("RedBullet") || collision.tag.Equals("Rocket") || collision.tag.Equals("Hole"))
            {
                dealer = collision.GetComponent<DamageDealer>();
                ExecuteHit();
            }
            if (collision.tag.Equals("Player"))
            {
                DestroyEnemy();
            }
        }
    }
    public void ExecuteHit()

    {
        health -= dealer.GetDamage();
        if (health <= 0)
        {
            DestroyEnemy();
            
        }
    }
    public void DestroyEnemy()
    {
        if(FindObjectOfType<GameSession>() != null)
        FindObjectOfType<GameSession>().SetScore(scoreValue);
        if (items.Count > 0)
        {
            if(Enemy.currentNumber % Enemy.numberOfEnemies == 0)
            Instantiate(items[Random.Range(0, items.Count)], gameObject.transform.position, Quaternion.identity);
            numberOfEnemies = Random.Range(15, 30);
          
        }
        Destroy(gameObject);
        currentNumber++;
        GameObject explo = Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(explo, durationOfEffect);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolumn);




    }

}
