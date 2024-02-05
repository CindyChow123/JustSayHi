using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform pivotPoint;
    public GameObject receiver;

    private Camera mycam;
    private Collider2D collider;
    private Vector3 screenPos;
    private float angleOffset;

    // Start is called before the first frame update
    void Start()
    {
        mycam = Camera.main;
        collider = receiver.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = mycam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = mycam.WorldToScreenPoint(pivotPoint.position);
                Vector3 vector3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(pivotPoint.right.y, pivotPoint.right.x) - Mathf.Atan2(vector3.y, vector3.x)) *
                              Mathf.Rad2Deg;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vector3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vector3.y, vector3.x) * Mathf.Rad2Deg;
                pivotPoint.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
        }
    }

    // private void OnMouseDrag()
    // {
    //     float deltax = Input.GetAxis("Mouse X");
    //     float deltay = Input.GetAxis("Mouse Y");
    //     turn.x += deltax;
    //     if (deltax > 0)
    //     {
    //         turn.y -= deltay;
    //     }
    //     else
    //     {
    //         turn.y += deltay;
    //     }
    //     pivotPoint.localRotation = Quaternion.Euler(0, turn.y*rotationSpeed, 0);
    // }
    
}