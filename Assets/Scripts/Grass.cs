﻿using System.Collections;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public float GrowthDelay = 5;
    public float GrowthDuration = 10f;
    public float GrowthHeight = 100f;
    
    private float _canvasScale = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _canvasScale = GetComponentInParent<Canvas>().transform.localScale.x;
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(GrowthDelay);
        float elapsedTime = 0;

        while (elapsedTime < GrowthDuration)
        {
            elapsedTime += Time.deltaTime;
            float grassGrowthDistance = Mathf.Lerp(0, GrowthHeight, elapsedTime / GrowthDuration);
            transform.position = new Vector3(transform.position.x, grassGrowthDistance * _canvasScale, transform.position.z);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}