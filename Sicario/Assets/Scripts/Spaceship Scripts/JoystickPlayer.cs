using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private Animator animator;
    private Rigidbody2D body;
    // Start is called before the first frame update
    private void setUpMoveBoundaries()
    {
       
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        setUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Move(float Horizontal, float Vertical)
    {

       

        var deltaX = Horizontal * Time.deltaTime * speed;
        var deltaY = Vertical * Time.deltaTime * speed;

       
        body.velocity = new Vector3(deltaX * 70, deltaY * 70);
    

        if (Horizontal > 0)
        {
            
      
            if (Vertical > 0.5 || Vertical < -0.5)
            {
                animator.SetBool("moveLeft", false);
                animator.SetBool("moveRight", false);
                animator.SetBool("move", true);
                
            }
            else
            {
                animator.SetBool("moveRight", true);
                animator.SetBool("moveLeft", false);
                animator.SetBool("move", false);
            }    

        }
        if (Horizontal < 0)
        {
            
            if (Vertical > 0.5 || Vertical < -0.5)
            {
                animator.SetBool("moveLeft", false);
                animator.SetBool("moveRight", false);
                animator.SetBool("move", true);
                

            }
            else
            {
                animator.SetBool("moveLeft", true);
                animator.SetBool("moveRight", false);
                animator.SetBool("move", false);
            }    
        }
       
       
        if (Vertical == 0 && Horizontal == 0)
        {
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", false);
            animator.SetBool("move", false);
           return;
        }
  
    }
        
}
