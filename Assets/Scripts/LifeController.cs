using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

/*Each player has 3 lives, everytime you hit an obstacle a life is lost
 and a sound effect plays, with some text and the option to restart the level.*/

/*This file takes care of the functionality for lives of the player,
 reducing life for everytime a player hits an obstacle with the ball,
 playing sound effects  for each life lost and a song
 when you lose all life.*/

public class LifeController : MonoBehaviour
{

    private int lifecount;
    public Text life;
    public Text restartText;
    public AudioClip loseLifeSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.05f;

    /*Use this for initialization*/
    void Start()
    {
        lifecount = 3;
        SetCountText();
        Advertisement.Initialize("3086513", true);
    }

    /*Initialization of audio*/
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    /*When the ball collides with an obstacle a life is lost, and the sound effect plays.*/
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("PlayerLife") && lifecount > 0)
        {
            lifecount = lifecount - 1;
            SetCountText();
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(loseLifeSound, vol);
        }
    }

    /*When all life is lost, the whole platform collapses and its game over.*/
    void OnCollisionExit(Collision coll)
    {

        if (lifecount == 0)
        {
            if (coll.gameObject.CompareTag("Ball"))
            {
                coll.gameObject.SetActive(false);
            }
        }


    }

    /*Takes care of the text for the players lifeline, loads GameOver Menu Scene.*/
    public void SetCountText()
    {

        life.text = "Life: " + lifecount.ToString();

        if (lifecount == 0)
        {
            StartCoroutine(WaitForIt(2.0f));
        }
    }

    /*Timer, loads next scene after a few seconds*/
    IEnumerator WaitForIt(float waitTime)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        yield return new WaitForSeconds(waitTime);
        if (sceneName == "Level 1")
        {
            /*Plays Ad before showing Game over Menu, same for all levels and Game over menus*/
            StartCoroutine(ShowAdWhenReady());
            SceneManager.LoadScene("GameOver Menu");
        }
        else if (sceneName == "Level 2")
        {
            StartCoroutine(ShowAdWhenReady());
            SceneManager.LoadScene("GameOver Menu Level 2");
        }
        else if (sceneName == "Level 3")
        {
            StartCoroutine(ShowAdWhenReady());
            SceneManager.LoadScene("GameOver Menu Level 3");
        }
        else if (sceneName == "Level 4")
        {
            StartCoroutine(ShowAdWhenReady());
            SceneManager.LoadScene("GameOver Menu Level 4");
        }
    }

    /*Checsk if Ad is ready to show and plays when it is ready, uses Ads script to run the Ad*/
    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show();
    }

}
