using UnityEngine;
using CodeMonkey.Utils;
using JetBrains.Annotations;
using UnityEngine.Diagnostics;

public class EnemyAI : MonoBehaviour
{
    public static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 startingPosition;
    private void Start()
    {
        startingPosition = transform.position;
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + UtilsClass.GetRandomDir() * Random.Range(10f, 70f);
    }
}
