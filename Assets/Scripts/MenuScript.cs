using Unity.VisualScripting;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private Camera menuCamera;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private AudioClip menuSound;

    private SoundManager soundManager;
    private PlayerScript playerScript;
    void Start()
    {
        playerScript = FindAnyObjectByType(typeof(PlayerScript)).GetComponent<PlayerScript>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (!soundManager.checkIfIsPlaying(menuSound))
            soundManager.PlaySound(menuSound);
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
