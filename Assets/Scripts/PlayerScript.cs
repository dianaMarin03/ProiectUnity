using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private readonly float rotationSpeed = 1.0f;
    private ParticleSystem flameTop;
    private ParticleSystem flameLeft;
    private ParticleSystem flameBottom;
    private ParticleSystem flameRight;
    private ParticleSystem explosion;
    private ParticleSystem impact;

    void Start()
    {
        GetFlameParticles();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * 3.0f, ForceMode.Impulse); // give an initial impulse
    }

    void Update()
    {
        rb.AddForce(Vector3.back * 1.5f, ForceMode.Force); // slow the player
        RotateDownward();

        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.D))
        {
            MoveUp();
            MoveRight();
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.A))
        {
            MoveUp();
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            MoveUp();
        }
    }

    #region PARTICLES
    private void GetFlameParticles()
    {
        flameTop = GameObject.FindGameObjectWithTag("FlameTop").GetComponent<ParticleSystem>();
        flameTop.Stop();
        flameLeft = GameObject.FindGameObjectWithTag("FlameLeft").GetComponent<ParticleSystem>();
        flameLeft.Stop();
        flameBottom = GameObject.FindGameObjectWithTag("FlameBottom").GetComponent<ParticleSystem>();
        flameBottom.Stop();
        flameRight = GameObject.FindGameObjectWithTag("FlameRight").GetComponent<ParticleSystem>();
        flameRight.Stop();
        explosion = GameObject.FindGameObjectWithTag("Explosion").GetComponent<ParticleSystem>();
        explosion.Stop();
        impact = GameObject.FindGameObjectWithTag("Impact").GetComponent<ParticleSystem>();
        impact.Stop();
    }

    private void TurnOnParticles()
    {
        flameTop.Play();
        flameLeft.Play();
        flameBottom.Play();
        flameRight.Play();
    }
    
    private void TurnOffParticles()
    {
        flameTop.Stop();
        flameLeft.Stop();
        flameBottom.Stop();
        flameRight.Stop();
    }
    #endregion
    
    #region MOVEMENT
    private void MoveUp()
    {
        TurnOnParticles();
        rb.AddForce(Vector3.forward * 3.0f, ForceMode.Force);
        rb.AddForce(Vector3.up * 7.0f, ForceMode.Force);
        RotateUpward();
        Invoke("TurnOffParticles", 0.5f);
    }
    private void MoveRight()
    {
        rb.AddForce(Vector3.right * 3.0f, ForceMode.Force);
        RotateRight();
    }
    private void MoveLeft()
    {
        rb.AddForce(Vector3.left * 3.0f, ForceMode.Force);
        RotateLeft();
    }
    #endregion

    #region ROTATION
    private void RotateDownward()
    {
        Quaternion targetRotation = Quaternion.Euler(120f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void RotateUpward()
    {
        Quaternion targetRotation = Quaternion.Euler(-10f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void RotateRight()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -60f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void RotateLeft()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, 60f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    #endregion
}
