using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PauseMenu : MonoBehaviour
{
    private Canvas _canvas;

    
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowPauseMenu();
        }
    }

    void ShowPauseMenu()
    {
        _canvas.enabled = true;
    }

    public void HidePauseMenu()
    {
        _canvas.enabled = false;
    }
}
