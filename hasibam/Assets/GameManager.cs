using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    public Player player;
    public GroundMove gMove;
    public RespawnMananger res;
    public CloudMove cloudmove;
    public ScoreBoard scoreboard;
    public isCollision collision;

    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;
    public float gameSpeed = 1;
    public bool isPlay = false;
    public GameObject playBtn;
    public Text scoreText;
    public int score = 0;

    private void Update()
    {
        player.PlayerMove();
        gMove.gMove();
        cloudmove.moveCloud();
        Collision();
    }

    void Collision()
    {
        if (isPlay)
        {
            for (int i = 0; i < 6; i++)
            {
                collision.enemy = res.MobPool[i].transform;
                if (collision.CheckCollision(collision.player.position,
                    collision.playerSize, collision.enemy.position, collision.enemySize))
                    GameOver();
            }
        }
    }
    IEnumerator AddScore()
    {
        while (isPlay)
        {
            score++;
            scoreText.text = score.ToString();
            gameSpeed = gameSpeed + 0.02f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void PlayBtnClick()
    {
        playBtn.SetActive(false);
        scoreboard.one.SetActive(false);
        scoreboard.two.SetActive(false);
        scoreboard.three.SetActive(false);
        scoreboard.four.SetActive(false);
        scoreboard.five.SetActive(false);
        scoreboard.six.SetActive(false);
        scoreboard.seven.SetActive(false);
        scoreboard.eight.SetActive(false);
        scoreboard.nine.SetActive(false);
        scoreboard.ten.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
        score = 0;
        scoreText.text = score.ToString();
        StartCoroutine(AddScore());
    }

    public void StopBtnClick()
    {
        isPlay = false;
    }

    public void GameOver()
    {
        playBtn.SetActive(true);
        isPlay = false;
        onPlay.Invoke(isPlay);
        StopCoroutine(AddScore());
        gameSpeed = 5.0f;

        scoreboard.one.SetActive(true);
        scoreboard.two.SetActive(true);
        scoreboard.three.SetActive(true);
        scoreboard.four.SetActive(true);
        scoreboard.five.SetActive(true);
        scoreboard.six.SetActive(true);
        scoreboard.seven.SetActive(true);
        scoreboard.eight.SetActive(true);
        scoreboard.nine.SetActive(true);
        scoreboard.ten.SetActive(true);
        scoreboard.UpdateHighScore();
        scoreboard.savesocre();
    }
}
