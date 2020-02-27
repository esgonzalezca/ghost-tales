using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public GameObject brickedBox;
    private float time2Dead=26f;
    private float currentTime;
    public GameObject[] pociones;
    Transform initialTransform;
  
    

	// Use this for initialization
	void Start () {
        initialTransform = this.transform;
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
        if (other.gameObject.tag == "Bullet") 
        {
            BrickIt(gameObject);
        }
    }
    protected void BrickIt(GameObject box)
    {
        GameObject roto = Instantiate(brickedBox, box.GetComponent<Transform>().position, box.GetComponent<Transform>().rotation);
         int random = Random.Range(0, 3);
      
        if (random == 1 || random==2)
            Instantiate(pociones[Random.Range(0, pociones.Length)],new Vector3( this.transform.position.x,this.transform.position.y+ 1.21f,this.transform.position.z), initialTransform.rotation);
        Destroy(box);
    
       
    }
   
    
}
