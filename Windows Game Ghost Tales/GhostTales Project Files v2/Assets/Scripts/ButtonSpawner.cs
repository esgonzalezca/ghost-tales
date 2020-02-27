using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class ButtonSpawner : NetworkBehaviour
{
   
    public GameObject[] playerModel;
   
    
   
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnStartServer()

    {
        for(int i=0; i < playerModel.Length; i++)
        {
            GameObject bat = Instantiate(playerModel[i]);
           
            NetworkServer.Spawn(bat);
        }
        
        
       
    }


}