
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_cube_positionBuzz : MonoBehaviour
{
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter = counter+1;

        if(counter%1050 == 0){
            transform.position = new Vector3(-1,22,-6);
        }
    }
}

