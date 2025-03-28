using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;
using UnityEditor.Rendering;

public partial class NewEnemyAI : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public float nextWaypointDistance = 3f;
    private Pathfinding.Path enemyPath;
    public int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    public List<GameObject> nodeList;
    public List<GameObject> currentTargetList;
    public System.Random random = new System.Random();


    public Seeker seeker;
    public Rigidbody2D rb;

    public float speed;
    public float playerDistance;
    public float slowdownDistance;
    public float runDistance;
    public float runSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }



    void OnPathComplete(Pathfinding.Path p)
    {
        if (!p.error)
        {
            enemyPath = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector2.Distance((Vector2)target.position, (Vector2)transform.position);

        if (enemyPath == null)
        {
            return;
        }

        if (currentWaypoint >= enemyPath.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)enemyPath.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, enemyPath.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}