using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Rose : MonoBehaviour
{    
    public float gameStartDelay = 2;
    public float startTransitionDuration = .5f;
    
    // Start is called before the first frame update
    void Start()
    {
        // wait 2 seconds
        // show rose bud on screen
        //
        StartCoroutine(StartGame());
    }


    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(gameStartDelay);
        float elapsedTime = 0;

        while (elapsedTime < startTransitionDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = new Vector3(transform.position.x,elapsedTime,transform.position.z);
            
            yield return null;
        }

    }


}
