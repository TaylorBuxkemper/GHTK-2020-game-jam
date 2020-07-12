using System.Collections;
using UnityEngine;

public class Rose : SingletonBehaviour<Rose>
{
    public float targetTransitionHeight = 2f;

    public bool isAlive = true;
    
    private float _canvasScale = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _canvasScale = GetComponentInParent<Canvas>().transform.localScale.x;
    }
    
    public IEnumerator StartOpeningSequence(float gameStartDelay) {
        var transitionDuration = gameStartDelay / 3;
        yield return new WaitForSeconds(transitionDuration);
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float distanceToMoveUpThisFrame =
                Mathf.Lerp(0, targetTransitionHeight, elapsedTime / transitionDuration);
            transform.position = new Vector3(transform.position.x, distanceToMoveUpThisFrame * _canvasScale, transform.position.z);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, targetTransitionHeight * _canvasScale, transform.position.z);
        yield return new WaitForSeconds(transitionDuration);
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        while (isAlive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .05f, transform.position.z);
            yield return null;
        }
    



}
}
