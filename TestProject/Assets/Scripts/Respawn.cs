using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(player, new Vector3(0, -4f, 0), Quaternion.identity);
        }
    }

}
