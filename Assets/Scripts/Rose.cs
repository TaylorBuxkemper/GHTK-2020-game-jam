using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Rose : SingletonBehaviour<Rose>
{
    public float targetTransitionHeight = 125f;
    public bool isAlive = true;
    public List<Sprite> roseSprites;
    public List<float> targetHeights;
    
    public Image newRoseImage;
    private Image _roseImage;
    
    private int _currentGrowthStage = 0;
    private float _canvasScale = 1;
    private float startingTransitionHeight;

    void Start() {
        _roseImage = GetComponent<Image>();
        _canvasScale = GetComponentInParent<Canvas>().transform.localScale.x;
    }
    
    public IEnumerator StartOpeningSequence(float gameStartDelay) {
        var transitionDuration = gameStartDelay / 3;
        yield return new WaitForSeconds(transitionDuration);
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration) {
            elapsedTime += Time.deltaTime;
            float distanceToMoveUpThisFrame =
                Mathf.Lerp(0, targetTransitionHeight, elapsedTime / transitionDuration);
            transform.position = new Vector3(transform.position.x, distanceToMoveUpThisFrame * _canvasScale, transform.position.z);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, targetTransitionHeight * _canvasScale, transform.position.z);
        yield return new WaitForSeconds(transitionDuration);
        StartCoroutine(StartGrowing());
    }

    public void TransitionToNextState(float transitionDuration) {
        startingTransitionHeight = targetHeights[_currentGrowthStage];
        _currentGrowthStage++;
        StartCoroutine(FadeInNewRose(transitionDuration));
    }

    private IEnumerator FadeInNewRose(float transitionDuration) {
        if (_currentGrowthStage >= roseSprites.Count) yield break;

        newRoseImage.color = Color.clear;
        newRoseImage.sprite = roseSprites[_currentGrowthStage];
        Debug.Log("Transitioning to State" + _currentGrowthStage);
        
        float fadeOutDuration = 2;
        float elapsedTime = 0;
        while (elapsedTime < fadeOutDuration) {
            elapsedTime += Time.deltaTime;
            var newFadeOutAlpha = elapsedTime / fadeOutDuration;
            _roseImage.color = new Color(1, 1, 1, 1 - newFadeOutAlpha);
            newRoseImage.color = new Color(1, 1, 1, newFadeOutAlpha);
            yield return null;
        }
        
        // swap the faded out with the new faded in image
        _roseImage.sprite = newRoseImage.sprite;
        _roseImage.color = Color.white;
        newRoseImage.color = Color.clear;
    }
    
    private IEnumerator StartGrowing() {
        float elapsedTime = 0;
        float transitionDuration = 5f;
        
        while (isAlive) {
            if (_currentGrowthStage >= targetHeights.Count) yield break;

            elapsedTime += Time.deltaTime;
            var targetHeight = Mathf.Lerp(startingTransitionHeight, targetHeights[_currentGrowthStage],
                elapsedTime / transitionDuration);
            transform.position = new Vector3(transform.position.x, targetHeight, transform.position.z);
            
            yield return null;
        }
    }
}
