using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinding
{
    //private const int MOVE_STRAIGHT_COST = 10;
    //private const int MOVE_DIAGONAL_COST = 14;

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

    //    while (openList.Count > 0)
    //    {
    //        PathNode currentNode = GetLowestFCostNode(openList);
    //        if (currentNode == endNode)
    //        {
    //            return CalculatePath(endNode);
    //        }

    //        openList.Remove(currentNode);
    //        closedList.Add(currentNode);


    //    }
    //}

    //private List<PathNode> GetNeighbourList(PathNode currentNode)
    //{
    //    List<PathNode> neighbourList = new List<PathNode>();

    //    if (currentNode.x - 1 >= 0)
    //    {
    //        neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y));
    //    }

    //private List<PathNode> CalculatePath(PathNode endNode)
    //{
    //    return null;
    //}

    //private int CalculateDistanceCost(PNode a, PNode b)
    //{
    //    int xDistance = Mathf.Abs(a.x - b.x);
    //    int yDistance = Mathf.Abs(a.y - b.y);
    //    int remaining = Mathf.Abs(xDistance - yDistance);
    //    return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    //}

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
