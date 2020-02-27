using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class PlayerController : NetworkBehaviour
{
    public float movementSpeed;
    Vector3 movementNotNull = new Vector3(1,0,1);
    public GameObject bullet;
    public Transform eyes;
    public GameObject ShieldPrefab;
    public float speed;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!isLocalPlayer)
        {
            return;
        }
        gameObject.name = "Local";
    }
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            rb.isKinematic = true;
            return;

        }
        float moveHorizontal = Input.acceleration.x + Input.GetAxisRaw("Horizontal");
        float moveVertical = -Input.acceleration.z + Input.GetAxisRaw("Vertical");
        
        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            Vector3 v3 = GetComponent<Rigidbody>().velocity;
            v3.x = 0f;
            v3.z = 0.0f;
            GetComponent<Rigidbody>().velocity = v3;

        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            movementNotNull = movement;
        }

        transform.rotation = Quaternion.LookRotation(movementNotNull);
    }
    void Update()
    {
      
       
        //float moveHorizontal = Input.acceleration.x+ Input.GetAxisRaw("Horizontal");
        //float moveVertical = -Input.acceleration.z+ Input.GetAxisRaw("Vertical");

      




        //  transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
      //  GetComponent<Rigidbody.AddForce(movement * speed);
        if (Input.GetKeyDown("space"))
        {
            Cmd_ActivateShield();
        }
       
       
    }
    [Command]
    public void Cmd_Shoot(float timeSpend)
    {
        if (GetComponent<PowerBar>().currentPower >= 5)
        {
            GameObject bulletToSpawn = Instantiate(bullet, eyes.position, eyes.rotation);

            bulletToSpawn.GetComponent<BulletBehaviour>().setTamano((new Vector3(1, 1, 1) * timeSpend));

            bulletToSpawn.GetComponent<Rigidbody>().velocity = bulletToSpawn.transform.forward * 6;


         
            LosePower(timeSpend);
            Destroy(bulletToSpawn, 2.0f);
        }

        else if (GetComponent<PowerBar>().currentPower < 5 && GetComponent<PowerBar>().currentPower > 0)
        {
            if (GetComponent<PowerBar>().currentPower < timeSpend)
            {
                timeSpend = GetComponent<PowerBar>().currentPower;
                GameObject bulletToSpawn = Instantiate(bullet, eyes.position, eyes.rotation);

                bulletToSpawn.GetComponent<BulletBehaviour>().setTamano((new Vector3(1, 1, 1) * timeSpend));

                bulletToSpawn.GetComponent<Rigidbody>().velocity = bulletToSpawn.transform.forward * 6;


                NetworkServer.Spawn(bulletToSpawn);

                LosePower(timeSpend);
                
                Destroy(bulletToSpawn, 2.0f);
            }
            else if (GetComponent<PowerBar>().currentPower >= timeSpend)
            {
                GameObject bulletToSpawn = Instantiate(bullet, eyes.position, eyes.rotation);

                bulletToSpawn.GetComponent<BulletBehaviour>().setTamano((new Vector3(1, 1, 1) * timeSpend));

                bulletToSpawn.GetComponent<Rigidbody>().velocity = bulletToSpawn.transform.forward * 6;


                NetworkServer.Spawn(bulletToSpawn);

                LosePower(timeSpend);
              
                Destroy(bulletToSpawn, 2.0f);
            }

        }
    }
    public void LosePower(float amount)
    {
        GetComponent<PowerBar>().LosePower(amount);
    }

    [Command]
    public void Cmd_ActivateShield()
    {
        GameObject shieldToSpawn = Instantiate(ShieldPrefab,transform.position,transform.rotation);
        shieldToSpawn.transform.parent = gameObject.transform;
        //NetworkServer.Spawn(shieldToSpawn);
        Destroy(shieldToSpawn, 5f);

    }
}