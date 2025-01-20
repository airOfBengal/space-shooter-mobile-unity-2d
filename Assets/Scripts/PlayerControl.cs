using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControl : MonoBehaviour
{

    private Vector2 offset;
    private Camera mainCamera;

    private float maxLeft;
    private float maxRight;
    private float maxDown;
    private float maxUp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);

        maxLeft = mainCamera.ViewportToWorldPoint(new Vector2(0.15f, 0f)).x;
        maxRight = mainCamera.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        maxDown = mainCamera.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;
        maxUp = mainCamera.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Touch.activeFingers.Count > 0)
        {
            if(Touch.activeFingers[0].index == 0)
            {
                Touch touch = Touch.activeFingers[0].currentTouch;
                Vector3 touchPos = touch.screenPosition;
                touchPos = mainCamera.ScreenToWorldPoint(touchPos);

                if(touch.phase == TouchPhase.Began){
                    offset = touchPos - transform.position;
                }
                if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0f);
                }
                
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, maxLeft, maxRight),
                    Mathf.Clamp(transform.position.y, maxDown, maxUp),
                    0f
                );
            }
        }
    }

    private void OnEnable(){
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable(){
        EnhancedTouchSupport.Disable();
    }
}
