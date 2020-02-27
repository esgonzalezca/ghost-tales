using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PowerBar : NetworkBehaviour {

    public const int maxPower=50;
    [SyncVar(hook = "onChangePower")]
    public float currentPower = maxPower;
    
    public Image powerBar;
    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
            powerBar = GameObject.FindGameObjectWithTag("PowerBar").GetComponent<Image>();
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
        if (currentPower > maxPower) currentPower = maxPower;

    }

    private void onChangePower(float currentPower)
    {
        if (isServer) return;
      if(powerBar!=null)
        //Ojito, aqui yo pongo a multiplicar por 2 porque la barra en el inspector tiene size 100, entonces no se puede hacer solo en base a 50, lolXD
        powerBar.fillAmount = (currentPower * 2f)/100;
       // powerBar.sizeDelta = new Vector2(currentPower*1.25f, powerBar.sizeDelta.y);
    }
}

