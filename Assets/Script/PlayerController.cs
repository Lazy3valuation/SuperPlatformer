using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float runSpeedMultiplier;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private GameObject spawnPoint;

    private bool isGrounded;

    [SerializeField]
    private float maxVelocityChange;

    private float horizontalMovement;
    private float verticalMovement;
    private bool isRunning;

    private bool jumpTrigger;

    // Start is called before the first frame update
    void Start()
    {
        horizontalMovement = 0;
        verticalMovement = 0;
        jumpTrigger = false;
        isGrounded = true;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        //inizializzano i component/variabili
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAxis();
        CheckJump();
        CheckRun();
    }

    void FixedUpdate()
    {
        Jump();
        Move();
    }

    private void Move()
    {
        if (isGrounded)
        {
            Vector3 targetVelocity;
            Vector3 velocity;

            float actualSpeed = speed;
            if (isRunning)
                actualSpeed *= runSpeedMultiplier;

            targetVelocity = (transform.forward * verticalMovement) + (transform.right * horizontalMovement);

            if (targetVelocity.magnitude > 1)
                targetVelocity.Normalize();

            targetVelocity *= actualSpeed;
            targetVelocity.y = 0;

            velocity = rb.velocity;

            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }

    private void UpdateAxis()
    {
        if (isGrounded)
        {
            horizontalMovement = Input.GetAxis(Constants.HORIZONTAL); //-1, 0, 1
            verticalMovement = Input.GetAxis(Constants.VERTICAL); //-1, 0, 1
        }
        else
        {
            horizontalMovement = 0;
            verticalMovement = 0;
        }
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpTrigger = true;
        }
    }

    private void Jump()
    {
        if (jumpTrigger)
        {
            rb.AddForce(transform.up * 4, ForceMode.Impulse);
            jumpTrigger = false;
        }
    }

    private void CheckRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            isRunning = true;
        else
            isRunning = false;
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Spike")
        {
            if (other.gameObject.GetComponent<TimedSpikes>().GetIsUp())
                transform.position = spawnPoint.transform.position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrivo")
        {
            GameManager.instance.IncrementaLivello();
            string nomeLivello = $"Livello {GameManager.instance.livello}";
            Debug.Log("Si va al livello " + nomeLivello);
            SceneManager.LoadScene(nomeLivello);
        }
        if (collision.gameObject.tag == "Terrain")
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
            isGrounded = false;
    }

}
