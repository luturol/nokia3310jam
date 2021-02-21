using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private float delayTimeToRestartGame = 5f;
    [SerializeField] private GameObject bustedImage;
    [SerializeField] private TextMeshProUGUI timeToRestartText;

    private bool restart = false;
    private float waitingTime = 0f;
    private Player player;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<Player>();
        waitingTime = delayTimeToRestartGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            bustedImage.SetActive(true);
            timeToRestartText.text = ((int) waitingTime).ToString();
            waitingTime -= Time.deltaTime;

            if (waitingTime <= 0)
            {
                bustedImage.SetActive(false);
                restart = false;
                player.CanMove();
                waitingTime = 0f;
            }
        }
    }

    public void RestartGame() => restart = true;
}
