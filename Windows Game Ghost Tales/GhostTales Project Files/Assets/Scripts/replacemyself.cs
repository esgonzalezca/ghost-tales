using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class replacemyself : NetworkBehaviour {
    public GameObject[] playerModels;
    public int CurrentCharacterSelected=0;
    //este objeto es el boton y el textinput del canvas para que se elimine cuando se efectua con exito la conexion del cliente. debe haber una mejor forma de hacer esto.
    public GameObject startPanelToDestroy;
    
	// Use this for initialization
	void Start () {
        if (isServer) return;
        startPanelToDestroy = GameObject.FindGameObjectWithTag("MainMenuPhone");
    
        if(startPanelToDestroy!=null)
        startPanelToDestroy.SetActive(false);
        
	}
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "Local";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void setCharacterNumber(int number)
    {
        CurrentCharacterSelected = number;
    }
    [Command]
    public void Cmd_ReplacePlayer(int selected,GameObject button)
    {
        //Player prefab is a global variable that refers to a prefab.


        //This line spawns the prefab just like any signle player game on the server.
        GameObject go = Instantiate(playerModels[selected], transform.position, transform.rotation);
        //Then this just tells all the clients to spawn the same object.
        NetworkServer.Spawn(go);
        //Then we try to replace it. And if it succeeded.
        if (NetworkServer.ReplacePlayerForConnection(connectionToClient, go, playerControllerId))
        {
            //We destroy the current player across all instances
            NetworkServer.Destroy(button);
            NetworkServer.Destroy(gameObject);
        }
    }
}
