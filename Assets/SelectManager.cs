using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


/*[0,1,2,3,4,5,6,7] = [0,45,90,135,180,225,270,315]
 * Level HI initial angle index
 * initial: [5,1,1,3]
 * win: [0,0,0,6]
 */
/*
 * Level NIHAO initial angles
 */
/*
 * Level HEBREW initial angles
 */
public class SelectManager : MonoBehaviour
{
    public GameObject selected;
    private RotateDiscretControll[] barsRotate;
    public int[] initialAngles; // Set in the hierarchy for each level
    public int[] winAngles; // Set in the hierarchy for each level
    private ClickChoose clickChoose;
    private RotateDiscretControll rotateDiscret;
    [SerializeField] private UnityEvent lose;
    public TMP_Text stepNum;
    public GameObject StepUsedup;
    // Start is called before the first frame update
    void Start()
    {
        StepUsedup = GameObject.Find("CanvasUsedup");
        stepNum = gameObject.GetComponentInChildren<TMP_Text>();
        barsRotate = gameObject.GetComponentsInChildren<RotateDiscretControll>();
        initAngles();
        StepUsedup.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (selected) stepNum.text = Convert.ToString(rotateDiscret.remainStep);
        else stepNum.text = "*";

        bool endOfGame = checkEnd();
        if (endOfGame)
        {
            showStepUsedUp();
        }
    }
    public void showStepUsedUp()
    {
        StepUsedup.gameObject.SetActive(true);
    }
    public void initAngles()
    {
        for (int i = 0;i<barsRotate.Length;i++)
        {
            barsRotate[i].setIndex(initialAngles[i]);
        }
    }
    public void checkWin()
    {
        bool win = true;
        for (int i = 0;i<barsRotate.Length;i++)
        {
            if (barsRotate[i].curIndex != winAngles[i])
            {
                win = false;
                break;
            }
        }

        if (win)
        {
            Debug.Log("YOU WIN!");
            StepUsedup.gameObject.SetActive(false);
            lose.Invoke();
        }
        else
        {
            Debug.Log("YOU LOSE!");
            StepUsedup.gameObject.SetActive(false);
            lose.Invoke();
        }
    }

    public bool checkEnd()
    {
        bool ended = true;
        foreach(RotateDiscretControll r in barsRotate)
        {
            if (r.remainStep > 0)
            {
                ended = false;
                break;
            }
        }
        StepUsedup.gameObject.SetActive(false);
        lose.Invoke();
        return ended;
    }

    public void setSelected(GameObject gameObject)
    {
        if (selected)
        {
            Renderer prevrenderer = clickChoose.receiver.GetComponent<Renderer>();
            prevrenderer.material.SetColor("_Color", Color.white);
        }
        selected = gameObject;
        rotateDiscret = gameObject.GetComponent<RotateDiscretControll>();
        clickChoose = rotateDiscret.clickChoose;
        Renderer renderer = clickChoose.receiver.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.grey);
    }

    public void restart()
    {
        for(int i = 0;i<barsRotate.Length;i++)
        {
            var br = barsRotate[i];
            br.curIndex = initialAngles[i];
            br.gameObject.transform.eulerAngles = new Vector3(0, 0, br.curIndex* 45);
            br.remainStep = br.initStep;
        }
    }
}
