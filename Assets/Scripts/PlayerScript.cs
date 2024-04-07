using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private readonly float rotationSpeed = 1.5f;

    private bool isAlive = true;
    private bool start = false;

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
        if (start)
        {
            if (isAlive)
            {                
                if (Input.GetKey(KeyCode.Space))
                {
                    TurnOffParticles();
                    ReduceSpeed();
                    rb.useGravity = true;
                }
                else if (Input.GetKey(KeyCode.LeftShift)) { Boost(); }
                else
                {
                    TurnOnParticles();
                    rb.velocity = Camera.main.transform.forward * 15.0f;
                }

                if (Input.GetKey(KeyCode.W))
                {
                    MoveUp();
                    rb.useGravity = false;
                }
                else if (Input.GetKey(KeyCode.D)) { MoveRight(); }
                else if (Input.GetKey(KeyCode.A)) { MoveLeft(); }
                else if (Input.GetKey(KeyCode.S)) { RotateDownward(); }
            }
        }
        else
        {
            rb.isKinematic = true;
        }
    }

    public void StartGame() { start = true; rb.isKinematic = false; }
    #region MOVEMENT
    private void MoveUp()
    {
        RotateUpward();
    }
    private void Boost()
    {
        rb.AddForce(Camera.main.transform.forward * 10.0f, ForceMode.Force);
    }
    private void ReduceSpeed()
    {
        rb.AddForce(Camera.main.transform.forward * -4.0f, ForceMode.Force);
    }
    private void MoveRight()
    {
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
    }
    private void MoveLeft()
    {
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
    }
    #endregion

    #region ROTATION
    private void RotateDownward()
    {
        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(120f, cameraRotation.eulerAngles.y, cameraRotation.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void RotateUpward()
    {
        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(-20f, cameraRotation.eulerAngles.y, cameraRotation.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
    #endregion

    #region PARTICLES
    private void GetFlameParticles()
    {
        flameTop = GameObject.FindGameObjectWithTag("FlameTop").GetComponent<ParticleSystem>();
        flameLeft = GameObject.FindGameObjectWithTag("FlameLeft").GetComponent<ParticleSystem>();
        flameBottom = GameObject.FindGameObjectWithTag("FlameBottom").GetComponent<ParticleSystem>();
        flameRight = GameObject.FindGameObjectWithTag("FlameRight").GetComponent<ParticleSystem>();
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
        rb.useGravity = true;
        TurnOffParticles();
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
        if (!impact.IsUnityNull())
        {
            impact.Play();
            Invoke("StopImpactParticles", 1f);
        }
    }
    private void StopImpactParticles()
    {
        if (!impact.IsUnityNull())
            impact.Stop();
    }
    #endregion
}
