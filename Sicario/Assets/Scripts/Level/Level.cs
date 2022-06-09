using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    [SerializeField] float delaySeconds = 2f;
    [SerializeField] string nextLevel;
    [SerializeField] float TimeWaitLoad = 5f;
    int currentScore;
    private bool isLoadLevel = false;
    private void Start()
    {
        if(SceneManager.GetActiveScene().name.Equals("StartMenu") || SceneManager.GetActiveScene().name.Equals("Game"))
        {
            GameSession.score = 0;
        }    
    }
    public void LoadStartMenu()
    {
      
        SceneManager.LoadScene(0);
       // GameSession.score = 0;
    }
    public void LoadGame()
    {
        GameSession gs = FindObjectOfType<GameSession>();
        if (gs != null)
            gs.ResetGame();
       
        SceneManager.LoadScene("Game");
       // GameSession.score = 0;

    }    
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }    
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("GameOver");
    }    
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadLevel()
    {
       
            FindObjectOfType<GameSession>().ResetGame();

            StartCoroutine(LoadNextLevel());
        
            
    }
    IEnumerator LoadNextLevel()
    {

        yield return new WaitForSeconds(TimeWaitLoad);
       
        SceneManager.LoadScene(nextLevel);
       

    }
    public void SetLoadLevel(bool isLoad)
    {
        isLoadLevel = isLoad;
    }
    public void Update()
    {
        if(FindObjectOfType<spaceship>() == null && SceneManager.GetActiveScene().name != "GameOver" 
          && SceneManager.GetActiveScene().name != "StartMenu" && SceneManager.GetActiveScene().name != "WinGame")
        {
            LoadGameOver();
        }    
        if(isLoadLevel && FindObjectOfType<Enemy>() == null)
        {
            
            LoadLevel();
            isLoadLevel = false;
        }    
    }
}
