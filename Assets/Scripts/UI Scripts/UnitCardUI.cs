using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCardUI : BaseCardUI {

    [SerializeField]
    Text Food;
    [SerializeField]
    Text Atk;
    [SerializeField]
    Text HP;

    Unit_Card cardInfo;
    private void Start()
    {
        cardInfo = GetComponent<Unit_Card>();
        SetupUI();
    }

    // Set up the card UI
    public override void SetupUI()
    {
        CardName.text = cardInfo.CardName;
        CardID.text = cardInfo.CardID;
        Gold.text = cardInfo.GoldCost.ToString();

        Food.text = cardInfo.FoodCost.ToString();
        Atk.text = cardInfo.Attack.ToString();
        HP.text = cardInfo.MaxHP.ToString(); // Set hp to the card's max hp to begin with
        
    }

    // Update the card UI based on changes
    public override void UpdateUI()
    {
        CardName.text = cardInfo.CardName;
        CardID.text = cardInfo.CardID;
        Gold.text = cardInfo.GoldCost.ToString();

        Food.text = cardInfo.FoodCost.ToString();
        Atk.text = cardInfo.Attack.ToString();
        HP.text = cardInfo.MaxHP.ToString();
    }

}
