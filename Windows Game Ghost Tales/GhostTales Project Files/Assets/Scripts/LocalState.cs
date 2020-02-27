using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalState : MonoBehaviour {
    private GameObject player;
    public bool takeDamage;
    public GameObject[] boxes;
    public float timeLeft;
    private float timeToReseat;

	// Use this for initialization
	void Start () {
        
        timeToReseat = timeLeft;

	}
	
	// Update is called once per frame
	void Update () {
    


         timeToReseat-= Time.deltaTime;
        if (timeToReseat < 0)
        {

            float z = Random.Range(-23.57f, 15.5f);
            float x = Random.Range(-19.2f, 20.83f);

            Instantiate(boxes[Random.Range(0, boxes.Length)], new Vector3(x, 1.95f, z), this.transform.rotation);

            timeToReseat = timeLeft;
        }
        

    }
   

}
