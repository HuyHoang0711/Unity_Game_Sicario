using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoystickControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    spaceship sship;
    Level level;
    public void OnPointerDown(PointerEventData eventData)
    {
       if(gameObject.name == "FireButton")
        {
           if(sship != null)
            sship.ShootWithButton();
        }
        if (level != null)
        {
            if (gameObject.name == "StartButton")
            {

                level.LoadGame();
            }
            if (gameObject.name == "QuitButton")
            {
                level.QuitGame();
            }
            if(gameObject.name == "PlayButton")
            {
                level.LoadGame();
            }    
            if(gameObject.name == "MainMenu")
            {
                level.LoadStartMenu();
            }    
        }
        if(gameObject.name.Equals("RocketButton"))
        {
            if (sship != null)
                sship.isFire();
        }    
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (gameObject.name == "FireButton")
        {
            if (sship != null)
                sship.StopShootButton();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sship = FindObjectOfType<spaceship>();
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
