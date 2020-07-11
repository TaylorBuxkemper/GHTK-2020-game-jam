using System.Collections;
using UnityEngine;

public class Rose : MonoBehaviour
{    
    public float gameStartDelay = 2;
    public float startTransitionDuration = .5f;
    public float targetTransitionHeight = 2f;

    public bool isAlive = true;
    
    private float _canvasScale = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _canvasScale = GetComponentInParent<Canvas>().transform.localScale.x;
        StartCoroutine(StartOpeningSequence());
    }
    private IEnumerator StartOpeningSequence()
    {
        yield return new WaitForSeconds(gameStartDelay);
        float elapsedTime = 0;

        while (elapsedTime < startTransitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float distanceToMoveUpThisFrame =
                Mathf.Lerp(0, targetTransitionHeight, elapsedTime / startTransitionDuration);
            transform.position = new Vector3(transform.position.x, distanceToMoveUpThisFrame * _canvasScale, transform.position.z);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, targetTransitionHeight * _canvasScale, transform.position.z);
        yield return new WaitForSeconds(gameStartDelay);
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        while (isAlive == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .05f, transform.position.z);
            yield return null;
        }
    



}
}
