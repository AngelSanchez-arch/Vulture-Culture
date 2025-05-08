using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 6)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                StartCoroutine(shoot());
            }
        }
    }

    IEnumerator shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);

        yield return new WaitForSeconds(.25f);

        foreach (var item in FindFirstObjectByType<EnemyBulletScript>().GetComponents<CircleCollider2D>())
        {
            item.enabled = true;
        }
    }
}
