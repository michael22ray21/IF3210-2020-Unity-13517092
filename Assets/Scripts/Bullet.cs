using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    CameraShake camShake;
    public Rigidbody2D rb;
    public int damage = 40;
    public float speed = 20f;
    public float shakeAmount = .1f;
    public float shakeLength = .1f;
    private bool hitSomething = false;

    private void Start()
    {
        camShake = GameMaster.gm.GetComponent<CameraShake>();
    }

    void OnEnable()
    {
        rb.velocity = transform.right * speed;
        camShake.Shake(shakeAmount, shakeLength);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (!hitSomething)
        {
            hitSomething = true;
            if(hitInfo.CompareTag("Boundary"))
            {
                gameObject.SetActive(false);
                hitSomething = false;
            }
            else
            {
                // Take action
                if (hitInfo.CompareTag("Enemy")) hitInfo.GetComponent<Enemy>().DamageEnemy(damage);
                // Blast away
                GameMaster.Blast(gameObject.transform);
                gameObject.SetActive(false);
                hitSomething = false;
            }
        }
    }
}
