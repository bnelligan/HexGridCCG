using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBuilder : MonoBehaviour {

    [SerializeField]
    HexTile objTile;

    // Amount to adjust spawn location by
    float dz = 6.5f;
    float dx = 11f;

    /// <summary>
    /// Radius of hex shaped board not including center HexTile.
    /// </summary>
    [SerializeField]
    int hexRadius;
    
    public List<HexTile> BuildHexagonalBoard()
    {
        // Ensure there is a HexTile
        if (!objTile)
        {
            Debug.Log("Unable to create board. No HexTile prefab selected.");
            return null;
        }
        // Board Array
        List<HexTile> gameBoard = new List<HexTile>();
        
        // Movement Vectors
        Vector3 DownRight = new Vector3(dx,  0f, -dz);
        Vector3 DownDown  = new Vector3(0f,  0f, -2*dz);
        Vector3 DownLeft  = new Vector3(-dx, 0f, -dz);
        Vector3 UpLeft    = new Vector3(-dx, 0f, +dz);
        Vector3 UpUp      = new Vector3(0f,  0f, 2*dz);
        Vector3 UpRight   = new Vector3(dx,  0f, dz);

        
        // Set inital spawn location to HexTile.
        Vector3 SpawnLocation = Vector3.zero;
        Cubic SpawnCoord = new Cubic(0, 0, 0);
        int TileID = 0;

        // Spawn initial HexTile in board center
        HexTile centerTile = SpawnTile(SpawnLocation, SpawnCoord, TileID);
        gameBoard.Add(centerTile);


        // Loop through each layer of HexTiles
        for (int r = 1; r <= hexRadius; r++)
        {
            // Top HexTile as start position
            SpawnLocation += UpUp;
            SpawnCoord.Cube_Add(Cubic.N);

            // Top Right
            for (int i = 1; i <= r; i++)
            {
                SpawnLocation += DownRight;
                SpawnCoord.Cube_Add(Cubic.SE);
                HexTile tempTile = SpawnTile(SpawnLocation, SpawnCoord, ++TileID);
                gameBoard.Add(tempTile);
            }
            // Right
            for (int i = 1; i <= r; i++)
            {
                SpawnLocation += DownDown;
                SpawnCoord.Cube_Add(Cubic.S);
                HexTile tempTile = SpawnTile(SpawnLocation, SpawnCoord, ++TileID);
                gameBoard.Add(tempTile);
            }
            // Bottom Right
            for (int i = 1; i <= r; i++)
            {
                SpawnLocation += DownLeft;
                SpawnCoord.Cube_Add(Cubic.SW);
                HexTile tempTile = SpawnTile(SpawnLocation, SpawnCoord, ++TileID);
                gameBoard.Add(tempTile);
            }
            // Bottom Left
            for (int i = 1; i <= r; i++)
            {
                SpawnLocation += UpLeft;
                SpawnCoord.Cube_Add(Cubic.NW);
                HexTile tempTile = SpawnTile(SpawnLocation, SpawnCoord, ++TileID);
                gameBoard.Add(tempTile);
            }
            
            // Left
            for (int i = 1; i <= r; i++)
            {
                SpawnLocation += UpUp;
                SpawnCoord.Cube_Add(Cubic.N);
                HexTile tempTile = SpawnTile(SpawnLocation, SpawnCoord, ++TileID);
                gameBoard.Add(tempTile);
            }
            // Top Right
            for (int i = 1; i <= r; i++)
            {
                SpawnLocation += UpRight;
                SpawnCoord.Cube_Add(Cubic.NE);
                HexTile tempTile = SpawnTile(SpawnLocation, SpawnCoord, ++TileID);
                gameBoard.Add(tempTile);
            }
        }

        return gameBoard;

    }

    // Create a new HexTile and set its ID
    public HexTile SpawnTile(Vector3 SpawnLocation, Cubic SpawnCoord, int ID)
    {
        HexTile tTile = Instantiate(objTile, SpawnLocation, Quaternion.Euler(0f, 0f, 0f), transform);
        tTile.SetID(ID);
        Debug.Log("HexTile Spawned. Coords are: x=" + SpawnCoord.x + " y=" + SpawnCoord.y + " z=" + SpawnCoord.z);
        Debug.Log("ID: " + ID);
        tTile.CubicCoords = SpawnCoord;
        return tTile;
    }
}
