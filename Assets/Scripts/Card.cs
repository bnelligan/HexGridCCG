using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Card : MonoBehaviour {

    #region Protected Variables

    /// <summary>
    /// The card's name
    /// </summary>
    [SerializeField]
    protected string _CardName;
    
    /// <summary>
    /// Unique ID for each card [Set + CardNum]
    /// </summary>
    [SerializeField]
    protected string _CardID;
    
    /// <summary>
    /// Cost of the card in Gold
    /// </summary>
    [SerializeField]
    protected int _GoldCost;
    

    #region Access Variables
    public string CardName{ get { return _CardName; } }
    public string CardID { get { return _CardID; } }
    public int GoldCost { get { return _GoldCost; } }
    #endregion

    #endregion


    #region Public Methods

    /// <summary>
    /// NEEDS IMPLEMENTATION
    /// </summary>
    /// <param name="ID"></param>
    //public void LoadCardByID(string ID){ }

    #endregion
}
