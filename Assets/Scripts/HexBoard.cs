using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoardBuilder))]
public class HexBoard : MonoBehaviour {

    #region Private Variables

    BoardBuilder Builder;
    List<HexTile> Board;

    #endregion


    #region MonoBehaviour Callbacks
    
    void Start()
    {
        // Get the boardbuilder and create a board
        Builder = GetComponent<BoardBuilder>();
        Board = Builder.BuildHexagonalBoard();
    }

    #endregion


    #region Public Methods

    // Highlights a tile for testing purposes
    public void HighlightTile(int TileID, bool Primary)
    {
        foreach (HexTile t in Board)
        {
            if (t.GetID() == TileID)
            {
                Debug.Log("Highlighting tile with ID " + t.GetID());
                if(Primary)
                {
                    t.TogglePrimaryHighlight();

                }
                else
                {
                    t.ToggleSecondaryHighlight();
                }
            }
        }
    }

    // Return a tile by it's cubic coordinates
    public HexTile GetTile(Cubic _CubicCoords)
    {
        foreach (HexTile t in Board)
        {
            if(t.CubicCoords == _CubicCoords)
            {
                return t;
            }
        }

        Debug.Log("Unable to find tile by cubic coordinates.");
        return null;
    }
    
    #endregion
}
