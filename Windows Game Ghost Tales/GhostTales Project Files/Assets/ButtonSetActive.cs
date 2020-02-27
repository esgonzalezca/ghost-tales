using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonSetActive : MonoBehaviour {
    public GameObject panel;
    NetworkManager manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindObjectOfType<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DeslizarElPanel()
    {
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);

        }
        else
        {
            panel.SetActive(true);
        }
    }
    public void CloseSession()
    {
       
        manager.StopClient();
    }
    public void CloseSessionServer()
    {
        manager.StopServer();
    }
}
