using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public CinemachineVirtualCamera myCinemachine;

    private void Awake()
    {
        if (gm == null) gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        myCinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    public GameObject spawnParticle;
    public GameObject playerPrefab;
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

    public IEnumerator RespawnPlayer(Player player)
    {
        yield return new WaitForSeconds(spawnDelay);
        player.transform.position = spawnPoint.position;
        player.gameObject.SetActive(true);
        Instantiate(spawnParticle, spawnPoint.position, spawnPoint.rotation);
        myCinemachine.m_Follow = player.transform;
    }

    public static void KillPlayer(Player player)
    {
        player.gameObject.SetActive(false);
        gm.StartCoroutine(gm.RespawnPlayer(player));
    }

    public static void KillEnemy(Enemy enemy)
    {
        GameObject enemyDeathEffect = ObjectPooler.SharedInstance.GetPooledObject("EnemyDeath");
        if (enemyDeathEffect != null)
        {
            gm.StartCoroutine(gm.Boom(enemyDeathEffect, enemy.transform));
        }
        enemy.gameObject.SetActive(false);
    }
}
