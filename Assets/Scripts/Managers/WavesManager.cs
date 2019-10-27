using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ArShooter.Managers
{
	

	public class WavesManager : MonoBehaviour, IPoolFeeder
	{
		[SerializeField]
		int currentWave = 0, enemiesLeft;
		[SerializeField]
		Transform SpawnPoints;
		[SerializeField]
		int maxEnemies, minEnemies;
		PoolManager poolManager;
		EventManager globalEventsManager;
		[SerializeField]
		GameObject enemy;

		void Start ()
		{
			poolManager = ManagersContainer.Instance.GetManager<PoolManager>();
			globalEventsManager = ManagersContainer.Instance.GetManager<EventManager>();
			FeedPoolManager ();
			globalEventsManager.StartListening (Constants.MarkerTrackEvent, OnTrackedImageStatusChange);
//			StartCoroutine (CreateWave ());

		}

		void OnTrackedImageStatusChange (Hashtable eventParams)
		{
			bool isTracking = (bool)(eventParams [Constants.NewValueParam1]); 
			if (isTracking && enemiesLeft <= 0) {
				StartCoroutine (CreateWave ());
			}
		}

		public void FeedPoolManager ()
		{
			List<GameObject> poolables = new List<GameObject> (){ enemy };
			poolManager.Init (poolables, true);
		}

		IEnumerator CreateWave ()
		{
			yield return new WaitForSeconds (2f);
			currentWave += 1;
			globalEventsManager.TriggerEvent (Constants.WaveEvent, new Hashtable (){ { Constants.NewValueParam1, currentWave } });
			enemiesLeft = Random.Range (minEnemies, maxEnemies);
			Debug.Log ("enemiesLeft ; " + enemiesLeft);
			for (int i = 0; i < enemiesLeft; i++) {
				yield return new WaitForSeconds (0.1f);
//				poolManager.ShowAllDictKeys ();
				GameObject newEnemy = poolManager.Spawn (enemy.name);
//				newEnemy.transform.SetParent (null);
				newEnemy.gameObject.SetActive (true);
				Debug.Log ("Spawning " + i);
				newEnemy.transform.position = GetRandomSpawnPos ().position;
				EventManager enemyEventManager = newEnemy.transform.GetComponentInChildren<EventManager> (true);
				enemyEventManager.TriggerEvent (Constants.RespawnEvent);
				enemyEventManager.StopListening ("Dead", OnEnemyDeath);
				enemyEventManager.StartListening ("Dead", OnEnemyDeath);

			}

//			foreach (Transform item in SpawnPoints) {
//				i += 1;
//				yield return new WaitForSeconds (0.1f);
//				CharacterInit newEnemy = PoolManager.instance.GetEnemy (EnemyType.Tower);//TODO; radomize enemy
//				//			if (i>=SpawnPoints.Length) {
//				if (item.name == "Monster") {
//					newEnemy = PoolManager.instance.GetEnemy (EnemyType.Allien);
//				}
//				newEnemy.oCharacter.State = State.Idle;
//				newEnemy.transform.parent.transform.position = item.position;
//				//newEnemy.gameObject.SetActive (true);
//				//////Debug.Log ("newEnemy : " + newEnemy.name + " active? : " + newEnemy.gameObject.activeInHierarchy);
//				newEnemy.gameObject.SetActive (true);
//				newEnemy.transform.parent.gameObject.SetActive (true);
//
//				newEnemy.oCharacter.CharacterType.Health.Max += currentWave * 3;
//				newEnemy.oCharacter.CharacterType.Health.Current = newEnemy.oCharacter.CharacterType.Health.Max;
//				newEnemy.oCharacter.eDead -= EnemyDefeated;
//				newEnemy.oCharacter.eDead += EnemyDefeated;
//				newEnemy.oCharacter.IsDead = false;
//
//			}

		}

		void OnEnemyDeath (Hashtable eventParams)
		{
			enemiesLeft -= 1;
			if (enemiesLeft <= 0) {
				Debug.Log ("NeextWave");
				StartCoroutine (CreateWave ());
			}
		}

		public Transform GetRandomSpawnPos ()
		{
			return SpawnPoints.GetChild (UnityEngine.Random.Range (0, SpawnPoints.GetComponentsInChildren<Transform> ().Length - 1));
		}

	}

}