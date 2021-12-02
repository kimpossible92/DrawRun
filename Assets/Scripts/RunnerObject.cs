using System.Collections;
using UnityEngine;

namespace Assets
{
    public abstract class RunnerObject : MonoBehaviour,IDealer
    {
        [SerializeField]
        private float _speed;
        [SerializeField] private DrawAndRun _DrawRunners;
        [SerializeField] private GameObject fire;
        private UnitBattleIdentity _battleIdentity;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public GameObject Object => gameObject;
        public void Init(UnitBattleIdentity battleIdentity, DrawAndRun DrawRunners)
        {
            _battleIdentity = battleIdentity;
            _DrawRunners = DrawRunners;
        }
        private void Update()
        {
        }
        private void OnCollisionEnter(Collision other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();

            if (damagableObject != null
                && damagableObject.BattleIdentity == UnitBattleIdentity.Enemy)
            {
                _DrawRunners.Remove(this.GetComponent<Runner>());
                Instantiate(fire, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (damagableObject != null
                && damagableObject.BattleIdentity == UnitBattleIdentity.Bonus)
            {
                for (int i = 0; i < 5; i++)
                {
                    _DrawRunners.Add(this.GetComponent<Runner>());
                }
                Destroy(other.gameObject);
            }
        }
    }
}