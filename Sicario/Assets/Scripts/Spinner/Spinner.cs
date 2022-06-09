using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speedOfSpin = 1f;
    [SerializeField] float needRotate = 0f;
    void Start()
    {
        if(needRotate != 0)
        {
            transform.Rotate(new Vector3(0, 0, needRotate));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }
}
