using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotation;
    public float speed;
    
    // Update is called once per frame
    void Update() //constantly checks to make sure it's okay
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
