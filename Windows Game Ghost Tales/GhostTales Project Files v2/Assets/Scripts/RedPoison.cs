using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedPoison : MonoBehaviour
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
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            Destroy(gameObject);
            health.GiveHealth(30);
        }

    }

}
