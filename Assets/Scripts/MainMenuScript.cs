using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject rankingMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject mainMenu;

    private AudioSource audioSource;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    private void TriggerClickSound()
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayGame()
    {
        TriggerClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnableRankingMenu()
    {
        TriggerClickSound();
        rankingMenu.SetActive(!rankingMenu.activeSelf);
        mainMenu.SetActive(!mainMenu.activeSelf);
    }

    public void EnableOptionsMenu()
    {
        TriggerClickSound();
        optionsMenu.SetActive(!optionsMenu.activeSelf);
        mainMenu.SetActive(!mainMenu.activeSelf);
    }
}
