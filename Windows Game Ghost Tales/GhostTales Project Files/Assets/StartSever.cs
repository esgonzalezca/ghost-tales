using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartSever : MonoBehaviour {
    NetworkManager manager;
    public GameObject myCamera;
    public GameObject mainMenuPanel;
    AudioSource buttonSound;

	// Use this for initialization
	void Start () {
        buttonSound = GetComponent<AudioSource>();
        manager = GameObject.FindObjectOfType<NetworkManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void buttonPressed()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        manager.StartServer();
        myCamera.GetComponent<Moving>().iHaveMoved = true;
        mainMenuPanel.SetActive(false);
        //StartCoroutine(example());


    }
    //IEnumerator example()
    //{
    //    buttonSound.Play();
    //    yield return new WaitWhile(() => buttonSound.isPlaying);
    //    //do something
       

    //   
    //}
}
