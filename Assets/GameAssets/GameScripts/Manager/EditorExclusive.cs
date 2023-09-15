using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class EditorExclusive : GameSingleton<EditorExclusive>
{
    [Title("Editor Exclusive", "Reference")]
    public UICard UICardPrefab;

    [Button]
    private void SpawnCard(int numberOfCards)
    {
       StartCoroutine(CoSpawnCard(numberOfCards));
    }

    private IEnumerator CoSpawnCard(int numberOfCards)
    {
        List<UICard> ui_cards = new();
        for (int i = 0; i < numberOfCards; i++)
        {
            //UIManager.Instance.CanvasGameplay.UIHandCard.AddCardsToHand(ui_cards);
            UICard ui_Card = Instantiate(UICardPrefab);
            ui_cards.Add(ui_Card);
            yield return Helper.GetWaitForSeconds(1);
            ui_Card.StateMachine.ChangeState(CardOnDrawFromDrawPileState.Instance);
        }    
    }
}
