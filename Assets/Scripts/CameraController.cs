using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Takes care of the camera position while the ball is in motion during the game.*/

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    /*Use this for initialization*/
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    /*Update is called once per frame*/
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}
