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
    void Start()
    {
        curIndex = 0;
        hasKeyDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (!hasKeyDown)
        {
            if (horizontalInput > 0)
            {
                curIndex = changeIndex(curIndex, true);
                transform.Rotate(new Vector3(0,0,45));
            }else if (horizontalInput < 0)
            {
                curIndex = changeIndex(curIndex, false);
                transform.Rotate(new Vector3(0,0,-45));
            }

            hasKeyDown = true;
        }
        if(horizontalInput == 0)
        {
            hasKeyDown = false;
        }
        
    }

    void OnKeyDown(KeyDownEvent ev)
    {
        Debug.Log("KeyDown" + ev.keyCode);
    }
    
    int changeIndex(int curIndex, bool add)
    {
        if (add)
        {
            if (curIndex == 8)
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
                curIndex = 8;
            }
            else
            {
                curIndex -= 1;
            }
        }

        return curIndex;
    }
}
