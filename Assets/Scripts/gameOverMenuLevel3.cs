using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*This file takes care of the functionality of the GameOver Menu, it pops up after you have one*/
/*You can either restart the game or quit to main menu.*/

public class gameOverMenuLevel3 : MonoBehaviour { 

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

