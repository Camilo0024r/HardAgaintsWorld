using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mover la pared hacia atras
        transform.Translate(1,0,0 *Time.deltaTime);
    }
}
        
