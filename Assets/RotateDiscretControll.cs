using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class RotateDiscretControll : MonoBehaviour
{
    // Start is called before the first frame update
    private int[] angles = new int[]{0, 45, 90, 135, 180, 225, 270, 315};
    public int curIndex;
    public float horizontalInput;
    private bool hasKeyDown;
    private SelectManager selectManager;
    public ClickChoose clickChoose;
    public int remainStep;
    public int initStep;

    void Start()
    {
        initStep = 5;
        remainStep = initStep;
        curIndex = Convert.ToInt32(transform.eulerAngles.z / 45);
        hasKeyDown = false;
        selectManager = gameObject.GetComponentInParent<SelectManager>();
        clickChoose = gameObject.GetComponent<ClickChoose>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectManager.selected == gameObject)
        {
            checkKeyPress();
        }
    }

    void checkKeyPress()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (remainStep>0 && !hasKeyDown)
        {
            if (horizontalInput < 0)
            {
                curIndex = changeIndex(curIndex, true);
                remainStep -= 1;
            }else if (horizontalInput > 0)
            {
                curIndex = changeIndex(curIndex, false);
                remainStep -= 1;
            }
            transform.eulerAngles = new Vector3(0, 0, curIndex * 45);
            hasKeyDown = true;
        }
        if(horizontalInput == 0)
        {
            hasKeyDown = false;
        }
    }
    
    int changeIndex(int curIndex, bool add)
    {
        if (add)
        {
            if (curIndex == 7)
            {
                curIndex = 0;
            }
            else
            {
                curIndex += 1;
            }
        }
        else
        {
            if (curIndex == 0)
            {
                curIndex = 7;
            }
            else
            {
                curIndex -= 1;
            }
        }

        return curIndex;
    }

    public void setIndex(int index)
    {
        curIndex = index;
        transform.eulerAngles = new Vector3(0, 0, curIndex * 45);
    }
}
