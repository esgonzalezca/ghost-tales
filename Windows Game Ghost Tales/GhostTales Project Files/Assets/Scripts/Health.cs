using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "onChangeHealth")]
    public float currentHealth = maxHealth;

    CurrentPlayer CurrentManager;
    NetworkManager manager;
    bool hasRested;
    AudioSource gameOverSound;
    public bool hasSaidYoulose;
    public Image healthBar;
    public bool canRest;

    [SyncVar]
    public bool canClose;

    // Use this for initialization
    void Start()
    {

        gameOverSound = GetComponent<AudioSource>();
        manager = GameObject.FindObjectOfType<NetworkManager>();
        CurrentManager = GameObject.FindObjectOfType<CurrentPlayer>();
        if (isLocalPlayer)
            healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {

            transform.GetChild(1).GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            if (isLocalPlayer && !hasSaidYoulose)
            {
                StartCoroutine(example());




            }

            if (isServer && !hasRested && canRest)
            {

                CurrentManager.currentPlayers -= 1;
                print("Debi haber restado " + CurrentManager.currentPlayers);
                hasRested = true;
                canClose = true;
                //StartCoroutine(example2());

            }

            //Destroy(gameObject);
            if (canClose && isLocalPlayer) manager.StopClient();

        }

    }
    IEnumerator example2()
    {

        yield return new WaitForSeconds(10);
        //do something




    }
    IEnumerator example()
    {
        hasSaidYoulose = true;

        //GetComponent<PlayerController>().enabled = false;
        gameOverSound.Play();
        yield return new WaitWhile(() => gameOverSound.isPlaying);
        //do something
        Cmd_ActivateCanRest();




    }
    [Command]
    void Cmd_ActivateCanRest()
    {
        canRest = true;
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
        if (healthBar != null)
            healthBar.fillAmount = currentHealth / 100;

        if (this.currentHealth > currentHealth)
        {
            // Handheld.Vibrate();
        }
        this.currentHealth = currentHealth;

    }

}
