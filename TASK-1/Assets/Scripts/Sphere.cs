using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rg;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Sphere_tag")
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

    void Update()
    {
        Vector3 newV = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = newV;
    }
}
