using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class HeroController : GameSingleton<HeroController>
{
    [SerializeField] private Hero heroPrefab;
    [SerializeField] private Hero hero;

    #region Getter Setter
    public Hero GetHero() => hero;
    #endregion

    public override void FetchData()
    {
        base.FetchData();
        InitHero(); 
    }

    private void InitHero()
    {
        hero = Instantiate(heroPrefab);
    }
}
