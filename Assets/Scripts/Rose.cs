using System.Collections;
using UnityEngine;

public class Rose : MonoBehaviour
{    
    public float gameStartDelay = 2;
    public float startTransitionDuration = .5f;
    public float targetTransitionHeight = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(gameStartDelay);
        float elapsedTime = 0;

        while (elapsedTime < startTransitionDuration)
        {
            elapsedTime += Time.deltaTime;
            
            // TODO: use scale of canvas to move the image
            float distanceToMoveUpThisFrame =
                Mathf.Lerp(0, targetTransitionHeight, elapsedTime / startTransitionDuration);
            transform.position = new Vector3(transform.position.x, distanceToMoveUpThisFrame, transform.position.z);
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, targetTransitionHeight, transform.position.z);
    }
}
