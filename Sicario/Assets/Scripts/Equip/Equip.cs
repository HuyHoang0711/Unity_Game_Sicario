using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    Coroutine firing;
    Coroutine shoot;
    [SerializeField]
    private GameObject redBullet;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolumn = 0.25f;
    private float timeWaitNextShoot = 0.1f;
    [SerializeField]
    private float timeToDestroy = 15f;
    float heSoX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 currentPos = transform.position;
        transform.position = Vector2.MoveTowards(currentPos, currentPos + new Vector2(heSoX, 0), 0.001f * Time.deltaTime);
       shoot = StartCoroutine(Shoot());
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<spaceship>() != null)
        {
            transform.position = FindObjectOfType<spaceship>().transform.position + new Vector3(heSoX, 0, 0);
        }
        else
        {
            //StopCoroutine(shoot);
           //StopCoroutine(firing);
            Destroy(gameObject);
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.7f);
        firing = StartCoroutine(ShootContinuous());

    }

    public void StopShoot()
    {
        StopCoroutine(firing);

    }

    IEnumerator ShootContinuous()
    {
        while (true)
        {

            GameObject bullet = Instantiate(redBullet, transform.position, Quaternion.identity) as GameObject;
           
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolumn);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
            yield return new WaitForSeconds(timeWaitNextShoot);
               
         }

    }
    public void SetHeSoX(float x)
    {
        this.heSoX = x;
    }
    
}
