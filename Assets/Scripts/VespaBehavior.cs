using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VespaBehavior : MonoBehaviour
{
    public AudioClip clip;
    float vespaSpeed;
    Quaternion vespaRotation;
    PlayerMovement playerMovement;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        vespaSpeed = playerMovement.speedOfPlayer() / 4;
        AudioSource.PlayClipAtPoint(clip, transform.position); 

    }

    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerMovement.Die();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, target, vespaSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            DestroyVespa();
        }
    }

    void DestroyVespa()
    {
        Destroy(gameObject, 0.01f);
    }

    public void FromRight()
    {
        transform.Rotate(0,-90f,0);
        target = new Vector3(transform.position.x - 25, transform.position.y, transform.position.z);
    }

    public void FromLeft()
    {
        transform.Rotate(0,90f,0);
        target = new Vector3(transform.position.x + 25, transform.position.y, transform.position.z);
    }
    
}
