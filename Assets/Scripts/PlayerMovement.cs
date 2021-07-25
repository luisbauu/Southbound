using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    float horizontalInput;
    private bool isCarGrounded;
    
    public LayerMask GroundLayer;
    public GameOver gameOver;
    public ParticleSystem particle;
    SteeringWheel steeringWheel;

    RaycastHit hit;
    [SerializeField] Rigidbody rb;
    Vector3 forwardMove;
    Vector3 horizontalMove;

    Vector3 trainSpawnpoint;
    Vector3 motorSpawnpoint;
    [SerializeField] GameObject train;
    [SerializeField] GameObject vespa;
    private GameObject activeTrain;

    public int distance;
    public int vespaIteration;
    public int speedIteration;
    public int trainIteration;
    private bool dead;


    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        steeringWheel = GameObject.FindObjectOfType<SteeringWheel>();

        playerSpeed = 45f;

        activeTrain = GameObject.Find("Train(Clone)");
        vespaIteration = 150;
        speedIteration = 250;
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("Difficulty") == 0)
        {
            steeringWheel.SetActive(true);
            horizontalInput = steeringWheel.GetClampedValue();
        }
        else
        {
            steeringWheel.SetActive(false);
            //TILTCONTROLS horizontalInput = Input.acceleration.x;
            horizontalInput = Input.GetAxis("Horizontal");
        }

        CheckTrain();
        distance = Mathf.RoundToInt(transform.position.z) / 10;

        if (transform.position.y < -5)
        {
            Die();
        }

        if(distance >= 150)
        {
            if(vespaIteration == distance)
            {
                SpawnVespa();
                vespaIteration += 150;
            }    
        }

        if(distance >= 250)
        {
            float randomNum = Random.Range(0f,1f);
            if(randomNum < 0.5f && CheckTrain())
            {
                SpawnTrain();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       horizontalMove = transform.right * horizontalInput * playerSpeed * Time.fixedDeltaTime;
       rb.MovePosition(rb.position + horizontalMove);
       rb.AddForce(transform.forward * playerSpeed, ForceMode.Force);
       rb.velocity = playerSpeed * (rb.velocity.normalized);

        if(speedIteration == distance)
        {
            //playerSpeed = Mathf.SmoothStep(playerSpeed, playerSpeed + 20, 2f * Time.fixedDeltaTime);
            playerSpeed += 5;
            speedIteration += 250;
        }

        if(dead)
        {
            rb.velocity = 0 * rb.velocity.normalized;
        }
    }

    public void Die()
    {
        dead = true;
        playerSpeed = 0;
        particle.Play();
        gameOver.Setup();
        if(transform.position.y > -5.05 || transform.position.y >= 0 )
        {
            AudioManager.instance.Play("CarCrash");
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float speedOfPlayer()
    {
        return playerSpeed;
    }

    public void SpawnTrain()
    {
        trainSpawnpoint = new Vector3(-14f, 14f, transform.position.z);
        float randomNum = Random.Range(0f,1f);
        if(randomNum < 0.5f)
        {
            GameObject spawnedTrain = Instantiate(train, trainSpawnpoint, Quaternion.identity);
        }
    }

    public void SpawnVespa()
    {
        if(transform.position.x > 0)
        {
            //RIGHT SIDE VESPA
            motorSpawnpoint =  new Vector3(-8f, 1f, transform.position.z + speedOfPlayer());
            GameObject spawnedMotor = Instantiate(vespa, motorSpawnpoint, Quaternion.identity);
            spawnedMotor.GetComponent<VespaBehavior>().FromLeft();

        }
        else
        {
            motorSpawnpoint =  new Vector3(8f, 1f, transform.position.z + speedOfPlayer());
            GameObject spawnedMotor = Instantiate(vespa, motorSpawnpoint, Quaternion.identity);
            spawnedMotor.GetComponent<VespaBehavior>().FromRight();
        }
    }

    public bool CheckTrain()
    {
        activeTrain = GameObject.Find("Train(Clone)");
        
        if(activeTrain == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
