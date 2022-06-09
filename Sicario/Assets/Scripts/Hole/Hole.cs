using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] float speedHole = 3f;
    [SerializeField] float TimeToDestroy = 15f;
    [SerializeField] GameObject holeSmall;
  
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeToDestroy);
        Instantiate(holeSmall, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<Enemy>() != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, FindObjectsOfType<Enemy>()[0].transform.position, speedHole * Time.deltaTime);
        }
        if (FindObjectOfType<spaceship>() == null)
        {

            Destroy(gameObject);
        }
    }
}
