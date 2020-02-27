using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StartClient : MonoBehaviour {
     NetworkManager manager;
    public InputField myText;
    // Use this for initialization
    void Start () {
        manager = GameObject.FindObjectOfType<NetworkManager>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void JoinToParty()
    {
        manager.networkAddress = myText.text;
        manager.StartClient();
       


    }
   
}
