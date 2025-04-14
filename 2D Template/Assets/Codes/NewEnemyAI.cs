using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;
using UnityEditor.Rendering;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.Audio;

public partial class NewEnemyAI : MonoBehaviour
{
    [SerializeField] private AudioClip WalkingSoundClip;
    [SerializeField] private AudioClip RunningSoundClip;

    public enum States {Roaming, Chasing, Attacking}
    public States currentState = States.Roaming;
    public Transform target;
    public GameObject player;
    public float nextWaypointDistance = 3f;
    private Pathfinding.Path enemyPath;
    public int currentWaypoint = 0;
    private bool reachedEndOfPath = false;
    public bool isRandom;

    public List<GameObject> nodeList;
    public List<GameObject> currentTargetList;
    public System.Random random = new System.Random();


    public Seeker seeker;
    public Rigidbody2D rb;

    public float speed;
    public float slerp;
    public float targetDistance;
    public float leaveDistance;
    public float followDistance;
    public float playerDistance;
    public float stopChasing;
    // Start is called before the first frame update
    void Start()
    {
        if (isRandom == true)
        {
            RandomizePath();
            target = currentTargetList[0].transform;
            currentTargetList.Remove(currentTargetList[0]);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    public void RandomizePath()
    {
        List<GameObject> shuffledList = nodeList.OrderBy(x  => random.Next()).ToList();
        currentTargetList = shuffledList;
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
            Sound.instance.PlaySoundFXClip(WalkingSoundClip, transform, 1f);
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
        playerDistance = Vector2.Distance((Vector2)player.transform.position, (Vector2)transform.position);
        targetDistance = Vector2.Distance((Vector2)target.position, (Vector2)transform.position);

        if (playerDistance <= followDistance)
        {
            target = player.transform;
            currentState = States.Chasing;
        }
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
        if (targetDistance <= leaveDistance && currentState == States.Roaming)
        {
            if (currentTargetList.Count <= 0)
            {
                RandomizePath();
            }
            currentTargetList.Remove(currentTargetList[0]);
            target = currentTargetList[0].transform;
        }
        if (playerDistance > stopChasing && currentState == States.Chasing)
        {
            currentState = States.Roaming;
            if (currentTargetList.Count <= 0)
            {
                RandomizePath();
            }
            currentTargetList.Remove(currentTargetList[0]);
            target = currentTargetList[0].transform;
        }
        if (currentState == States.Chasing && playerDistance > 4f)
        {
            //Sound.instance.PlaySoundFXClip(RunningSoundClip, transform, 1f);
        }
        if (currentState == States.Chasing && playerDistance < 6f)
        {
            currentState = States.Attacking;
        }
        else if (currentState == States.Attacking && playerDistance >= 6f)
        {
            currentState = States.Chasing;
            Sound.instance.PlaySoundFXClip(RunningSoundClip, transform, 1f);
        }
        if (currentState != States.Chasing && playerDistance > 4)
        {
            Sound.instance.PlaySoundFXClip(WalkingSoundClip, transform, 1f);
        }

        if (currentState == States.Chasing || currentState == States.Roaming)
        {
            Vector2 direction = ((Vector2)enemyPath.vectorPath[currentWaypoint] - rb.position).normalized;
        
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, direction * speed, Time.deltaTime * slerp);

            float distance = Vector2.Distance(rb.position, enemyPath.vectorPath[currentWaypoint]);

            if (distance < leaveDistance)
            {
                currentWaypoint++;
            }
        }
        if (currentState == States.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(enemyPath.vectorPath[currentWaypoint], 1);
    }
}


