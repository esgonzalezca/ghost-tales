using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedPoison : MonoBehaviour
{

    public float timeToDead;
    float countDown;
    // Use this for initialization
    void Start()
        
    {
        countDown = timeToDead;

    }

    // Update is called once per frame
    void Update()
    {

        countDown -= Time.deltaTime;

        if (countDown <= 0) Destroy(gameObject);
    }


    void OnTriggerEnter(Collider other)
    {

      
        var hit = other.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
           
            health.GiveHealth(30);
        }
        Destroy(gameObject);
    }

}
