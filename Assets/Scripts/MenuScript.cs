using Unity.VisualScripting;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private Camera menuCamera;
    [SerializeField]
    private Camera mainCamera;
    private PlayerScript playerScript;
    void Start()
    {
        playerScript = FindAnyObjectByType(typeof(PlayerScript)).GetComponent<PlayerScript>();
    }

    void OnMouseDown()
    {
        if(gameObject.name == "Start")
        {
            menuCamera.enabled = false;
            playerScript.StartGame();
        } else if (gameObject.name == "Quit")
        {
            Application.Quit();
        }
    }
}
