using System.Collections;
using UnityEngine;

namespace Assets
{
    public interface IDamagable
    {

        UnitBattleIdentity BattleIdentity { get; }

    }


    public enum UnitBattleIdentity
    {
        Runner,
        Bonus,
        Enemy
    }
}