using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartSever : MonoBehaviour {
    public NetworkManager manager;
    public GameObject myCamera;
    public GameObject mainMenuPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void buttonPressed()
    {
        manager.StartHost();
        myCamera.GetComponent<Moving>().iHaveMoved = true;
        mainMenuPanel.SetActive(false);

    }
}
