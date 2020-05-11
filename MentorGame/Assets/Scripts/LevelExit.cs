using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    [SerializeField] float LevelLoadDelay = 1f;

    BoxCollider2D myExit;

    // Start is called before the first frame update
    void Start()
    {
        myExit = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelClear();
        ExitLevel();
    }

    private void LevelClear()
    {
        if (myExit.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            //print("Player touched exit");


            if (CrossPlatformInputManager.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
            {
                print("Player jumped");
                StartCoroutine(ExitLevel());
            }
        }
    }

    IEnumerator ExitLevel()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene(0);
    }
}
