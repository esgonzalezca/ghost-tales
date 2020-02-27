using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
    public const int maxHealth = 100;
    [SyncVar(hook = "onChangeHealth")]
    public float currentHealth = maxHealth;
    public RectTransform healthBar;
    // Use this for initialization
    void Start () {
        if(isLocalPlayer)
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
		
	}
    public void TakeDamage(float amount)
    {
        if (!isServer)
        {
            return;
        }
        currentHealth -= amount;
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
    public void GiveHealth(float amount)
    {
        if (!isServer)
        {
            return;
        }
        currentHealth += amount;
        if (currentHealth > 100) currentHealth = 100;
    }

    private void onChangeHealth(float currentHealth)
    {
        if(healthBar!=null)
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

}
