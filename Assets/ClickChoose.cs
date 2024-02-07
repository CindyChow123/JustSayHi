using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChoose : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSelected;
    private Collider2D collider;
    private Camera mycam;
    public GameObject receiver;
    void Start()
    {
        isSelected = false;
        mycam = Camera.main;
        collider = collider = receiver.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = mycam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                // Highlight the bar
                // Change colors
                // Debug.Log(collider.gameObject);
            }
        }

        // if (Input.GetMouseButton(0))
        // {
        //     if (collider == Physics2D.OverlapPoint(mousePos))
        //     {
        //         Debug.Log(collider.gameObject);
        //     }
        // }
    }
}
