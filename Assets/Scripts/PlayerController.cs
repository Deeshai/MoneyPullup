using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

/*The aim of the game is to collect all the pills and 
 not hit the obstacles in your way. This game
 is a heavily Jamaican influenced game with music, look, text and
 sound effects coming from a Jamaican background.*/

/*This file controls the speed of the ball in the game,
 keeps track of the players score in the level,
 and controls when music and soudeffects are played for colllecting
  a pill and beating the level*/


public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private int count;
    public Text score;
    public AudioClip pickUpSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.05f;

    /*Beginning set up with a count for the score display and makes sure that no text
     shows up until the player wins.*/
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        SetCountText();
        int level_index;
        
        /*Checks if player has started level based on level name and index*/
        if (sceneName == "Level 1")
        {
            level_index = 1;
            AnalyticsEvent.LevelStart(level_index);
            
        }
        else if (sceneName == "Level 2")
        {
            level_index = 1;
            AnalyticsEvent.LevelStart(level_index);

        }
        else if (sceneName == "Level 3")
        {
            level_index = 1;
            AnalyticsEvent.LevelStart(level_index);

        }
        else if (sceneName == "Level 4")
        {
            level_index = 1;
            AnalyticsEvent.LevelStart(level_index); 

        }

    }


    /*Gets audio for game*/
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    /*Takes care of the speed at which the ball travels
     when playing the game.*/
    void FixedUpdate()
    {
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * 5);
    }

    /*When a ball comes in contact with a pill it dissapears
     and a sound effect is played*/

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(pickUpSound, vol);

        }

    }

    /*Takes care of the text for the players lifeline, loads Win Menu Scene.*/

    void SetCountText()
    {
        score.text = "Score: $ " + count.ToString() + "00";

        if (count >= 7)
        {
            StartCoroutine(WaitForIt(2.0f));
        };
    }

    /*Timer, loads next scene after a few seconds*/
    IEnumerator WaitForIt(float waitTime)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        yield return new WaitForSeconds(waitTime);
        if (sceneName == "Level 1")
        {
            
            SceneManager.LoadScene("Win Menu");
        }
        else if (sceneName == "Level 2")
        {

            SceneManager.LoadScene("Win Menu Level 2");
        }
        else if (sceneName == "Level 3")
        {

            SceneManager.LoadScene("Win Menu Level 3");
        }
        else if (sceneName == "Level 4")
        {

            SceneManager.LoadScene("Win Menu Level 4");
        }

    }

    
}

    


