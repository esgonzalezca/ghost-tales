using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BluePoison : MonoBehaviour
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
        var health = hit.GetComponent<PowerBar>();
        if (health != null)
        {
            Destroy(gameObject);
            health.GivePower(50);
        }

    }

}