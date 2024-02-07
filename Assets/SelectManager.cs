using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSelected(GameObject gameObject)
    {
        if (selected)
        {
            Renderer prevrenderer = selected.GetComponent<ClickChoose>().receiver.GetComponent<Renderer>();
            prevrenderer.material.SetColor("_Color", Color.white);
        }
        selected = gameObject;
        Renderer renderer = gameObject.GetComponent<ClickChoose>().receiver.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.grey);
    }
}
