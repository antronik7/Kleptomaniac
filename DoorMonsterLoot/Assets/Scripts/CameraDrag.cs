﻿using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour
{

    private Vector2 previousPosition;
    private Vector2 distanceBetWeenDrag;

    bool JeVeuxDezoomer = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(JeVeuxDezoomer);

        if (Camera.main.orthographicSize > 4.95f)
        {
            JeVeuxDezoomer = false;
        }

        if(JeVeuxDezoomer)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5.0f, 50 * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            previousPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        distanceBetWeenDrag = objPosition - previousPosition;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x + distanceBetWeenDrag.x, -15, 4), transform.position.y);

        previousPosition = objPosition;
    }

    void OnMouseDown()
    {
        if (Camera.main.orthographicSize == 2.5f)
        {
            JeVeuxDezoomer = true;
        }
    }
}
