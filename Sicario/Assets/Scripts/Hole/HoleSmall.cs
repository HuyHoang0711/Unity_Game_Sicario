using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSmall : MonoBehaviour
{
    [SerializeField] float speedHoleSmall = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 12f);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Enemy>() != null)
        {
            Enemy ene = FindObjectsOfType<Enemy>()[FindObjectsOfType<Enemy>().Length - 1];
            transform.position = Vector2.MoveTowards(transform.position, ene.transform.position, speedHoleSmall * Time.deltaTime);
        }
        if(FindObjectOfType<spaceship>() == null)
        {

            Destroy(gameObject);
        }
    }
}
