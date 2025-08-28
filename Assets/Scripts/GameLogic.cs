using System.Collections;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject obstacles;

    [Header("Movement")]
    [SerializeField] private float speed = 20f;
    private Vector3 newPos;

    [Header("Start Menu")]
    [SerializeField] private GameObject startMenu;
    public AudioSource rockThatBody;
    public TMP_Text startCountText;
    public GameObject goButton;

    private void Awake()
    {
        Time.timeScale = 0f;
    }
    private void Update()
    {
        newPos = obstacles.transform.position;
        newPos.z = newPos.z - 1 * speed * Time.deltaTime;
        obstacles.transform.position = newPos;
    }

    public void StartGame()
    {
        rockThatBody.Play();
        goButton.SetActive(false);
        startCountText.gameObject.SetActive(true);
        StartCoroutine(StartCount());
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
