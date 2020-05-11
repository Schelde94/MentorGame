using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    [SerializeField] float FallingPlatformDelay = 1f;

    // Cached component references
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(PlatformFall());
    }
    
    

    private IEnumerator PlatformFall()
    {
        yield return new WaitForSecondsRealtime(FallingPlatformDelay);
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSecondsRealtime(FallingPlatformDelay);
        myRigidBody.bodyType = RigidbodyType2D.Static;
    }
}
