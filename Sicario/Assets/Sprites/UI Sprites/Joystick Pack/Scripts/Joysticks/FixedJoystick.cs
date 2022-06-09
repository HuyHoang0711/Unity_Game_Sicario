using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    private JoystickPlayer joystickPlayer;
    protected override void Start()
    {
        base.Start();
        joystickPlayer = FindObjectOfType<JoystickPlayer>();
    }
   
    public void Update()
    {
        if(joystickPlayer != null)
        joystickPlayer.Move(this.Horizontal, this.Vertical);
      
        
    }

}