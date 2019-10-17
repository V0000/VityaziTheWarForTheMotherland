using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    public float perspectiveZoomSpeed = 0.5f;        
    public float orthoZoomSpeed = 0.5f;
    public float moveSpeed = 0.01f;
    private Camera camera;
    public SpriteRenderer bgSprite;

    void Start()
    {
        camera = GetComponent<Camera>();
        Debug.Log(bgSprite.sprite.rect.size);
        Debug.Log(camera.pixelHeight);
        Debug.Log(camera.pixelWidth);
    }

    void Update()       
    {        

        if (Input.touchCount == 1)
        {
            

            if(Input.GetTouch(0).tapCount == 1)
            {
                if (camera.orthographic)
                {
                    Touch touchZero = Input.GetTouch(0);

                    Vector3 touchZeroPrevPos3 = touchZero.deltaPosition;
                    camera.transform.position -= touchZeroPrevPos3 * moveSpeed;
                    Debug.Log(touchZeroPrevPos3);
                    //////////////////////////////////////////////////////////////////
                }
            }
        
        }

            if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            
            if (camera.orthographic)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
            }
            else
            {
                // Otherwise change the field of view based on the change in distance between the touches.
                camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
            }
        }
    }
}
