using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemy : MonoBehaviour
{
    float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float displacement = speed * Time.fixedDeltaTime;
        transform.Translate(Vector3.forward * displacement* -1);
            
    }
}

