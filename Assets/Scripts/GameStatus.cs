using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using System;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private float delayTimeToRestartGame = 5f;
    [SerializeField] private GameObject bustedImage;
    [SerializeField] private TextMeshProUGUI timeToRestartText;
    [SerializeField] private TextMeshProUGUI timeText;    

    private bool restart = false;
    private float waitingTime = 0f;
    private Player player;
    private List<Monster> monsters;
    private float timeInMap = 0f;
    private int deaths = 0;
    private DateTime date;
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<Player>();
        monsters = FindObjectsOfType<Monster>().ToList();
        waitingTime = delayTimeToRestartGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            bustedImage.SetActive(true);
            timeToRestartText.text = ((int)waitingTime).ToString();
            waitingTime -= Time.deltaTime;
            monsters.ForEach(e => e.EnableMovement(false));
            if (waitingTime <= 0)
            {
                bustedImage.SetActive(false);
                restart = false;
                waitingTime = delayTimeToRestartGame;
                
                player.CanMove();
                player.SetToInitialPosition();
                monsters.ForEach(e =>
                {
                    e.EnableMovement(true);
                    e.SetToInitialPosition();
                });
            }
        }
        else{
            timeInMap += Time.deltaTime;
            date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddSeconds(timeInMap);
            timeText.text = date.ToString("mm:ss");
        }
    }

    public void RestartGame() => restart = true;
}
