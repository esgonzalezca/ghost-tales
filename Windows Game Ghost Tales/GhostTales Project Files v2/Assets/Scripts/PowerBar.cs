using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerBar : NetworkBehaviour {

    public const int maxPower = 20;
    [SyncVar(hook = "onChangePower")]
    public float currentPower = maxPower;
    public RectTransform powerBar;
    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
            powerBar = GameObject.FindGameObjectWithTag("PowerBar").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LosePower(float amount)
    {
        if (!isServer)
        {
            return;
        }
        currentPower -= amount;
        //if (currentHealth <= 0)
        //{

        //    if (destroyOnDeath) Destroy(gameObject);
        //    else
        //    {
        //        currentHealth = maxHealth;
        //        RpcRespawn();
        //    }


        //}
        //onChangeHealth(currentHealth);
    }
    public void GivePower(float amount)
    {
        if (!isServer)
        {
            return;
        }
        currentPower += amount;
        if (currentPower > 20) currentPower = 20;

    }

    private void onChangePower(float currentPower)
    {
        if (isServer) return;
        //Ojito, aqui yo pongo a multiplicar por 5 porque la barra en el inspector tiene size 100, entonces no se puede hacer solo en base a 20, lolXD
        powerBar.sizeDelta = new Vector2(currentPower*5, powerBar.sizeDelta.y);
    }
}
