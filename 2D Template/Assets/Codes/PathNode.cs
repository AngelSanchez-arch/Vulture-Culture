/*using UnityEngine;

public class PathNode
{
    //private Grid<PathNode> grid;
    //private int x;
    //private int y;

    //public int gCost;
    //public int hCost;
    //public int fCost;

<<<<<<< HEAD
    //public PathNode cameFromNode;

    //public PathNode(Grid<PathNode> grid, int x, int y)
    //{
    //    this.grid = grid;
    //    this.x = x;
    //    this.y = y;
    //}
=======
    public bool isWalkable;
    public PathNode cameFromNode;

    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
    }
>>>>>>> 95b5ea33d2e1cc4573841e1301dc1cf661e52d5c

    //public void CalculateFCost()
    //{
    //    fCost = gCost + hCost;
    //}

<<<<<<< HEAD
    //public override string ToString()
    //{
    //    return x + "," + y;
    //}
=======
    public void SetIsWalkable(bool isWalkable)
    {
        this.isWalkable = isWalkable;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return x + "," + y;
    }
>>>>>>> 95b5ea33d2e1cc4573841e1301dc1cf661e52d5c
}
*/
