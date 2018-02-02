using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour {

    /// <summary>
    /// Transform of Hand Area
    /// </summary>
    private RectTransform rTrans;

    /// <summary>
    /// Gap between cards & edge
    /// </summary>
    [SerializeField]
    private float _CardPadding;
    /// <summary>
    /// Gap between hand and the screen sides
    /// </summary>
    [SerializeField]
    private float _HorizPadding;
    /// <summary>
    /// Gap between hand and screen bottom
    /// </summary>
    [SerializeField]
    private float _BotPadding;
    /// <summary>
    /// Reference to the player's hand
    /// </summary>
    [SerializeField]
    Hand playerHand;
    

    private void Start()
    {
        rTrans = GetComponent<RectTransform>();
    }

    // Update the card positions
    public void UpdateScaling()
    {
        List<Card> cards = playerHand.pHand;
        float HandWidth = Screen.width - (2*_HorizPadding);
        float dx = HandWidth / cards.Count; // div by 0 check required
        
        // Move each card into place
        for(int x = 0; x < cards.Count; x++)
        {
            cards[x].transform.position = new Vector3(_HorizPadding + x * dx, _BotPadding, 1);
        }
    }

}
