using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class collision : MonoBehaviour
{
    public string tags;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == tags)
        {
            Debug.Log(other.GetComponent<Rigidbody2D>().velocity.x);
            if (other.GetComponent<Rigidbody2D>().velocity.x > 3)
            {
                Destroy(this.gameObject);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
