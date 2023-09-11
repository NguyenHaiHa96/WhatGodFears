using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EditorExclusive : GameSingleton<EditorExclusive>
{
    [Title("Editor Exclusive", "Reference")]
    public UICard UICardPrefab;

    [Button]
    private void SpawnCard(int numberOfCards)
    {
        List<UICard> cards = new();
        for (int i = 0; i < numberOfCards; i++)
        {
            UICard ui_Card = Instantiate(UICardPrefab);
            cards.Add(ui_Card);
        }
        UIManager.Instance.CanvasGameplay.UIHandCard.AddCardsToHand(cards);
    }

}
