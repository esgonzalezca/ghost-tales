using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallenPlayer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        print("colisonado");
        var hit = other.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            print("vamo a borrar");
            health.TakeDamage(100);

        }
    }
}
