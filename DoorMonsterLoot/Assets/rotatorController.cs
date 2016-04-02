﻿using UnityEngine;
using System.Collections;

public class rotatorController : MonoBehaviour {

    public GameObject coffre;

    Vector2 GesturePoint;
    float OriginalRotAng;
    float OriginalTouchAng;
    float RotationAngle;
    float previousAngle;

    bool FiniLaBase = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(FiniLaBase)
        {
            gameObject.transform.rotation = Quaternion.AngleAxis(RotationAngle, Vector3.forward);
        }
        
    }

    void OnMouseDrag()
    {
        if(FiniLaBase)
        {
            Debug.Log("Je drag");
            Vector2 SpinnerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            GesturePoint = Input.mousePosition;
            SpinnerScreenPoint = (GesturePoint - SpinnerScreenPoint);
            float newRot = Mathf.Atan2(SpinnerScreenPoint.y, SpinnerScreenPoint.x) * Mathf.Rad2Deg - 90;
            RotationAngle = OriginalRotAng + newRot - OriginalTouchAng;

            if(previousAngle > transform.eulerAngles.z)
            {
                coffre.transform.Translate(Vector2.up / 20);
            }

            previousAngle = transform.eulerAngles.z;
        }
    }

    void OnMouseDown()
    {
        Vector2 SpinnerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //OriginalRotAng = (Mathf.Atan2(SpinnerScreenPoint.y, SpinnerScreenPoint.x) * Mathf.Rad2Deg - 90);
        OriginalRotAng = transform.eulerAngles.z;
        previousAngle = transform.eulerAngles.z;

        Debug.Log(OriginalRotAng);

        GesturePoint = Input.mousePosition;
        SpinnerScreenPoint = (GesturePoint - SpinnerScreenPoint);

        OriginalTouchAng = (Mathf.Atan2(SpinnerScreenPoint.y, SpinnerScreenPoint.x) * Mathf.Rad2Deg - 90);

        FiniLaBase = true;   
    }

    void OnMouseUp()
    {
        FiniLaBase = false;
    }
}