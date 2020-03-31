using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 40;
    public float speed = 20f;
    public GameObject impactEffect;

    void OnEnable()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Boundary"))
        {
            gameObject.SetActive(false);
        }
        else
        {
            // Take action
            if (hitInfo.CompareTag("Enemy")) hitInfo.GetComponent<Enemy>().TakeDamage(damage);
            // Blast away
            StartCoroutine(Blast());
        }
    }

    IEnumerator Blast()
    {
        GameObject obj = ObjectPooler.SharedInstance.GetPooledObject("Blast");
        if (obj != null)
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
            yield return new WaitForSeconds(.1f);
            obj.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
