/*using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinding
{
    //private const int MOVE_STRAIGHT_COST = 10;
    //private const int MOVE_DIAGONAL_COST = 14;

<<<<<<< HEAD
    //private Grid<PathNode> grid;
    //private List<PathNode> openList;
    //private List<PathNode> closedList;

    //public PathFinding(int width, int height)
    //{
    //    grid = new Grid<PathNode>(width, height, 10f, Vector3.zero, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y));
    //}

    //private List<PathNode> FindPath(int startX, int startY, int endX, int endY) 
    //{
    //    PathNode startNode = grid.GetGridObject(startX, startY);
    //    PathNode endNode = grid.GetGridObject(endX, endY);
=======
    public static PathFinding Instance {  get; private set; }

    private Grid<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;

    public PathFinding(int width, int height)
    {
        Instance = this;
        grid = new Grid<PathNode>(width, height, 10f, Vector3.zero, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }

    public Grid<PathNode> GetGrid()
    {
        return grid;
    }

    public List<Vector3> FindPath(Vector3 startWorldPosition, Vector3 endWorldPosition)
    {
        grid.GetXY(startWorldPosition, out int startX, out int startY);
        grid.GetXY(endWorldPosition, out int endX, out int endY);

        List<PathNode> path = FindPath(startX, startY, endX, endY);
        if (path != null)
        {
            return null;
        }
        else
        {
            List<Vector3> vectorPath = new List<Vector3>();
            foreach (PathNode pathNode in path)
            {
                vectorPath.Add(new Vector3(pathNode.x, pathNode.y) * grid.GetCellSize() + Vector3.one * grid.GetCellSize() * .5f);
            }
            return vectorPath;
        }
    }

    private List<PathNode> FindPath(int startX, int startY, int endX, int endY) 
    {
        PathNode startNode = grid.GetGridObject(startX, startY);
        PathNode endNode = grid.GetGridObject(endX, endY);
>>>>>>> 95b5ea33d2e1cc4573841e1301dc1cf661e52d5c

    //    openList = new List<PathNode> { startNode };
    //    closedList = new List<PathNode>();

    //    for (int x = 0; x < grid.GetWidth(); x++)
    //    {
    //        for (int y = 0; y < grid.GetHeight(); y++)
    //        {
    //            PathNode pathNode = grid.GetGridObject(x, y);
    //            pathNode.gCost = int.MaxValue;
    //            pathNode.CalculateFCost();
    //            pathNode.cameFromNode = null;
    //        }
    //    }

    //    startNode.gCost = 0;
    //    startNode.hCost = CalculateDistanceCost(startNode, endNode);
    //    startNode.CalculateFCost();

<<<<<<< HEAD
    //    while (openList.Count > 0)
    //    {
    //        PathNode currentNode = GetLowestFCostNode(openList);
    //        if (currentNode == endNode)
    //        {
    //            return CalculatePath(endNode);
    //        }
=======
        PathFindingDebugStepVisual.Instance.ClearSnapshot();
        PathFindingDebugStepVisual.instance.TakeSnapshot(grid, startNode, openList, closedList);

        while (openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                PathFindingDebugStepVisual.Instance.TakeSnapshot(grid, currentNode, openList, closedList);
                PathFindingDebugStepVisual.Instance.TakeSnapshotFinalPath(grid, CalculatePath(endNode));
                return CalculatePath(endNode);
            }
>>>>>>> 95b5ea33d2e1cc4573841e1301dc1cf661e52d5c

    //        openList.Remove(currentNode);
    //        closedList.Add(currentNode);

            foreach (PathNode neighborNode in GetNeighbourList(currentNode))
            {
                if (closedList.Contains(neighborNode)) continue;
                if (!neighbourNode.isWalkable)
                {
                    closedList.Add(neighborNode);
                    continue;
                }

<<<<<<< HEAD
    //    }
    //}
=======
                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighborNode);
                if (tentativeGCost < neighborNode.gCost)
                {
                    neighborNode.cameFromNode = currentNode;
                    neighborNode.gCost = tentativeGCost;
                    neighborNode.hCost = CalculateDistanceCost(neighborNode, endNode);
                    neighborNode.CalculateFCost();

                    if (!openList.Contains(neighborNode))
                    {
                        openList.Add(neighborNode);
                    }
                }
            }
        }

        return null;
    }
>>>>>>> 95b5ea33d2e1cc4573841e1301dc1cf661e52d5c

    //private List<PathNode> GetNeighbourList(PathNode currentNode)
    //{
    //    List<PathNode> neighbourList = new List<PathNode>();

<<<<<<< HEAD
    //    if (currentNode.x - 1 >= 0)
    //    {
    //        neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y));
    //    }

    //private List<PathNode> CalculatePath(PathNode endNode)
    //{
    //    return null;
    //}
=======
        if (currentNode.x - 1 >= 0)
        {
            neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y));
            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
            if (currentNode.y + 1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
        }
        if (currentNode.x + 1 < grid.GetWidth())
        {
            neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y));
            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
            if (currentNode.y + 1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
        }
        if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x, currentNode.y - 1));
        if (currentNode.y + 1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.y - 1));

        return neighbourList;

    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        path.Reverse();
        return path;
    }
>>>>>>> 95b5ea33d2e1cc4573841e1301dc1cf661e52d5c

    //private int CalculateDistanceCost(PNode a, PNode b)
    //{
    //    int xDistance = Mathf.Abs(a.x - b.x);
    //    int yDistance = Mathf.Abs(a.y - b.y);
    //    int remaining = Mathf.Abs(xDistance - yDistance);
    //    return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    //}

<<<<<<< HEAD
    //private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    //{
    //    PathNode lowestFCostNode = pathNodeList[0];
    //    for (int i = 1; i < pathNodeList.Count; i++)
    //    {
    //        if (pathNodeList[i].fCost < lowestFCostNode.fCost)
    //        {
    //            lowestFCostNode = pathNodeList[i];
    //        }
    //    }
    //    return lowestFCostNode;
    //}
}
=======
    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        PathNode lowestFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++)
        {
            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = pathNodeList[i];
            }
        }
        return lowestFCostNode;
    }
}*/
>>>>>>> 95b5ea33d2e1cc4573841e1301dc1cf661e52d5c
