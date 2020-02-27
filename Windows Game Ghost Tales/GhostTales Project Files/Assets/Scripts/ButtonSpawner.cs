using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class ButtonSpawner : NetworkBehaviour
{
   
    public GameObject[] playerModel;
    ButtonObj[] buttons;
    CountdownStart countDown; 
   
    // Use this for initialization
    void Start()
    {
        countDown = GameObject.FindObjectOfType<CountdownStart>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
           if(countDown == null)
            {
                
                buttons=GameObject.FindObjectsOfType<ButtonObj>();
                for(int i=0; i < buttons.Length; i++)
                {
                    Destroy(buttons[i].gameObject);
                }

            }

        }

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