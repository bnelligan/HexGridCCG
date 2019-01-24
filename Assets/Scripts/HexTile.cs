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
    private Material matDefault;
    [SerializeField]
    private Material matPrimaryHighlight;
    [SerializeField]
    private Material matSecondaryHighlight;
    MeshRenderer mesh;
    bool primaryHighlightActive;
    bool secondaryHighlightActive;
    #endregion


    #region Monobehaviour Callbacks

    private void Awake()
    {
        mesh = GetComponentInChildren<MeshRenderer>();
        CubicCoords = new Cubic(0, 0, 0);
        matDefault = mesh.material;
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

    public void TogglePrimaryHighlight()
    {
        // Changes the material to highlight the tile
        if (!primaryHighlightActive)
        {
            mesh.material = matPrimaryHighlight;
            primaryHighlightActive = true;
            secondaryHighlightActive = false;
        }
        else
        {
            mesh.material = matDefault;
            primaryHighlightActive = false;
        }
        
    }
    public void ToggleSecondaryHighlight()
    {
        if(!secondaryHighlightActive)
        {
            mesh.material = matSecondaryHighlight;
            secondaryHighlightActive = true;
            primaryHighlightActive = false;
        }
        else
        {
            mesh.material = matDefault;
            secondaryHighlightActive = false;
        }
    }

    #endregion

}