using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private readonly float rotationSpeed = 1.5f;

    private bool isAlive = true;

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
        RotateDownward();
        if (isAlive)
        {
            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.D))
            {
                //MoveUp();
                rb.AddForce(Vector3.forward * 1.5f, ForceMode.Acceleration);
                rb.AddForce(Vector3.up * 3.0f, ForceMode.Force);
                MoveRight();
            }
            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.A))
            {
                //MoveUp();
                rb.AddForce(Vector3.forward * 1.5f, ForceMode.Acceleration);
                rb.AddForce(Vector3.up * 3.0f, ForceMode.Force);
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
    }

    #region MOVEMENT
    private void MoveUp()
    {
        TurnOnParticles();
        rb.AddForce(Vector3.forward * 2.5f, ForceMode.Acceleration);
        rb.AddForce(Vector3.up * 6.0f, ForceMode.Force);
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
        //Quaternion targetRotation = Quaternion.Euler(-20f, 0f, 0f);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //transform.RotateAround(transform.position, Vector3.right, -120 * Time.deltaTime);
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(-20f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(startRotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
    private void RotateRight()
    {
        //Quaternion targetRotation = Quaternion.Euler(Vector3.forward * -100f);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 3.0f * Time.deltaTime);
        transform.RotateAround(transform.position, Vector3.down, -120 * Time.deltaTime);
    }
    private void RotateLeft()
    {
        //Quaternion targetRotation = Quaternion.Euler(0f, 0f, 140f);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.RotateAround(transform.position, Vector3.up, -120 * Time.deltaTime);
    }
    #endregion

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
        rb.AddForce(Vector3.back * 1.0f, ForceMode.Force);
        flameTop.Stop();
        flameLeft.Stop();
        flameBottom.Stop();
        flameRight.Stop();
    }

    public void StartCrashParticles()
    {
        rb.freezeRotation = false;
        isAlive = false;
        explosion.Play();
        Invoke("StopCrashParticles", 4f);
    }
    private void StopCrashParticles()
    {
        explosion.Stop();
    }

    public void StartImpactParticles()
    {
        impact.Play();
        Invoke("StopImpactParticles", 0.7f);
    }
    private void StopImpactParticles()
    {
        impact.Stop();
    }
    #endregion
}
