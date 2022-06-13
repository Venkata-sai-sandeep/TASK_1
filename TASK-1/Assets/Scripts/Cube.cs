using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody rg;
   
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.transform.tag);
        if (other.transform.tag == "Cube_tag")
        {
            
            if (rg.velocity.x > other.rigidbody.velocity.x)
            {
                
                Destroy(other.gameObject);
            }
            else
            {
                
                Destroy(this.gameObject);
            }
        }
    }
    private void Update()
    {
        Vector3 newV = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = newV;
    }
}