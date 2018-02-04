using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HandUI))]
[RequireComponent(typeof(Deck))]
public class Hand : MonoBehaviour {

    /// <summary>
    /// Maximum hand size allowed
    /// </summary>
    [SerializeField]
    private int MaxSize = 9;
    /// <summary>
    /// Initial hand size
    /// </summary>
    [SerializeField]
    private int InitSize = 5;

    /// <summary>
    /// Cards in the player hand
    /// </summary>
    private List<Card> m_pHand;
    public List<Card> pHand { get { return m_pHand; } }

    // Component refs
    private Deck deck;
    private HandUI handUI;

    private void Start()
    {
        deck = GetComponent<Deck>();
        handUI = GetComponentInChildren<HandUI>();
        DrawStartingHand();
        
    }

    // Draws a hand of size InitSize
    public void DrawStartingHand()
    {
        if(InitSize > MaxSize)
        {
            Debug.LogWarning("Init hand size too large. Drawing to max hand size.");
            InitSize = MaxSize;
        }
        m_pHand = deck.DrawCards(InitSize);
        foreach(Card c in m_pHand)
        {
            // Parents the card to the hand ui component
            c.transform.SetParent(handUI.transform);
        }
        handUI.UpdateScaling();
    }


}
