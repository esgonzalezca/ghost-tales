using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System.Linq;
public class StartClient : MonoBehaviour {
    public NetworkManager manager;
    public InputField myText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void JoinToParty()
    {
        manager.networkAddress = myText.text;
        manager.StartClient();
       


    }
    public static string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "0.0.0.0";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
}
