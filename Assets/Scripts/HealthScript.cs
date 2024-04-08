using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public GameObject Health1;
    public GameObject Health2;
    public GameObject Health3;
    private CollisionHandler collisionHandler;

    private int lives;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level2Scene")
        {
            Health1.gameObject.SetActive(true);
            Health2.gameObject.SetActive(true);
            Health3.gameObject.SetActive(true);
        }
        else
        {
            Health1.gameObject.SetActive(false);
            Health2.gameObject.SetActive(false);
            Health3.gameObject.SetActive(false);
        }
        collisionHandler = FindAnyObjectByType(typeof(CollisionHandler)).GetComponent<CollisionHandler>();
    }

    void Update()
    {
        lives = collisionHandler.GetLivesRemaining();
        if (lives >= 0)
        {
            switch (lives)
            {
                case 0:
                    {
                        Health1.gameObject.SetActive(false);
                        Health2.gameObject.SetActive(false);
                        Health3.gameObject.SetActive(false);
                        break;
                    }
                case 1:
                    {
                        Health1.gameObject.SetActive(false);
                        Health2.gameObject.SetActive(false);
                        break;
                    }
                case 2:
                    {
                        Health1.gameObject.SetActive(false);
                        break;
                    }
            }
        }
    }

    public void DisplayHealth()
    {
        Health1.gameObject.SetActive(true);
        Health2.gameObject.SetActive(true);
        Health3.gameObject.SetActive(true);
    }

}
