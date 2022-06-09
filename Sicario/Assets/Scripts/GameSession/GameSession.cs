using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
   
    public static int score = 0;
   
    // Start is called before the first frame update
    private void Awake()
    {

        SetUpSingleton();
    }
    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }    
        else
        {
            DontDestroyOnLoad(gameObject);
        }    
    }    
    public int GetScore()
    {
        return score;
    }    
    public void SetScore(int scoreValue)
    {
        
        score += scoreValue;
     
       
    }    
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public void Update()
    {
        var boss = FindObjectOfType<Boss1>();
        if(boss != null)
        {
            if (score == boss.GetScoreNeedAttack())
            {
                EnemiesSpawn es = FindObjectOfType<EnemiesSpawn>();
                if (es != null)
                    es.setLooping(false);
            }
        }
    }
 
}
