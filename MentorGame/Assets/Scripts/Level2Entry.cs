using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Level2Entry : MonoBehaviour
{

    [SerializeField] float LevelLoadDelay = 1f;

    BoxCollider2D myEntry;

    // Start is called before the first frame update
    void Start()
    {
        myEntry = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelEntry();
        EnterLevel();
    }

    private void LevelEntry()
    {
        if (myEntry.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (CrossPlatformInputManager.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
            {

                StartCoroutine(EnterLevel());
            }
        }
    }

    IEnumerator EnterLevel()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene(2);
    }
}
