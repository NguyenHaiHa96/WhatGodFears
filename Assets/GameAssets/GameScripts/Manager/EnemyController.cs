using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : GameSingleton<EnemyController>   
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Enemy enemy;
    [SerializeField] private List<Enemy> enemies;

    #region Getter Setter
    public List<Enemy> GetEnemies() => enemies;
    #endregion

    public override void FetchData()
    {
        base.FetchData();
        InitEnemy();
    }

    private void InitEnemy()
    {
        enemy = Instantiate(enemyPrefab);   
        enemies.Add(enemy);
    }
}
