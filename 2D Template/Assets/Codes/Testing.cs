using CodeMonkey.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Rendering;

public class Testing : MonoBehaviour
{
    [SerializeField] private PathFindingVisual PathFindingVisual;
    [SerializeField] private CharacterPathFindingMovementHandler characterPathFinding;
    private PathFinding pathFinding;

    private void Start()
    {
        Grid grid = new Grid(4, 2, 10f);
        PathFinding pathFinding = new PathFinding(10, 10);
        pathFindingVisual.SetGrid(pathFinding.GetGrid());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            List<PathNode> path = pathFinding.FindPath(0, 0, x, y);
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green);
                }
            }
            characterPathFinding.SetTargetPosition(mouseWorldPosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            pathFinding.GetGrid().SetIsWalkable(!pathFinding.GetNode(x, y).IsWalkable);
        }
    }
}
