using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    PlaneSpawner planeSpawner;
    [SerializeField] GameObject plane;
    public List<GameObject> buildings;
    Vector3 nextSpawnPoint;
    Vector3 buildSpawnPoint;
  


    // Start is called before the first frame update
    void Start()
    {
        planeSpawner = GameObject.FindObjectOfType<PlaneSpawner>();

        buildSpawnPoint = new Vector3(22.0f,0,0);

        for (int i = 0; i < 12; i++)
        {
            if(i < 1)
            {
                SpawnPlane(false, false, false);
            }
            else
            {
                SpawnPlane(true, true, false);
            }

            // Destroy(gameObject, 2);
        }


        for (int i = 0; i < 12; i++)
        {
            SpawnBuildings(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnPlane(bool spawnCoin, bool spawnCar, bool hardMode)
    {
        GameObject temp = Instantiate(plane, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;

        if(spawnCoin)
        {
            temp.GetComponent<PlaneSpawner>().SpawnCoins();
        }

        if(spawnCar)
        {
            temp.GetComponent<PlaneSpawner>().SpawnCars();
        }

        if(hardMode)
        {
            temp.GetComponent<PlaneSpawner>().SpawnCarsHard();
        }
    }

    public void SpawnBuildings()
    {
        GameObject buildingToSpawn = buildings[Random.Range(0,buildings.Count)];

        GameObject temp = Instantiate(buildingToSpawn, buildSpawnPoint, Quaternion.identity);
        buildSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

}
