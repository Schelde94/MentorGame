using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class LevelEntry : MonoBehaviour
{

    

    BoxCollider2D myEntry;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myEntry = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DoorStatus();
        DoorTrigger();
        
    }

    private void DoorStatus()
    {
        int leverSwitches = FindObjectOfType<GameSession>().GetComponent<GameSession>().leverSwitches;
        if (this.tag == "Lever1" && leverSwitches >= 1)
        {
            this.myAnimator.SetTrigger("OpenDoor");
            this.myEntry.enabled = true;

        }
        else if (this.tag == "Lever2" && leverSwitches >= 2)
        {
            this.myAnimator.SetTrigger("OpenDoor");
            this.myEntry.enabled = true;
        }
        else if (this.tag == "Lever3" && leverSwitches > 2)
        {
            this.myAnimator.SetTrigger("OpenDoor");
            this.myEntry.enabled = true;
        }
        else
        {
            this.myEntry.enabled = false;
        }
        
    }

    private void DoorTrigger()
    {
        
        if (this.enabled)
        {
            if (this.myEntry.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                if (CrossPlatformInputManager.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
                {
                    print("Open door");
                    if (this.tag == "Lever1")
                    {
                        EnterLevel(1);
                    }
                    else if (this.tag == "Lever2")
                    {
                        EnterLevel(2);
                    }
                    else if (this.tag == "Lever3")
                    {
                        EnterLevel(3);
                    }
                }
            }
            
        }
    }

    private void EnterLevel(int sceneNumber)
    {
        
        SceneManager.LoadScene(sceneNumber);
    }
}
