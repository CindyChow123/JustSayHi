using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentIndex;
    [SerializeField] private GameObject[] viewLevels;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject WinGame;
    [SerializeField] GameObject NoMore;
    public int hintTime;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        hintTime = 2;
        // viewLevels = GameObject.FindGameObjectsWithTag("Round");
        initViewLevels();
        
        Lose = GameObject.Find("CanvasLose");
        WinGame = GameObject.Find("CanvasWin");
        NoMore = GameObject.Find("CanvasNoMore");
        Lose.SetActive(false);
        WinGame.SetActive(false);
        NoMore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextLevel()
    {
        if (currentIndex >= 0 && currentIndex < viewLevels.Length)
        {
            viewLevels[currentIndex].SetActive(false);
        }
        
        if (currentIndex+1 < viewLevels.Length)
        {
            callRestart();
            currentIndex++;
            viewLevels[currentIndex].SetActive(true);
        }
        else
        {
            WinGame.SetActive(false);
            NoMore.SetActive(true);
            Debug.Log("Won all Games! No other levels!");
        }
    }
    
    public void initViewLevels()
    {
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
            Debug.LogError("No other levels");
        }
    }

    public void callRestart()
    {
        viewLevels[currentIndex].GetComponent<SelectManager>().restart();
        Lose.SetActive(false);
        WinGame.SetActive(false);
    }

    public void win()
    {
        Lose.SetActive(false);
        WinGame.SetActive(true);
    }

    public void lose()
    {
        WinGame.SetActive(false);
        Lose.SetActive(true);
    }

    public void restartAll()
    {
        currentIndex = 0;
        // viewLevels = GameObject.FindGameObjectsWithTag("Round");
        initViewLevels();
        NoMore.SetActive(false);
    }

    public void showHint()
    {
        StartCoroutine(showHintRoutine(hintTime));
    }

    IEnumerator showHintRoutine(int seconds)
    {
        viewLevels[currentIndex].GetComponent<SelectManager>().hint.SetActive(true);
        int i = 0;
        while (i < seconds)
        {
            i += 1;
            yield return new WaitForSeconds(1.0f);
        }
        viewLevels[currentIndex].GetComponent<SelectManager>().hint.SetActive(false);
    }
}
