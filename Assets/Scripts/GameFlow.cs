using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : SingletonBehaviour<GameFlow> {
    public float startDelay = 6f;
    public float gameSpeed = 1f;

    private Coroutine _gameFlowRoutine;
    private Coroutine _increaseDifficultyRoutine;
    private Coroutine _spawnEnemiesRoutine;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameFlowRoutine = StartCoroutine(StartGame());
    }

    public void Stop() {
        StopCoroutine(_gameFlowRoutine);
        StopCoroutine(_increaseDifficultyRoutine);
        StopCoroutine(_spawnEnemiesRoutine);
    }
    
    private IEnumerator StartGame() {
        // wait a frame to allow all other Start to finish
        yield return null;
        
        // start game with bud on a stem
        Rose.I.StartCoroutine(Rose.I.StartOpeningSequence(startDelay));
        yield return new WaitForSeconds(startDelay);
        
        // transition to pink peeking through bud
        gameSpeed = .85f;
        _spawnEnemiesRoutine = StartCoroutine(SpawnEnemies());
        yield return new WaitForSeconds(15);
        
        // transition to bud peeling off rose flower
        gameSpeed = .65f;
        yield return new WaitForSeconds(25);

        // transition to bud completely off 
        gameSpeed = .4f;
        yield return new WaitForSeconds(35);

        // transition to rose flower poofed up
        _increaseDifficultyRoutine = StartCoroutine(ContinuouslyIncreaseGameSpeed());
    }

    private IEnumerator SpawnEnemies() {
        while (Rose.I.isAlive) {
            GrassManager.I.SpawnGrass();
            yield return new WaitForSeconds(Random.Range(gameSpeed * .8f, gameSpeed * 1.2f));
        }
    }

    private IEnumerator ContinuouslyIncreaseGameSpeed() {
        while (Rose.I.isAlive) {
            gameSpeed *= .99f;
            yield return new WaitForSeconds(.25f);
        }
    }
}
