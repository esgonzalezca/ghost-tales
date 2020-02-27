using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public GameObject brickedBox;
    private float time2Dead=20f;
    private float currentTime;
    public GameObject[] pociones;
  
    

	// Use this for initialization
	void Start () {
        currentTime = time2Dead;
		
	}
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;
        if (currentTime <0)
        {
            Destroy(gameObject);
        }

        
		
	}
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet") 
        {
            BrickIt(gameObject);
        }
    }
    protected void BrickIt(GameObject box)
    {
        GameObject roto = Instantiate(brickedBox, box.GetComponent<Transform>().position, box.GetComponent<Transform>().rotation);
         int random = Random.Range(0, 2);
        print(random);
        if (random == 1)
            Instantiate(pociones[Random.Range(0, pociones.Length)],this.transform.position,this.transform.rotation);
        Destroy(box);
    
       
    }
   
    
}
