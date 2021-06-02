using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameZone _gameZone;
	[SerializeField] private Transform _grass;
	[SerializeField] private EnemyAI _prefab;
	
	public void Spawn(int count)
	{
		for (int i = 0; i < count; i++)
		{
			var offset = Random.insideUnitCircle * _gameZone.Size;
			Vector3 position = transform.position + new Vector3(offset.x, 0, offset.y);

			var enemy = Instantiate(_prefab, position, Quaternion.identity);
			enemy.Initialize(_gameZone, _grass);
		}
	}

	public void DestroyEnemy(ref int enemiesCount)
	{
		if (transform.position.y < _grass.transform.position.y)
		{
			Destroy(gameObject);
			enemiesCount--;
		}
	}
}