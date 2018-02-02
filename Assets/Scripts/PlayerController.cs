using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    HexBoard GameBoard;


	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(clickRay, out hit))
            {
                GameObject go = hit.transform.gameObject;
                HexTile tile = go.GetComponent<HexTile>();
                if(tile)
                {
                    int tileID = tile.GetID();
                    Debug.Log("Clicked Tile ID: " + tileID);
                    GameBoard.HighlightTile(tileID);
                }
            }


        }
	}
}
