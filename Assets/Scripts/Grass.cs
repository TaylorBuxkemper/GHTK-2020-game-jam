using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Grass : MonoBehaviour, IPointerClickHandler
{
    public float GrowthDuration = 10f;
    public float GrowthHeight = 2000f;
    public float growthSpeed = 1;
    
    private float _canvasScale = 1;

    void Start()
    {
        _canvasScale = GetComponentInParent<Canvas>().transform.localScale.x;
        GetComponent<Image>().alphaHitTestMinimumThreshold = .001f;
        StartCoroutine(StartGrowing());
    }
    
    private IEnumerator StartGrowing() {
        growthSpeed = GameFlow.I.gameSpeed;
        while (Rose.I.isAlive) {
            transform.position = new Vector3(transform.position.x, transform.position.y + growthSpeed / 10, transform.position.z);
            if (transform.position.y > Rose.I.transform.position.y) {
                Rose.I.isAlive = false;
                GameFlow.I.Stop();
            }
            yield return null;
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
