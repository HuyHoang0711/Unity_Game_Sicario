using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExploDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ExploDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
