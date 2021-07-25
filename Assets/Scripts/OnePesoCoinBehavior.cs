using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePesoCoinBehavior : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.GetComponent<ObstacleBehavior>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if(other.gameObject.GetComponent<MoveCar>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if(other.gameObject.name != "Player")
        {
            return;
        }

        // ADD SCORE
        // GameManager.inst.IncrementScore();

        AudioManager.instance.Play("OnePeso");
        GameManager.instance.IncrementScore("One");


        // DESTROY COIN IF COLLECTED
        Destroy(gameObject);
    }
}
