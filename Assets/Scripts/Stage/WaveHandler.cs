using Assets.Scripts.Enemies;
using Assets.Scripts.Gui;
using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Stage
{
    class WaveHandler : MonoBehaviour
    {
        [SerializeField] private LoaderSceneScreen _loaderSceneScreen;
        private Stage _stage;
        private int _indexWave;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private void Awake()
        {
            _indexWave = -1;
            _stage = Stage.CurrentStage;
        }

        private void Start()
        {
            SpawnNextWave();
        }

        private void OnDestroy()
        {
            foreach (Enemy enemy in _spawnedEnemies)
            {
                enemy.OnDeathRemoveListener(EnemyDeathHandler);
                enemy.OnEndTraceRemoveListener(EnemyEndTraceHandler);
            }
        }

        private void SpawnNextWave()
        {
            _indexWave++;
            if (_indexWave < _stage.Waves.Count)
            {
                foreach (Enemy enemy in _stage.Waves.ElementAt(_indexWave).Enemies)
                {
                    Enemy spawnedEnemy = Instantiate(enemy);
                    _spawnedEnemies.Add(spawnedEnemy);
                    spawnedEnemy.OnDeathAddListener(EnemyDeathHandler);
                    spawnedEnemy.OnEndTraceAddListener(EnemyEndTraceHandler);
                }
            }
            else
            {
                StartCoroutine(WaitAndGoToMenu());
            }
        }

        private void EnemyDeathHandler(Enemy killedEnemy, Enemy nextPhase)
        {
            if (nextPhase != null)
            {
                _spawnedEnemies.Add(nextPhase);
                nextPhase.OnDeathAddListener(EnemyDeathHandler);
                nextPhase.OnEndTraceAddListener(EnemyEndTraceHandler);
            }
            RemoveFromList(killedEnemy);
        }

        private void EnemyEndTraceHandler(Enemy enemy)
        {
            RemoveFromList(enemy);
        }

        private void RemoveFromList(Enemy enemy)
        {
            _spawnedEnemies.Remove(enemy);

            if (_spawnedEnemies.Count == 0)
            {
                SpawnNextWave();
            }
        }

        private IEnumerator WaitAndGoToMenu()
        {
            yield return new WaitForSeconds(5f);
            _loaderSceneScreen.LoadScene(ScenesEnum.MenuStages);
        }
    }
}
