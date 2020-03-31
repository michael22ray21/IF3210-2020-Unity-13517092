using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public class EnemyStats
    {
        public int maxHealth = 100;
        private int _curHealth;
        public int damage = 40;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init() { curHealth = maxHealth; }
    }

    public EnemyStats stats = new EnemyStats();
    [Header("Optional :")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    private void Start()
    {
        stats.Init();
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }

    public void DamageEnemy(int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            GameMaster.KillEnemy(this);
        }
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null) player.DamagePlayer(stats.damage);
    }
}
