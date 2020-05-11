using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{

    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LeverStatus();
    }

    private void LeverStatus()
    {
        int leverSwitches = FindObjectOfType<GameSession>().GetComponent<GameSession>().leverSwitches;
        if (this.tag == "Lever1" && leverSwitches >= 1)
        {
            LeverTrigger();
        }
        else if (this.tag == "Lever2" && leverSwitches >= 2)
        {
            LeverTrigger();
        }
        else if (this.tag == "Lever3" && leverSwitches > 2)
        {
            LeverTrigger();
        }
    }

    private void LeverTrigger()
    {
        this.myAnimator.SetTrigger("Switch");
        this.enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (this.enabled)
        {
            print("Collision!");
            this.enabled = false;
            myAnimator.SetTrigger("Switch");
            FindObjectOfType<GameSession>().ProcessLeverSwitch();
        }
        
    }
}
