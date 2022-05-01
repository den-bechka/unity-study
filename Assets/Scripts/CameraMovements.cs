using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private SpriteRenderer image;
    [SerializeField] private int zoomSpeed = 10;
    
    private Vector3 dragPosition;
    private float minX, maxX, minY, maxY;

    private void Awake()
    {
        minX = image.transform.position.x - image.bounds.size.x / 2f;
        maxX = image.transform.position.x + image.bounds.size.x / 2f;
        minY = image.transform.position.y - image.bounds.size.y / 2f;
        maxY = image.transform.position.y + image.bounds.size.y / 2f;
    }

    void Update()
    {
        Move();
        Zoom();
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
            dragPosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 diff = dragPosition - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position = ClampCamera(cam.transform.position += diff);
        }
    }

    void Zoom()
    {
        if (cam.orthographic)
        {
            float newSize = cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            
            if (CheckZoom(newSize))
            {
                cam.orthographicSize = newSize;
            }
        }
        else
        {
            float newSize = cam.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            
            if (CheckZoom(newSize))
            {
                cam.fieldOfView = newSize;
            }
        }
        
        cam.transform.position = ClampCamera(cam.transform.position);
    }

    Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minXPos = minX + camWidth;
        float maxXPos = maxX - camWidth;
        float minYPos = minY + camHeight;
        float maxYPos = maxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minXPos, maxXPos);
        float newY = Mathf.Clamp(targetPosition.y, minYPos, maxYPos);
        
        return new Vector3(newX, newY, targetPosition.z);
    }

    bool CheckZoom(float zoomVal)
    {
        bool isNotZero = zoomVal > 0;
        return isNotZero;
    }
}
