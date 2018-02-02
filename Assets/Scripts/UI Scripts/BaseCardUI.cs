using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCardUI : MonoBehaviour {

    RectTransform rTrans;
    [SerializeField]
    protected Text CardName;
    [SerializeField]
    protected Text CardID;
    [SerializeField]
    protected Text Gold;

    private void Start()
    {
        rTrans = GetComponent<RectTransform>();
        SetupUI();
    }

    public abstract void SetupUI();
    public abstract void UpdateUI();
    
}
