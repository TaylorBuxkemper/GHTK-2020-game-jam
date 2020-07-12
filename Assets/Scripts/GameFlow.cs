using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour {
    public float startDelay = 6f;
    public float gameSpeed = 1f;
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
        StartLevel(1);
        // transition to pink peeking through bud
        
        yield return new WaitForSeconds(15);
        StartLevel(2);
        // transition to bud peeling off rose flower

        yield return new WaitForSeconds(25);
        StartLevel(3);
        // transition to bud completely off 

        yield return new WaitForSeconds(35);
        StartLevel(4);
        // transition to rose flower poofed up
    }

    private void StartLevel(int level) {
        switch (level) {
            case 1:
                gameSpeed = 1.25f;
                break;
            case 2:
                gameSpeed = 1.5f;
                
                break;
            case 3:
                gameSpeed = 2f;
                break;
            case 4:
                StartCoroutine(ContinuouslyIncreaseGameSpeed());
                break;
        }
    }

    private IEnumerator ContinuouslyIncreaseGameSpeed() {
        while (Rose.I.isAlive) {
            gameSpeed += .01f;
            yield return null;
        }
    }
}
