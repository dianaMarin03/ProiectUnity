using Unity.VisualScripting;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private Camera menuCamera;
    [SerializeField]
    private Camera mainCamera;
    private PlayerScript playerScript;
    private HealthScript healthScript;
    void Start()
    {
        playerScript = FindAnyObjectByType(typeof(PlayerScript)).GetComponent<PlayerScript>();
        healthScript = FindAnyObjectByType(typeof(HealthScript)).GetComponent<HealthScript>();
    }

    void OnMouseDown()
    {
        if(gameObject.name == "Start")
        {
            menuCamera.enabled = false;
            playerScript.StartGame();
            healthScript.DisplayHealth();
        } else if (gameObject.name == "Quit")
        {
            Application.Quit();
        }
    }
}
