//This script outputs a message when a client connects or disconnects from the server
//Attach this script to your GameObject.
//Attach a NetworkManagerHUD to your by clicking Add Component in the Inspector window of the GameObject. Then go to Network>NetworkManagerHUD.
//Create a Text GameObject and attach it to the Text field in the Inspector.

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Example : NetworkManager
{
    //Assign a Text component in the GameObject's Inspector
    public Text m_Text;

    //Detect when a client connects to the Server
    public override void OnServerConnect(NetworkConnection connection)
    {
        //Change the text to show the connection
        m_Text.text = "Client " + connection.connectionId + " Connected!";
    }

    //Detect when a client disconnects from the Server
    public override void OnServerDisconnect(NetworkConnection connection)
    {
        //Change the text to show the loss of connection
        m_Text.text = "Client " + connection.connectionId + "Connection Lost!";
    }
}