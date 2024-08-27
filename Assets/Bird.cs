using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public Text GameScoreTxt, LoseScoreTxt, BestScoreTxt;
    public float JumpVelocity;
    public GameObject LosePanel;
    public Image LoseMedal;
    public Sprite WhiteMedal, GoldSprite;

    private int _gameScore, _bestScore;
    private Rigidbody2D _rb;
    private bool _GameOver;

    private void Awake()
    {
        Time.timeScale = 1;
        LoseMedal.sprite = WhiteMedal;

        if (PlayerPrefs.HasKey("Flappy"))
        {
            _bestScore = PlayerPrefs.GetInt("Flappy");
        }

        ShowText();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(ScoreCounter());
    }

    private void ShowText()
    {
        BestScoreTxt.text = _bestScore.ToString();
        GameScoreTxt.text = _gameScore.ToString();
        LoseScoreTxt.text = _gameScore.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.position.y < 3f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpVelocity);
        }
    }

    private IEnumerator ScoreCounter()
    {
        var timer = new WaitForSeconds(1);

        while (true)
        {
            yield return timer; // !!!!!

            if (!_GameOver)
            {
                _gameScore++;

                if (_gameScore > _bestScore)
                {
                    _bestScore = _gameScore;
                    PlayerPrefs.SetInt("Flappy", _bestScore);
                    LoseMedal.sprite = GoldSprite;
                }

                ShowText();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Block mover))
        {
            LosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
