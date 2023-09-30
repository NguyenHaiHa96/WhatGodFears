using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data Config", menuName = "Scriptable Objects/Character Data Config")]
public class CharacterDataConfig : ScriptableObject
{
    public int ID;
    public string Name;
    public int HP;
}
