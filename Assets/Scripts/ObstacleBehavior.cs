using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    PlayerMovement playerMovement;
    Vector3 target;
    public Transform player;

    //private float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(transform.position.x, transform.position.y,transform.position.z  + 200);
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    { 
        if(player.transform.position.z > transform.position.z)
        {
            Destroy(gameObject, 2f);
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerMovement.Die();
        }
    }

    public void CanMove ()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        Debug.Log("Hit");
        Destroy(gameObject, 5f);
    }

}
