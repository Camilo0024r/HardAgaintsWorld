using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{

    Stickman player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Stickman>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        if(other.tag == "Floor"){
            player.OnGround = true;
        }
    }

     private void OnTriggerExit(Collider other){

        if(other.tag == "Floor"){
            player.OnGround = false;
        }
    }
}
