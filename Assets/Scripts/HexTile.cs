using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType { BLANK, KING, VASSAL }

public class HexTile : MonoBehaviour
{

    #region Public Variables

    // Type [Needs Implementation]
    public TileType tileType;

    // Cubic Coordinates
    public Cubic CubicCoords;

    #endregion


    #region Private Variables

    // Id unique to each tile
    private int ID;

    // Material of highlighted tile
    [SerializeField]
    private Material matHighlighted;

    #endregion


    #region Monobehaviour Callbacks

    private void Awake()
    {
        CubicCoords = new Cubic(0, 0, 0);
    }

    #endregion


    #region Public Methods

    // Constructor
    public HexTile(Cubic _cubeCoord)
    {
        CubicCoords = _cubeCoord;
    }
    public void SetID(int _ID)
    {
        ID = _ID;
    }
    public int GetID()
    {
        return ID;
    }

    public void Highlight()
    {
        // Changes the material to highlight the tile
        MeshRenderer mesh = GetComponentInChildren<MeshRenderer>();
        mesh.material = matHighlighted;
    }

    #endregion

}