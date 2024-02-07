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
    public GameObject pivotLeft;
    private SelectManager selectManager;
    void Start()
    {
        isSelected = false;
        mycam = Camera.main;
        collider = receiver.GetComponent<Collider2D>();
        selectManager = gameObject.GetComponentInParent<SelectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = mycam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                // Set as selected gameobject
                float preZ = pivotLeft.transform.rotation.z;
                // Highlight the bar using color 1
                selectManager.setSelected(gameObject);
                // Display the remaining rotational steps

                // Minus steps one if they rotate
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
