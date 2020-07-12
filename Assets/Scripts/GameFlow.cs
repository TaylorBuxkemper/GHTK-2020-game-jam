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
        StartCoroutine(WaitForGameToStart());

    }

    private IEnumerator WaitForGameToStart() {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame() {
        yield return new WaitForSeconds(5);
    }
}
