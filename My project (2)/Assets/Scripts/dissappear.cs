using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Rigidbody2D birdCollider = this.GetComponent<Rigidbody2D>();
        if (this.GetComponent<Rigidbody2D>().velocity.x == 0 && !birdCollider.isKinematic)
        {
            Destroy(this.gameObject);
        }
    }
}
