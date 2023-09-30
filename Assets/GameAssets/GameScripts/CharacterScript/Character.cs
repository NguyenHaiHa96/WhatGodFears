using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Sirenix.OdinInspector;

public class Character : UIElement
{
    [Title("Character")]
    [SerializeField] private CharacterDataConfig characterDataConfig;
    [SerializeField] private SkeletonGraphic skeletonGraphicCharacter;

    [Title("Stat", "HP")]
    [SerializeField] private int defaultHP;
    [SerializeField] private int startingHP;
    [SerializeField] private int bonusHP;
    [SerializeField] private int totalHP;
    [SerializeField] private int currentHP;

    private StateMachine<Character> stateMachine;

    #region Getter Setter
    public StateMachine<Character> StateMachine { get => stateMachine; set => stateMachine = value; }
    #endregion

    public void ChangeAnim(string anim, bool loop)
    {
        skeletonGraphicCharacter.AnimationState.SetAnimation(0, anim, loop);
    }

    private void Awake()
    {
        Setup();
    }

    public virtual void Setup()
    {
        InitStateMachine();
    }

    public virtual void InitStateMachine()
    {
        stateMachine = new StateMachine<Character>(this);
        stateMachine.SetCurrentState(CharacterSetupState.Instance);
        stateMachine.SetGlobalState(CharacterGlobalState.Instance);
        stateMachine.CurrentState.OnEnter(this);
        stateMachine.ChangeState(CharacterIdleState.Instance);
    }

    public virtual void SetStartingHP()
    {
        defaultHP = characterDataConfig.HP;
        startingHP = defaultHP; 
        totalHP = startingHP;
        currentHP = totalHP;
    }
}

