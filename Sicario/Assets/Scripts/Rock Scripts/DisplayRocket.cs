using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayRocket : MonoBehaviour
{
    Text rocketText;
    spaceship sship;
    // Start is called before the first frame update
    void Start()
    {
        rocketText = GetComponent<Text>();
        sship = FindObjectOfType<spaceship>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sship != null)
        rocketText.text = "ROCKET: " + sship.GetRocket().ToString();
    }
}
