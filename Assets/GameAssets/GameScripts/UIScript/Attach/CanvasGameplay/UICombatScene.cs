using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICombatScene : UIElement 
{
    [Header("UI Combat Scene")]
    [SerializeField] private Transform tfHeroPosition;
    [SerializeField] private List<Transform> tfEnemyPositions;

    public Transform TfHeroPosition { get => tfHeroPosition; set => tfHeroPosition = value; }

    public void SetHeroPosition(Hero hero)
    {
        hero.SetTransformParent(tfHeroPosition);
        hero.WorldPosition = TfHeroPosition.position;  
    }


    public void SetEnemyPosition(List<Enemy> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetTransformParent(tfEnemyPositions[i]);
            enemies[i].WorldPosition = tfEnemyPositions[i].position;
        }
    }
}
