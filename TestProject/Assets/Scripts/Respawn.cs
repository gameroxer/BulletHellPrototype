using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject player;

    private void Update()
    {
        //If player presses R and another player doesn't exist, create new player object
        if (Input.GetKeyDown(KeyCode.R) && !(GameObject.Find("Player") || (GameObject.Find("Player(Clone)"))))
        {
            Instantiate(player, new Vector3(0, -4f, 0), Quaternion.identity);
        }
    }

}
