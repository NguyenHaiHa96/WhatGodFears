using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : GameSingleton<LevelManager>
{
    [SerializeField] private HeroController heroController;
    [SerializeField] private EnemyController enemyController;

    public override void FetchData()
    {
        base.FetchData();
        heroController = HeroController.Instance;
        enemyController = EnemyController.Instance;
        OnInit();
    }

    public override void OnInit()
    {
        base.OnInit();
        SetHeroPosition();
        SetEnemyPosition();
    }

    private void SetHeroPosition()
    {
        UIManager.Instance.CanvasGameplay.UICombatScene.SetHeroPosition(heroController.GetHero());
    }

    private void SetEnemyPosition()
    {
        UIManager.Instance.CanvasGameplay.UICombatScene.SetEnemyPosition(enemyController.GetEnemies());
    }
}
