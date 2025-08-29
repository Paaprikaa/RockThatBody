using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [Header("Obstacles")]
    [SerializeField] private GameObject obstacles;
    [SerializeField] private float speed = 20f;
    private Vector3 newPos;

    [Header("Start Menu")]
    [SerializeField] private GameObject startMenu;
    public AudioSource rockThatBody;
    public TMP_Text startCountText;
    public GameObject goButton;

    [Header("Win/Loose Menu")]
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject looseMenu;


    private void Awake()
    {
        Time.timeScale = 0f;
    }
    private void Update()
    {
        newPos = obstacles.transform.position;
        newPos.z = newPos.z - 1 * speed * Time.deltaTime;
        obstacles.transform.position = newPos;
        if (obstacles.transform.position.z <= -160f)
        {
            WinGame();
        }
    }

    // Buttons
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }


    public void StartGame()
    {
        rockThatBody.Play();
        goButton.SetActive(false);
        startCountText.gameObject.SetActive(true);
        StartCoroutine(StartCount());
    }

    // Menus
    private void WinGame()
    {
        winMenu.SetActive(true);
    }

    public void LooseGame()
    {
        looseMenu.SetActive(true);
        rockThatBody.Stop();
        Time.timeScale = 0f;
    }

    private IEnumerator StartCount()
    {
        for (int textCounter = 3; textCounter >= 0; textCounter--)
        {
            startCountText.text = textCounter.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }
        startMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
