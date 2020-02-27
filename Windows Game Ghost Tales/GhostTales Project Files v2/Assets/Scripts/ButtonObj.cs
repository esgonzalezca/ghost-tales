using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonObj : NetworkBehaviour {
    
    public bool hasTouched;
    public replacemyself myPlayer;
    public string ghostName;
    public int currentPlayerNumber;
    public GameObject miPanelJuego;
   
    // Use this for initialization
    void Start () {
       
        switch (ghostName)
        {
            case "GhostBrown":
                currentPlayerNumber = 0;
                break;
            case "GhostGreen":
                currentPlayerNumber = 1;
                break;
            case "GhostPurple":
                currentPlayerNumber = 2;
                break;
            case "GhostWhite":
                currentPlayerNumber = 3;
                break;

        }
        
       MyPanelController[] objetos = Resources.FindObjectsOfTypeAll<MyPanelController>();
        miPanelJuego = objetos[0].gameObject;
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   
    private void OnMouseDown()
    {
        myPlayer = GameObject.Find("Local").GetComponent<replacemyself>();
        hasTouched = true;
       // Destroy(GameObject.FindObjectOfType<Canvas>());
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("ButtonSelection");
        for(int i=0; i < buttons.Length; i++)
        {
            Destroy(buttons[i]);
        }
       
        myPlayer.Cmd_ReplacePlayer(currentPlayerNumber,gameObject);
        miPanelJuego.SetActive(true);
        
        //myPlayer = GameObject.Find(ghostName + "(Clone)").GetComponent<grantPermission>();
        //myPlayer.Cmd_botonear(gameObject);
       
    }
    
}
