using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script just destroys any object that leaves the boundary of the game area

public class BoundaryDestroy : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

}
