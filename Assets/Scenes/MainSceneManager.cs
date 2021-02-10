using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Spaceship player;
    public ScoreUI scoreUI;
    public Text GameOverUI;

    public DoubleClick doubleClick;
    public SwipeAxisX swipeAxisX;

    public Spaceship prefabEnemy;
    public GameObject prefabBarricad;

    public GameObject spawnEnemy;
    public GameObject spawnPlayer;

    private GameObject[] barricads;

    private Spaceship[] gameObjectsEnemy;

    private int CountEnemy = 15;

    private float CounterTime = 0f;
    private float TimeSpawnEnemy = 1;

    private float minX = -3f;
    private float maxX = 3f;

    void Start()
    {
		doubleClick.EventClick += DoubleClick_EventClick;
		swipeAxisX.EventClick += SwipeAxisX_EventClick;

        player.EventDied += Player_EventDied;
        barricads = GameObject.FindGameObjectsWithTag("Block");
        gameObjectsEnemy = new Spaceship[CountEnemy];

        for (int i = 0; i < CountEnemy; ++i)
		{
            var newEnemy = GameObject.Instantiate(prefabEnemy);
            newEnemy.gameObject.SetActive(false);
            newEnemy.EventDied += Enemy_EventDied;
            gameObjectsEnemy[i] = newEnemy;
        }
    }

	private void SwipeAxisX_EventClick(float value)
	{
        player.transform.localPosition += new Vector3(value, 0f, 0f);
        if (player.transform.localPosition.x < minX) { player.transform.localPosition = new Vector3(minX, player.transform.localPosition.y, player.transform.localPosition.z); }
        else if (player.transform.localPosition.x > maxX) { player.transform.localPosition = new Vector3(maxX, player.transform.localPosition.y, player.transform.localPosition.z); }
    }

    private void DoubleClick_EventClick()
	{
        player.spacegun.Fire();
    }

    private void SpawnEnemy(Spaceship spaceship)
	{
        spaceship.gameObject.SetActive(true);
        spaceship.transform.localPosition = new Vector3(Random.Range(-3f, 3f), spawnEnemy.transform.localPosition.y, spawnEnemy.transform.localPosition.z);
        spaceship.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -50f));
        spaceship.XP = Random.Range(1, 3) * 100;
    }

	private void Enemy_EventDied()
	{
        scoreUI.Add(100);
    }

    private void Player_EventDied()
	{
        GameOverUI.gameObject.SetActive(true);
        swipeAxisX.gameObject.SetActive(false);
        doubleClick.gameObject.SetActive(false);
        StartCoroutine(Wait_GameOver());
    }

    IEnumerator Wait_GameOver()
	{
        yield return new WaitForSeconds(3f);
        GameOverUI.gameObject.SetActive(false);
        swipeAxisX.gameObject.SetActive(true);
        doubleClick.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        player.XP = 100;
        player.gameObject.transform.localPosition = spawnPlayer.transform.localPosition;
        scoreUI.Reset();
        ReserBarricads();
        ResetEnemy();
    }

    private void ReserBarricads()
	{
		for (int i = 0; i < barricads.Length; ++i)
		{
            barricads[i].gameObject.SetActive(true);
        }
    }

    private void ResetEnemy()
	{
        for (int i = 0; i < gameObjectsEnemy.Length; ++i)
        {
            gameObjectsEnemy[i].gameObject.SetActive(false);
        }
    }

	void Update()
    {
        CounterTime += Time.deltaTime;
        if (CounterTime > TimeSpawnEnemy )
		{
            CounterTime = 0;
            for (int i = 0; i < CountEnemy; ++i)
            {
                if (gameObjectsEnemy[i].gameObject.activeSelf == false)
                {
                    SpawnEnemy(gameObjectsEnemy[i]);
                    break;
                }
            }
        }
    }
}
