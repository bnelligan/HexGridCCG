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
    private Material matDefault;
    bool highlighted = false;
    #endregion


    #region Monobehaviour Callbacks

    private void Awake()
    {
        CubicCoords = new Cubic(0, 0, 0);
        matDefault = GetComponentInChildren<MeshRenderer>().material;
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

    public void ToggleHighlight()
    {
        // Changes the material to highlight the tile
        if (!highlighted)
        {
            MeshRenderer mesh = GetComponentInChildren<MeshRenderer>();
            mesh.material = matHighlighted;
            highlighted = true;
        }
        else
        {
            MeshRenderer mesh = GetComponentInChildren<MeshRenderer>();
            mesh.material = matDefault;
            highlighted = false;
        }
        
    }

    #endregion

}