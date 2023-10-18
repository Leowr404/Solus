using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public int rotationSpeed;
    private Vector3 rotate;
    void Start()
    {
        rotate = new Vector3(0, rotationSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);
    }
}
