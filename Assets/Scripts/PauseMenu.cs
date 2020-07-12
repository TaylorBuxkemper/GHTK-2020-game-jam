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
        if (Input.GetKeyDown(KeyCode.P)) {
            ShowPauseMenu();
        }
    }

    void ShowPauseMenu() {
        Time.timeScale = 0f;
        _canvas.enabled = true;
    }

    public void HidePauseMenu() {
        Time.timeScale = 1f;
        _canvas.enabled = false;
    }
}
