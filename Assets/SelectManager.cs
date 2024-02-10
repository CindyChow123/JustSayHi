using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*[0,1,2,3,4,5,6,7] = [0,45,90,135,180,225,270,315]
 * Level HI initial angle index
 * initial: [5,1,1,3]
 * win: [0,0,0,6]
 */
/*
 * Level NIHAO initial angles
 * initial: [5,0,1,4,6,2,7,0,3,4,2]
 * win: [5,7,7,3,7,1,2,3,6,2,1]
 */
/*
 * Level HEBREW initial angles
 * initial: [2,7,5,3,4,7,2,6,4,7,2,3]
 * win: [4,6,0,4,0,6,4,4,1,0,4,7]
 */
public class SelectManager : MonoBehaviour
{
    public GameObject selected;
    private RotateDiscretControll[] barsRotate;
    public int[] initialAngles; // Set in the hierarchy for each level
    public int[] winAngles; // Set in the hierarchy for each level
    private ClickChoose clickChoose;
    private RotateDiscretControll rotateDiscret;

    [SerializeField] private GameObject[] viewLevels;

    private int currentIndex = 0;
    public TMP_Text stepNum;
    public GameObject StepUsedup;
    
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject WinGame;
    
    // Start is called before the first frame update
    void Start()
    {
        StepUsedup = GameObject.Find("CanvasUsedup");
        stepNum = gameObject.GetComponentInChildren<TMP_Text>();
        barsRotate = gameObject.GetComponentsInChildren<RotateDiscretControll>();
        initAngles();
        StepUsedup.gameObject.SetActive(false);
        Lose.SetActive(false);
        WinGame.SetActive(false);
        if (viewLevels != null && viewLevels.Length > 0)
        {
            foreach (var level in viewLevels)
            {
                level.SetActive(false);
            }

            viewLevels[0].SetActive(true);
        }
        else
        {
            Debug.LogError("No levels");
        }
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
            Lose.SetActive(false);
            WinGame.SetActive(true);
        }
        else
        {
            Debug.Log("YOU LOSE!");
            WinGame.SetActive(false);
            Lose.SetActive(true);
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
            br.setIndex(initialAngles[i]);
            br.remainStep = br.initStep;
        }
        StepUsedup.gameObject.SetActive(false);
        SceneManager.LoadScene("Linguo");
    }

    public void nextLevel()
    {
        if (currentIndex >= 0 && currentIndex < viewLevels.Length)
        {
            viewLevels[currentIndex].SetActive(false);
        }

        currentIndex++;
        
        if (currentIndex < viewLevels.Length)
        {
            viewLevels[currentIndex].SetActive(true);
        }
        else
        {
            Debug.Log("Won all Games!");
        }
    }
    
}
