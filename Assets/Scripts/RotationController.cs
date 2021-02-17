using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Takes care of the way the pills rotate at an angle in the game.*/
public class RotationController : MonoBehaviour
{

    /*Update is called once per frame*/
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
