using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

/*This file takes care of the functionality of the Win Menu, it pops up after you have one*/
/*You can either go to the next level or quit to main menu.*/

public class WinMenuLevel4 : MonoBehaviour
{
    /*Keeps track of level completion.*/
    private void Start()
    {
        int level_index = 4;
        AnalyticsEvent.LevelComplete(level_index);
    }

    /*Loads next level if Next Level is pressed*/
    public void NextLevel()
    {
        SceneManager.LoadScene("Level 5");
    }

    /*Loads recent level if Replay is pressed*/
    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    /*Loads Main Menu, if quit is pressed*/
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
