using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreCounter : SingletonBehaviour<ScoreCounter> {
    public static int highScore = 0;
    public int score = 0;

    public void StartCountingScore() {
        StartCoroutine(CountScore());
    }

    private IEnumerator CountScore() {
        while (Rose.I.isAlive) {
            yield return new WaitForSeconds(1);
            GetComponent<Text>().text = "Current Height " + ++score;
        }

        highScore = score;
    }
}
