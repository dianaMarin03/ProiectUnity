using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private PlayerScript player;
    private int lives = 3;
    //private SoundManager soundManager;
    //[SerializeField]
    //private AudioClip collisionSound;
    //[SerializeField]
    //private AudioClip explosionSound;
    //[SerializeField]
    //private AudioClip finishLineSound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        //soundManager = FindObjectOfType<SoundManager>();
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
                //soundManager.PlaySound(explosionSound);
                player.StartCrashParticles();
                Invoke("Reset", 3f);
            }
            else if (lives > 0)
            {
                //soundManager.PlaySound(collisionSound);
                player.StartImpactParticles();
            }
        }
        else if (collision.gameObject.tag == "Finish")
        {
            if (SceneManager.GetActiveScene().name == "Level2Scene")
            {
                //soundManager.PlaySound(finishLineSound);
                player.DisablePlayer();
                Invoke("LoadFirstScene", 5f);
            }
            else
            {
                SceneManager.LoadScene("Level2Scene");
            }
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
