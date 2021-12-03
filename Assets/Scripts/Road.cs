using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private Obstacle _obstacle;
        [SerializeField] private Bonus bonus;
        List<Obstacle> _Obstacles = new List<Obstacle>();
        List<Bonus> bonuses = new List<Bonus>();
        public GameObject Instatce(float px1, float py1, float pz1, float numScale, UnitBattleIdentity _battleidentity)
        {
            if (_battleidentity == UnitBattleIdentity.Enemy)
            {
                var obstacle = Instantiate(_obstacle, new Vector3(px1, py1, pz1), Quaternion.identity);
                obstacle.init(_battleidentity);
                _Obstacles.Add(obstacle.GetComponent<Obstacle>());
                FinishPosition = obstacle.transform.position;
                return obstacle.gameObject;
            }
            else
            {
                var _bonus = Instantiate(bonus, new Vector3(px1, py1, pz1), Quaternion.identity);
                _bonus.init(_battleidentity);
                bonuses.Add(_bonus.GetComponent<Bonus>());
                FinishPosition = _bonus.transform.position;
                return _bonus.gameObject;
            }
        }
        public void loadZero()
        {
            foreach (var p in _Obstacles)
            {
                if (p != null) Destroy(p.gameObject);
            }
            _Obstacles.Clear();
            //foreach (var p in projectiles)
            //{
            //    if (p != null) Destroy(p.gameObject);
            //}
            //projectiles.Clear();
        }
        // Use this for initialization
        void Start()
        {
            loadRoad();
        }
        int saver = 0;
        public int Save => saver;
        [SerializeField] int Count;
        private Vector3 FinishPosition = Vector3.zero;
        public Vector3 _FinishPosition => FinishPosition;
        public void loadRoad()
        {
            saver = 0;
            for (int i = 0; i < Count; i++)
            {
                int xrandom = Random.Range(-1, 2);
                UnitBattleIdentity battleIdentity_ = (UnitBattleIdentity)Random.Range(1, 3);
                saver += Random.Range(6, 13);
                Instatce(xrandom, 2.48f, saver, 1,battleIdentity_);
                Instatce(Random.Range(-1, 2), 2.48f, saver, 1, (UnitBattleIdentity)Random.Range(1, 3));
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}