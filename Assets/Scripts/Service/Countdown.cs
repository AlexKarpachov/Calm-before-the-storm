using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] float countdownTimeInSeconds = 3600f;
    [SerializeField] float floodDuration = 180f;
    [SerializeField] GameObject lake;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform lakeAnchor;

    float currentTime;
    float floodTimer = 0f;
    bool floodCompleted = false;
    public static bool floodStarted = false;

    Vector3 startPosition;
    Vector3 startScale;
    Vector3 finalScale = new Vector3(80f, 36f, 80f);

    void Start()
    {
        currentTime = countdownTimeInSeconds;

        startPosition = lake.transform.position;
        startScale = lake.transform.localScale;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText(); 
        }
        else if (!floodStarted && !floodCompleted)
        {
            StartFlood(); 
        }

        if (floodStarted)
        {
            UpdateFlood();
        }
    }

    void UpdateCountdownText()
    {
        int hours = Mathf.FloorToInt(currentTime / 3600f);
        int minutes = Mathf.FloorToInt((currentTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        countdownText.text = string.Format("The Doomsday will start in: {0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    void StartFlood()
    {
        Time.timeScale = 1f;
        GameManager.DoomsdayHasStarted = true;
        countdownText.text = "You have a few minutes until complete flooding.";
        floodStarted = true;
        floodTimer = 0f;
    }

    void UpdateFlood()
    {
        if (PlayerOnBoatMover.playerIsOnBoat)
        {
            Time.timeScale = 4f;
        }

        floodTimer += Time.deltaTime;

        float t = floodTimer / floodDuration;

        lake.transform.localScale = Vector3.Lerp(startScale, finalScale, t);
        lake.transform.position = Vector3.Lerp(startPosition, lakeAnchor.position, t);
        Time.timeScale = 1f;

        if (t >= 1f)
        {
            floodStarted = false; 
            floodCompleted = true;
            gameManager.WinScenario();
        }
    }
}
