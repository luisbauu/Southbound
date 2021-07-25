using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBehavior : MonoBehaviour
{
    public float trainSpeed;
    public AudioClip clip;
    PlayerMovement playerMovement;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3000);
        trainSpeed = 2f * playerMovement.speedOfPlayer(); 
        AudioSource.PlayClipAtPoint(clip, transform.position); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, target, trainSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            DestroyTrain();
        }
    }

    void DestroyTrain()
    {
        Destroy(gameObject, 1f);
    }
}
