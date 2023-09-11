using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandCard : GameUnit
{
    [Header("UI Hand Card")]
    public Transform TfThreshold;
    public Transform TfCardContainer;
    public List<UICard> UICardsInHand;

    public int NumberOfCards;

    public void AddCardsToHand(List<UICard> ui_cards)
    {
        for (int i = 0; i < ui_cards.Count; i++)
        {
            ui_cards[i].SetTransformParent(TfCardContainer);
            UICardsInHand.Add(ui_cards[i]);          
        }

        for (int i = 0; i < UICardsInHand.Count; i++)
        {
            UICardsInHand[i].SetOrder(i, this);
        }
    }

    public void ReturnCardToHand(UICard ui_Card)
    {

    }
}
