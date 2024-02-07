using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public GameObject selected;
    private ClickChoose clickChoose;

    public TMP_Text stepNum;
    // Start is called before the first frame update
    void Start()
    {
        stepNum = gameObject.GetComponentInChildren<TMP_Text>();
        Debug.Log(stepNum.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            stepNum.text = Convert.ToString(clickChoose.remainStep);
        }
        else
        {
            stepNum.text = "*";
        }
    }

    public void setSelected(GameObject gameObject)
    {
        if (selected)
        {
            Renderer prevrenderer = clickChoose.receiver.GetComponent<Renderer>();
            prevrenderer.material.SetColor("_Color", Color.white);
        }
        selected = gameObject;
        clickChoose = gameObject.GetComponent<ClickChoose>();
        Renderer renderer = clickChoose.receiver.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.grey);
    }
}
