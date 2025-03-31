/*using UnityEngine;
using CodeMonkey.Utils;
using JetBrains.Annotations;
using UnityEngine.Diagnostics;

public class EnemyAI : MonoBehaviour
{
    //private enum State
    //{
    //    Roaming,
    //    ChaseTarget,
    //}

    //private EnemyPathfindingMovement pathfindingMovement;
    //private Vector3 startingPosition;
    //private Vector3 roamPosition;

    //private void Awake()
    //{
    //    pathfindingMovement= GetComponent<EnemyPathfindingMovement>();
    //}

    //private void Start()
    //{
    //    startingPosition = transform.position;
    //    roamPosition = GetRoamingPosition();
    //}

    //public static Vector3 GetRandomDir()
    //{
    //    return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    //}


    //private void Start()
    //{
    //    startingPosition = transform.position;
    //}

    //private void Update()
    //{
    //    switch (state)
    //    {
    //        default:
    //        case State.Roaming:
    //            pathfindingMovement.MoveTo(roamPosition);

    //            float reachedPositionDistance = 10f;
    //            if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance)
    //            {
    //                roamPosition = GetRoamingPosition();
    //            }

    //            FindTarget();
    //            break;
    //        case State.ChaseTarget:
    //            pathfindingMovement.MoveToTimer(Player.Instance.GetPosition());

    //            float attackRange = 10f;
    //            if(Vector3.Distance(transform.position, Player.Instance.GetPosition()) < attackRange)
    //            {

    //            }
    //            break;
    //        }    
    //    }
        

       

    //}

    //private Vector3 GetRoamingPosition()
    //{
    //    startingPosition + UtilsClass.GetRandomDir() * Random.Range(10f, 70f);
    //}

    //private void FindTarget() 
    //{
    //    float targetRange = 50f;
    //    if (Vector3.Distance(transform.position, Player.Instance.GetPosition()) < targetRange)
    //    {
    //        state = State.ChaseTarget;
    //    }
    //}
}
*/