using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*This file takes care of the functionality of the Main Menu, it pops up after you have one*/
/*You can click Play to start the game or quit to exit game, the rules section is done within unity.*/
public class MainMenu : MonoBehaviour {

	public void Play()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void Quit()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
}
