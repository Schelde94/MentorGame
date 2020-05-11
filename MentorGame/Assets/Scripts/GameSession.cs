using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] float LevelLoadDelay = 1f;
    [SerializeField] public int leverSwitches = 0;

    private void Awake()
    {
        int numbGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numbGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            StartCoroutine(TakeLife());
        }
        else
        {
            StartCoroutine(ResetGameSession());
        }
    }

    private IEnumerator TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene(currentSceneIndex);
    }


    private IEnumerator ResetGameSession()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void ProcessLeverSwitch()
    {
        //print(leverSwitches);
        leverSwitches++;
        print("Lever count = " + leverSwitches);
    }
}
