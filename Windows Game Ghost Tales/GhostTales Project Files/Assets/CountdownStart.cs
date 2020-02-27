using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CountdownStart : NetworkBehaviour {
    public float timeTodead;
    [SyncVar]
    float countDown;
    public GameObject OrbeCount;
    TextMesh myText;
    Camera mainCamera;
    int limit;
    AudioSource countBoy;
    bool soundStarted;
    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;
        if (mainCamera.GetComponent<Moving>().isPC) limit = 0;
        else limit = 1;
        myText = gameObject.GetComponent<TextMesh>();
        countDown = timeTodead;
        countBoy = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if(isServer) countDown -= Time.deltaTime;

        if (countDown <= 11.4f&&!soundStarted)
        {

            if (isServer) countBoy.Play();
            soundStarted = true;
        }
        if (countDown <= limit)
        {
            if(OrbeCount!=null) Destroy(OrbeCount);
            print("Hola me voy a desruir");
            DestroyImmediate(gameObject);
        }
        int countInt = (int)countDown;
        if(myText!=null) myText.text = countInt.ToString();
	}
}
