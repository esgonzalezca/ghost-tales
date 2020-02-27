using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour {
    public bool iHaveMoved;
    public float speed;
    public GameObject initialAsteroid;
    public GameObject initialLightsFlares;
    private Vector3 posPc = new Vector3(1.68f, 124f, -33.95f);
    private Vector3 posCel = new Vector3(1.68f,23, -5946f);
    public bool isPC;
    public GameObject MobileMenu;
    public GameObject PcMenu;
    public AudioSource Button;
    

    // Use this for initialization
    void Start () {
        if (isPC)
        {
            this.transform.position = posPc;
            PcMenu.SetActive(true);
        }
        else
        {
            
            this.transform.position=posCel;
            MobileMenu.SetActive(true);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
       
        if (iHaveMoved)
        {

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,13f,transform.position.z), step);

            //iHaveMoved = false;
            if (transform.position.y == 13)
            {
                iHaveMoved = false;
                initialAsteroid.SetActive(false);
                initialLightsFlares.SetActive(false);
            }
        }

    }
		
	
}
