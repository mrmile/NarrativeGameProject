using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinder_Manager : MonoBehaviour
{
    public Tilemap tilemap;    
    public Vector3Int[,] spots;
    
    Astar astar;
    List<Spot> path = new List<Spot>();
    new Camera camera;
    BoundsInt bounds;
    
    void Start()
    {
        tilemap.CompressBounds();
        
        bounds = tilemap.cellBounds;
        camera = Camera.main;


        CreateGrid();
        astar = new Astar(spots, bounds.size.x, bounds.size.y);
    }
    public void CreateGrid()
    {
        spots = new Vector3Int[bounds.size.x, bounds.size.y];
        for (int x = bounds.xMin, i = 0; i < (bounds.size.x); x++, i++)
        {
            for (int y = bounds.yMin, j = 0; j < (bounds.size.y); y++, j++)
            {
                if (tilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    spots[i, j] = new Vector3Int(x, y, 0);
                }
                else
                {
                    spots[i, j] = new Vector3Int(x, y, 1);
                }
            }
        }
    }
       
    void Update()
    {

       
    }

    public List<Vector3> CreatePath(Vector3 startPos, Vector3 endPos)
    {
        List<Vector3> finalPath = new List<Vector3>();

        Vector2Int startGridPos = (Vector2Int) tilemap.WorldToCell(startPos);
        Vector2Int endGridPos = (Vector2Int)tilemap.WorldToCell(endPos);

        CreateGrid();

        

        if (path != null && path.Count > 0)
            path.Clear();

        path = astar.CreatePath(spots, startGridPos, endGridPos, 100);
        if (path == null)
            return finalPath;

        for(int i = 0; i < path.Count; i++)
        {
            finalPath.Add(tilemap.CellToWorld(new Vector3Int(path[i].X, path[i].Y, 0)));
           
        }

        return finalPath;
    }
}