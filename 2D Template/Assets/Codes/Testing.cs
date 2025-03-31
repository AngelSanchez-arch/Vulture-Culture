/*
using System.Collections.Generic;
using CodeMonkey.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Rendering;

public class Testing : MonoBehaviour
{
    [SerializeField] private PathFindingVisual PathFindingVisual;
    [SerializeField] private CharacterPathFindingMovementHandler characterPathFinding;
    [SerializeField] private HeatMapVisual heatMapVisual;
    [SerializeField] private HeatMapBoolVisual heatMapBoolVisual;
    private PathFinding pathFinding;

    private Grid<bool> grid;

    private void Start()
    {
<<<<<<< HEAD
        //PathFinding pathFinding = new PathFinding(10, 10);
=======
        Grid grid = new Grid<HeatMapGridObject>(20, 10, 4f, new Vector3.zero, () => new HeatMapGirdObject());
        PathFinding pathFinding = new PathFinding(10, 10);
        pathFindingVisual.SetGrid(pathFinding.GetGrid());

        List<int> intList = new List<int>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            HeatMapGridObject heatMapGridObject = grid.GetValue(position);
            if (heatMapGridObject != null)
            {
                heatMapGridObject.AddValue(5);
            }
            int value = grid.GetValue(UtilsClass.GetMouseWorldPosition();
            grid.SetValue(position, value = 5);
            grid.AddValue(position, 100, 2, 15);
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
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
>>>>>>> 95b5ea33d2e1cc4573841e1301dc1cf661e52d5c
    }
}

public class HeatMapGridObject
{
    private const int MIN = 0;
    private const int MAX = 100;

    private Grid<HeatMapGridObject> grid;
    private int x;
    private int y;
    private int value;

    public HeatMapGridObject(Grid<HeatMapGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int addValue)
    {
        value += addValue;
        Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, y)
    }
    public float GetValueNormalized()
    {
        return (float)value / MAX;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}
*/