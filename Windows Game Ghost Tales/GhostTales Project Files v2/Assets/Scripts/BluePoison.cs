using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BluePoison : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }


    void OnCollisionEnter(Collision collision)
    {

       
        var hit = collision.gameObject;
        var health = hit.GetComponent<PowerBar>();
        if (health != null)
        {
            Destroy(gameObject);
            health.GivePower(7);
        }

    }

}