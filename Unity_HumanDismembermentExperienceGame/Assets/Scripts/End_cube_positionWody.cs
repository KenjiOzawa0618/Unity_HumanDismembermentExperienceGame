using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_cube_positionWody : MonoBehaviour
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

        if(counter%920 == 0){
            transform.position = new Vector3(-1,14,-6);
        }
    }
}





    


