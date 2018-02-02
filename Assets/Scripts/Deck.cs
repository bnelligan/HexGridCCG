using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    #region Private Variables

    /// <summary>
    /// Maxumum deck size
    /// </summary>
    [SerializeField]
    private int DeckSize = 60;

    /// <summary>
    /// ID unique to each deck
    /// </summary>
    private int DeckID;

    /// <summary>
    /// List of cards in the deck
    /// </summary>
    private List<Card> pDeck;

    #endregion


    #region Testing Vars

    [SerializeField]
    Card testCard;

    #endregion


    #region Unity Callbacks

    private void Awake()
    {
        //pDeck = LoadDeck(0); // WON'T WORK YET! ADD TESTING CASES!

        // Load a deck of test cards
        pDeck = LoadTest();

        // Shuffling doesn't work yet
        //Shuffle();
    }

    #endregion


    #region Public Methods

    // Draw a card from deck
    public Card DrawCard()
    {
        if (pDeck.Capacity > 0)
        {
            Card c = pDeck[0];
            Debug.Log("Drew " + c.name);
            pDeck.Remove(c);
            return c;
        }
        else
        {
            Debug.Log("Could not draw a card. Deck is empty.");
            return null;
        }
            
    }

    // Draw X cards from the deck
    public List<Card> DrawCards(int count)
    {
        List<Card> drawnCards = new List<Card>();
        for(int i = 0; i < count; i++)
        {
            Card c = DrawCard();
            if(c)
            {
                drawnCards.Add(c);
            }
        }
        return drawnCards;
    }

    // ------ NEEDS IMPLEMENTATION ------
    // Load a deck by deck ID
    public List<Card> Load(int deckId)
    {
        // TEMPORARY! NEEDS IMPLEMENTATION
        return new List<Card>();


    }
    // Load a deck of test cards
    public List<Card> LoadTest()
    {
        DeckID = 0;
        List<Card> tDeck = new List<Card>();

        // Add cards to the deck up the max size
        // Probably a better way than a loop
        for (int i = 0; i < DeckSize; i++)
        {
            Card tCard = Instantiate(testCard, transform);
            tDeck.Add(tCard);
        }
        return tDeck;
    }

    // ------ NOT TESTED ------
    // Shuffles the deck up
    public void Shuffle()
    {
        // Shuffled Cards moved here
        List<Card> ShuffledDeck = new List<Card>();

        // Pick random cards to move over to new deck
        while(pDeck.Capacity > 0)
        {
            int remIndex = Random.Range(0, pDeck.Capacity-1);
            ShuffledDeck.Add(pDeck[remIndex]);
            pDeck.RemoveAt(remIndex);
        }

        pDeck = ShuffledDeck;
    }

    #endregion
}
