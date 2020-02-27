using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Linq;

public class ShowLocalIp : MonoBehaviour {
    TextMesh myText;
   
	// Use this for initialization
	void Start () {
        myText = gameObject.GetComponent<TextMesh>();
        myText.text = LocalIPAddress();
     
	}
	
	// Update is called once per frame
	void Update () {
     
		
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
