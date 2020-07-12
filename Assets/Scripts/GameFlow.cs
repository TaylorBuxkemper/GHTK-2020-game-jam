using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour {
    public float startDelay = 6f;
    public int test;
    public Texture rose;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(rose.name);
        StartCoroutine(StartGame());

    }

    private IEnumerator StartGame() {
        // start game with bud on a stem
        
        yield return new WaitForSeconds(startDelay);
        // transition to pink peeking through bud
        
        yield return new WaitForSeconds(15);
        // transition to bud peeling off rose flower

        yield return new WaitForSeconds(25);
        // transition to bud completely off 

        yield return new WaitForSeconds(35);
        // transition to rose flower poofed up
    }
    
    
}
