using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{

    PrefabSpawner prefabSpawner;

    [SerializeField] GameObject OnePesoCoin;
    [SerializeField] GameObject FivePesoCoin;
    [SerializeField] GameObject train;

    public List<GameObject> Cars;

    private GameObject player;

    public int coinsToSpawn;
    public int hardStart;
    public int hardEnd;
    public int distance;
    Collider boxCollider;

    //Vector3 trainSpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        prefabSpawner = GameObject.FindObjectOfType<PrefabSpawner>();
        player = GameObject.Find("Player");
        coinsToSpawn = 10;
        hardStart = 500;
        hardEnd = 750;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.RoundToInt(player.transform.position.z) / 10;
    }

    private void OnTriggerExit (Collider other)
    {
        if(distance > hardStart && distance < hardEnd)
        {
            prefabSpawner.SpawnPlane(true, false, true);
            Destroy(gameObject, 2);
        }
        else if(distance == hardEnd)
        {
            prefabSpawner.SpawnPlane(true, false, true);
            Destroy(gameObject, 2);

            hardStart += 1500;
            hardEnd = hardStart + 250;
        }
        else
        {
            prefabSpawner.SpawnPlane(true, true, false);
            Destroy(gameObject, 2);
        }
            

        prefabSpawner.SpawnBuildings();
        Destroy(GameObject.FindWithTag("Building"), 1f);
    }

    public void SpawnCars ()
    {
        GameObject carToSpawn = Cars[Random.Range(0,Cars.Count)];
        GameObject carToSpawnB = Cars[Random.Range(0,Cars.Count)];

        // Random Car Position
        int carSpawnIndex =  Random.Range(1, 8);
        Transform spawnPoint = transform.GetChild(carSpawnIndex).transform;

        int carSpawnIndexB =  Random.Range(9, 16);
        Transform spawnPointB = transform.GetChild(carSpawnIndexB).transform;


        // Spawn Car
        Instantiate(carToSpawn, spawnPoint.position, Quaternion.identity);
        Instantiate(carToSpawnB, spawnPointB.position, Quaternion.identity);
    }

    public void SpawnCarsHard ()
    {
        GameObject carToSpawn = Cars[Random.Range(0,Cars.Count)];
        GameObject carToSpawnB = Cars[Random.Range(0,Cars.Count)];
        GameObject carToSpawnC = Cars[Random.Range(0,Cars.Count)];
        GameObject carToSpawnD = Cars[Random.Range(0,Cars.Count)];


        // Random Car Position
        int carSpawnIndex =  Random.Range(1, 4);
        Transform spawnPoint = transform.GetChild(carSpawnIndex).transform;

        int carSpawnIndexB =  Random.Range(5, 8);
        Transform spawnPointB = transform.GetChild(carSpawnIndexB).transform;

        int carSpawnIndexC =  Random.Range(9, 12);
        Transform spawnPointC = transform.GetChild(carSpawnIndexC).transform;

        int carSpawnIndexD =  Random.Range(13, 16);
        Transform spawnPointD = transform.GetChild(carSpawnIndexD).transform;

        float random = Random.Range(0f, 1f);

        if(random < 0.25f)
        {
            Instantiate(carToSpawn, spawnPoint.position, Quaternion.identity);
            Instantiate(carToSpawnB, spawnPointB.position, Quaternion.identity);
            Instantiate(carToSpawnC, spawnPointC.position, Quaternion.identity);
            Instantiate(carToSpawnD, spawnPointD.position, Quaternion.identity);
        } 
        else if(random < 0.60f)
        {
           int random2 = Random.Range(0,3);

           switch(random2)
           {
               case 0:
                Instantiate(carToSpawnB, spawnPointB.position, Quaternion.identity);
                Instantiate(carToSpawnC, spawnPointC.position, Quaternion.identity);
                Instantiate(carToSpawnD, spawnPointD.position, Quaternion.identity);
                break;
               case 1:
                Instantiate(carToSpawn, spawnPoint.position, Quaternion.identity);
                Instantiate(carToSpawnC, spawnPointC.position, Quaternion.identity);
                Instantiate(carToSpawnD, spawnPointD.position, Quaternion.identity);
                break;
               case 2:
                Instantiate(carToSpawn, spawnPoint.position, Quaternion.identity);
                Instantiate(carToSpawnB, spawnPointB.position, Quaternion.identity);
                Instantiate(carToSpawnD, spawnPointD.position, Quaternion.identity);  
                break;
               case 3:
                Instantiate(carToSpawn, spawnPoint.position, Quaternion.identity);
                Instantiate(carToSpawnB, spawnPointB.position, Quaternion.identity);
                Instantiate(carToSpawnC, spawnPointC.position, Quaternion.identity);
                break;
           }
        }
        else
        {
            int carSpawnIndexE =  Random.Range(1, 8);
            Transform spawnPointE = transform.GetChild(carSpawnIndexE).transform;

            int carSpawnIndexF =  Random.Range(9, 16);
            Transform spawnPointF = transform.GetChild(carSpawnIndexF).transform;

            Instantiate(carToSpawn, spawnPointE.position, Quaternion.identity);
            Instantiate(carToSpawnB, spawnPointF.position, Quaternion.identity);
        }
    }

    public void SpawnCoins ()
    {
        
        for(int i = 0; i < coinsToSpawn; i++)  
        {
            float random = Random.Range(0f, 1f);

            if(random < 0.2f)
            {
                GameObject temp = Instantiate(FivePesoCoin, transform);
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            }
            else
            {
                GameObject temp = Instantiate(OnePesoCoin, transform);
                temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            }
           
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3
        (
            Random.Range(collider.bounds.min.x + 0.25f, collider.bounds.max.x - 0.25f),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;

        return point;
    }
}
