using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Grass : MonoBehaviour, IPointerClickHandler
{
    public float growthSpeed = 1;
    
    private float _canvasScale = 1;

    void Start()
    {
        _canvasScale = GetComponentInParent<Canvas>().transform.localScale.x;
        //GetComponent<Image>().alphaHitTestMinimumThreshold = .99f;
        StartCoroutine(StartGrowing());
    }
    
    private IEnumerator StartGrowing() {
        growthSpeed = 1 / GameFlow.I.gameSpeed;
        float growthDuration = 10 * GameFlow.I.gameSpeed;

        float elapsedTime = 0;
        
        while (Rose.I.isAlive) {
            yield return null;
            if (Time.timeScale < .001) continue; // game paused
            
            elapsedTime += Time.deltaTime;

            var targetPosition = Mathf.Lerp(0, Rose.I.transform.position.y / _canvasScale + 10, elapsedTime / growthDuration);
            transform.position = new Vector3(transform.position.x, targetPosition, transform.position.z);
            if (transform.position.y > Rose.I.transform.position.y) {
                Rose.I.isAlive = false;
                GameFlow.I.Stop();
            }
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
