using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeathDisplay : MonoBehaviour
{
    
    Text healthText;
    spaceship sship;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        sship = FindObjectOfType<spaceship>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sship != null)
        healthText.text = "HP: " + sship.GetHealth().ToString();
    }
}
