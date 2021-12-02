using System.Collections;
using UnityEngine;

namespace Assets
{
    public interface IDealer
    {
        UnitBattleIdentity BattleIdentity { get; }
    }
}