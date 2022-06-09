using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField]
    private float speed = 10f;
  
    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private GameObject bigRocket;
    [SerializeField]
    private int health = 200;
    private bool isBigRocket = false;
    private int countRocket = 0;
    private float heSo = 0f;
    private float xMax;
    private float xMin;
    private float yMax;
    private float yMin;
    [SerializeField]
    private float padding = 1f;
    private float timeWaitNextShoot = 0.1f;
    // private Rigidbody2D rigid;

    // Start is called before the first frame update
    [Header("Projectile")]
    [SerializeField]
    private GameObject redBullet;
    [SerializeField] private float bulletSpeed = 10f;
   
    Coroutine firing;
    [Header("Explosion")]
    [SerializeField] GameObject explosion;

    [Header("Sound")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolumn = 0.7f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolumn = 0.25f;
    [SerializeField] AudioClip itemSound;
    [SerializeField] [Range(0, 1)] float itemSoundVolumn = 0.25f;
    private Joystick joystick;
    [Header("Aura")]
    [SerializeField] GameObject aura;
    private bool isImmortal = false;
    private int numberOfRockets = 3;
    private int numberOfBullet = 1;
    [Header("Equip")]
    [SerializeField] GameObject equipLeft;
    [SerializeField] float posXLeft = -1f;
    [SerializeField] GameObject equipRight;
    [SerializeField] float posXRight = 1f;
    [Header("Holes")]
    [SerializeField]
    List<GameObject> listOfHoles;
    private void setUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }    
    void Start()
    {
        setUpMoveBoundaries();
        joystick = FindObjectOfType<Joystick>();
       // gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    private void bulletMove()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
        if(FindObjectOfType<Aura>() == null)
        {
            isImmortal = false;
        }
       

    }
    public int GetHealth()
    {
        if (health < 0)
            return 0;
        else
        return health;
    }    
    public void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        var deltaX = h * Time.deltaTime * speed;
        var deltaY = v * Time.deltaTime * speed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);

    }
    public void isFire()
    {
        if (numberOfRockets > 0)
        {
            Instantiate(rocket, transform.position, Quaternion.identity);
            GameObject.Find("RocketSound").GetComponent<AudioSource>().Play();
            numberOfRockets--;
        }
    }
    IEnumerator CreateRocket()
    {
        float gravity = 0.1f;
        heSo = 0f;
        float stepX = 0.1f;
        for (int i = 0; i < 5; i++)
        {
            GameObject rocketx = Instantiate(rocket, bigRocket.transform.position, Quaternion.identity);
            // rocketx.transform.position += new Vector3(gravity, 0, 0);
            rocketx.GetComponent<Rocket>().SetIsInBigRocket(true);
            heSo = 0.01f;
            rocketx.GetComponent<Rocket>().SetHeSo(heSo);
            rocketx.GetComponent<Rocket>().SetStepX(stepX);
            rocketx.GetComponent<Rocket>().SetPreviousPosX(rocketx.transform.position.x);
            // gravity += 0.3f;
            yield return new WaitForSeconds(0.1f);
            stepX += 0.01f;
        }

    }
    IEnumerator Implement(GameObject rocketx)
    {
        yield return new WaitForSeconds(2f);

        heSo += 0.2f;
        rocketx.GetComponent<Rocket>().SetHeSo(heSo);

        rocketx.GetComponent<Rocket>().SetIsInBigRocket(true);
    }
    public void Shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            firing = StartCoroutine(ShootContinuous());
        }
        if (Input.GetKeyUp("space"))
        {
            StopCoroutine(firing);
        }
    }
    public void ShootWithButton()
    {

        firing = StartCoroutine(ShootContinuous());
    }
    public void StopShootButton()
    {
        StopCoroutine(firing);

    }
    public int GetRocket()
    {
        return this.numberOfRockets;
    }
    IEnumerator ShootContinuous()
    {
        while (true)
        {
            if (numberOfBullet == 1)
            {
                GameObject bullet = Instantiate(redBullet, transform.position, Quaternion.identity) as GameObject;
                //bullet.transform.Rotate(new Vector3(0, 0, 1), 90f);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolumn);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                yield return new WaitForSeconds(timeWaitNextShoot);
            }
            else if(numberOfBullet == 2)
            {
                Vector2 left = transform.position;
                GameObject bulletLeft = Instantiate(redBullet, left + new Vector2(0.2f, 0), Quaternion.identity) as GameObject;
                GameObject bulletRight = Instantiate(redBullet, left + new Vector2(-0.2f, 0), Quaternion.identity) as GameObject;
                //bullet.transform.Rotate(new Vector3(0, 0, 1), 90f);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolumn);
                bulletLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                bulletRight.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                yield return new WaitForSeconds(timeWaitNextShoot);
            }  
            else if(numberOfBullet >= 3)
            {
                Vector2 left = transform.position;
                GameObject bullet = Instantiate(redBullet, left, Quaternion.identity) as GameObject;
                GameObject bulletLeft = Instantiate(redBullet, left + new Vector2(0.2f, 0), Quaternion.identity) as GameObject;
                GameObject bulletRight = Instantiate(redBullet, left + new Vector2(-0.2f, 0), Quaternion.identity) as GameObject;
                //bullet.transform.Rotate(new Vector3(0, 0, 1), 90f);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolumn);
                bulletLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                bulletRight.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                yield return new WaitForSeconds(timeWaitNextShoot);
            }    
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != ("RedBullet") && collision.tag != ("Rocket") && 
            collision.tag != "item" && collision.tag != "Hole")
        {
            if (!isImmortal)
            {
                StartCoroutine(ChangeColor());
                DamageDealer dealer = collision.GetComponent<DamageDealer>();
                ExecuteHit(dealer);
            }
        }
        if(collision.tag == "item")
        {
            if(collision.GetComponent<item>().GetNameItem().Equals("AddBullet"))
            numberOfBullet++;
            if(collision.GetComponent<item>().GetNameItem().Equals("Flower"))
            {
                if (FindObjectOfType<Aura>() == null)
                {
                    GameObject aur = Instantiate(aura, transform.position, Quaternion.identity);
                    isImmortal = true;
                    Destroy(aur, 15f);
                   
                }
            }
            if(collision.GetComponent<item>().GetNameItem().Equals("AddHP"))
            {
                
                health += 20;
                if (health > 100)
                    health = 100;
            }    
            if(collision.GetComponent<item>().GetNameItem().Equals("AddRocket"))
            {
                numberOfRockets++;
            }
            if(collision.GetComponent<item>().GetNameItem().Equals("Machine"))
            {
                if(FindObjectOfType<Equip>() == null)
                EquipMachine();
            }
            if (collision.GetComponent<item>().GetNameItem().Equals("Hole"))
            {
                if (FindObjectOfType<Hole>() == null)
                    HoleAttack();
            }
            AudioSource.PlayClipAtPoint(itemSound, Camera.main.transform.position, itemSoundVolumn);
        }   
        
    }
    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.26f, 0.26f);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }    
    public void HoleAttack()
    {
        Instantiate(listOfHoles[Random.Range(0, listOfHoles.Count)], transform.position, Quaternion.identity);
    }
    public void EquipMachine()
    {
        GameObject machineLeft = Instantiate(equipLeft, transform.position, Quaternion.identity);
        machineLeft.GetComponent<Equip>().SetHeSoX(posXLeft);
        GameObject machineRight = Instantiate(equipRight, transform.position, Quaternion.identity);
        machineRight.GetComponent<Equip>().SetHeSoX(posXRight);
    }
    public void ExecuteHit(DamageDealer dealer)
    {
       
            health -= dealer.GetDamage();
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolumn);
           // FindObjectOfType<Level>().LoadGameOver();


        }
    }
    public bool GetImmortal()
    {
        return isImmortal;
    }    


}
