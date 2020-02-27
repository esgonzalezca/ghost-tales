using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletBehaviour : NetworkBehaviour
{

    [SyncVar]
    public Vector3 tamano;
    private Collision myOwnnCollision;
    public GameObject myPatron;
    private bool collisionSaved;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = tamano;
        //print(this.tamano + " pero yo soy de " + this.transform.localScale);

    }
    public void setTamano(Vector3 newTamano)
    {
        tamano = newTamano;
    }

    void OnTriggerEnter(Collider other)
    {
        //if (!collisionSaved)
        //{
        //    myPatron = other.gameObject;
        //    collisionSaved = true;
        //    return;
        //}

        if (other.gameObject != transform.parent.gameObject && other.gameObject.name != "Cylinder")
        {



            var hit = other.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(tamano.x * 100 * 10);
               
            }
            GameObject.FindObjectOfType<LocalState>().GetComponent<AudioSource>().Play();
            print(other.gameObject.name);
            Destroy(gameObject);
        }
    }


}
