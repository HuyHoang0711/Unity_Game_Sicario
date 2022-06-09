using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField] int scoreNeedToAttack = 0;
    [SerializeField] GameObject smoke;
    [SerializeField] GameObject boss;
    [SerializeField] float posXSmoke = 0f;
    [SerializeField] float posYSmoke = 0f;
    int countSmoke = 0;
    int countBoss = 0;
   // private bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Attack();   
    }
    public void Attack()
    {
         GameSession gs = FindObjectOfType<GameSession>();
        
        if(gs != null)
        {
            if(gs.GetScore() >= scoreNeedToAttack)
            {
                if (FindObjectOfType<Smoke>() == null)
                {
                    if (countSmoke == 0)
                    {
                        Instantiate(smoke, new Vector2(posXSmoke, posYSmoke), Quaternion.identity);
                        countSmoke++;
                    }
                }
                
                   
                    if (FindObjectOfType<Smoke>() == null)
                    {
                    if (FindObjectOfType<BossX>() == null)
                    {
                        if (countBoss == 0)
                        {
                            Instantiate(boss, new Vector2(posXSmoke, posYSmoke), Quaternion.identity);
                            countBoss++;
                        }
                    }
                    }
                
            }    
            
        }    
    }  
    public int GetScoreNeedAttack()
    {
        return this.scoreNeedToAttack;
    }
}
