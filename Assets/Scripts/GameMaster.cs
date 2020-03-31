using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public CinemachineVirtualCamera myCinemachine;
    CameraShake camShake;

    [SerializeField]
    private int maxLives = 3;
    private static int _playerLives;
    private static int _playerPoints;
    public static int playerPoints
    {
        get { return _playerPoints; }
    }
    public static int playerLives
    {
        get { return _playerLives; }
    }

    private void Awake()
    {
        if (gm == null) gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        myCinemachine = GetComponent<CinemachineVirtualCamera>();
        camShake = GetComponent<CameraShake>();
    }

    private void Start()
    {
        _playerPoints = 0;
        _playerLives = maxLives;
        audioManager = AudioManager.instance;
        if (audioManager == null) Debug.LogError("NOOOO! No audio manager");
    }

    private AudioManager audioManager;
    public GameObject spawnParticle;
    public float shakeAmount = .2f;
    public float shakeLength = .2f;
    public GameObject playerPrefab;
    public GameObject gameOverUI;
    public Transform spawnPoint;
    public int spawnDelay = 2;

    public static void Blast(Transform where)
    {
        GameObject obj = ObjectPooler.SharedInstance.GetPooledObject("Blast");
        if (obj != null)
        {
            gm.StartCoroutine(gm.Boom(obj, where));
        }
    }

    IEnumerator Boom(GameObject obj, Transform where)
    {
        obj.transform.position = where.position;
        obj.transform.rotation = where.rotation;
        obj.SetActive(true);
        yield return new WaitForSeconds(.1f);
        obj.SetActive(false);
    }

    public void EndGame()
    {
        // GAME OVER
        gameOverUI.SetActive(true);
    }

    public IEnumerator RespawnPlayer(Player player)
    {
        audioManager.PlaySound("Respawn");
        yield return new WaitForSeconds(spawnDelay);
        player.transform.position = spawnPoint.position;
        player.stats.Init();
        player.gameObject.SetActive(true);
        Instantiate(spawnParticle, spawnPoint.position, spawnPoint.rotation);
        myCinemachine.m_Follow = player.transform;
    }

    public static void KillPlayer(Player player)
    {
        player.gameObject.SetActive(false);
        gm.camShake.Shake(gm.shakeAmount, gm.shakeLength);
        _playerLives--;
        if (_playerLives <= 0)
        {
            gm.EndGame();
        }
        else gm.StartCoroutine(gm.RespawnPlayer(player));
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm.audioManager.PlaySound("Explode");
        _playerPoints += 10;
        GameObject enemyDeathEffect = ObjectPooler.SharedInstance.GetPooledObject("EnemyDeath");
        if (enemyDeathEffect != null)
        {
            gm.StartCoroutine(gm.Boom(enemyDeathEffect, enemy.transform));
        }
        enemy.gameObject.SetActive(false);
    }
}
