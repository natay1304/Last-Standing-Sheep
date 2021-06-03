using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public event Action OnAllEnemiesFallen;
	[SerializeField] private GameZone _gameZone;
	[SerializeField] private Transform _grass;
	[SerializeField] private EnemyAI _prefab;

	private List<EnemyAI> _enemies = new List<EnemyAI>();
	
	public void Spawn(int count)
	{
		for (int i = 0; i < count; i++)
		{
			var offset = Random.insideUnitCircle * _gameZone.Size;
			Vector3 position = transform.position + new Vector3(offset.x, 0, offset.y);

			var enemy = Instantiate(_prefab, position, Quaternion.identity);
			enemy.Initialize(_gameZone, _grass);
			enemy.OnFall += () => EnemyFallHandler(enemy);
			_enemies.Add(enemy);
		}
	}

	private void EnemyFallHandler(EnemyAI enemy)
	{
		_enemies.Remove(enemy);
		Destroy(enemy.gameObject);
		if (_enemies.Count == 0)
			OnAllEnemiesFallen?.Invoke();
	}
}