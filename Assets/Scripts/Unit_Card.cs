using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit_Card : Card {

    #region Protected Variables

    /// <summary>
    /// Unit ATK
    /// </summary>
    [SerializeField]
    protected int _Attack;

    /// <summary>
    /// Unit Initial Max HP (can overflow)
    /// </summary>
    [SerializeField]
    protected int _MaxHP;

    /// <summary>
    /// Cost of the card in Food
    /// </summary>
    [SerializeField]
    protected int _FoodCost;

    #region Access Variables
    public int Attack { get { return _Attack; } }
    public int MaxHP { get { return _MaxHP; } }
    public int FoodCost { get { return _FoodCost; } }
    #endregion

    #endregion



    #region Action Triggered Ability Delegates

    protected delegate void OnDeploy();
    protected OnDeploy onDeploy;

    protected delegate void OnCombatBegin();
    protected OnCombatBegin onCombatBegin;

    protected delegate void OnDeath();
    protected OnDeath onDeath;

    #endregion


    #region Turn Cycle Triggered Ability Delegates

    protected delegate void OnStartTurn();
    protected OnStartTurn onStartTurn;

    protected delegate void OnEndTurn();
    protected OnEndTurn onEndTurn;

    #endregion

}
