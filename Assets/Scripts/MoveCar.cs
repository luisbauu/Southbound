using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    ObstacleBehavior obstacleBehavior;
    PrefabSpawner prefabSpawner;

    // Start is called before the first frame update
    void Start()
    {
        obstacleBehavior = GameObject.FindObjectOfType<ObstacleBehavior>();
        prefabSpawner = GameObject.FindObjectOfType<PrefabSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit (Collider other)
    {
        float random = Random.Range(0f,1f);

        if(other.gameObject.name == "Player")
        {
        }      
    }
}
