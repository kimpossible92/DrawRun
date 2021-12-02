using System.Collections;
using UnityEngine;

namespace Assets
{
    public class Bonus : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private UnitBattleIdentity _battleIdentity;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public void init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}