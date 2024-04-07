using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private PlayerScript player;
    private int lives = 3;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {

    }

    public int GetLivesRemaining() { return lives; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tunnel") || collision.gameObject.CompareTag("Obstacle"))
        {
            lives--;
            if (lives == 0)
            {
                player.StartCrashParticles();
                Invoke("Reset", 3f);
            }
            else if (lives > 0)
            {
                player.StartImpactParticles();
            }
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
