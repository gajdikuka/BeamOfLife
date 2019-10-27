using UnityEngine;
using System.Collections;
using ArShooter.Managers;
using ArShooter.BehaviorComponents.Interfaces;
using System.Collections.Generic;

namespace ArShooter.BehaviorComponents.Other
{
	

	public class FloorHitComponent : MonoBehaviour
	{
		GameManager gameManager;

		[SerializeField]
		GameObject hitEffect;
		PoolManager poolManager;
		// Use this for initialization
		void Start ()
		{
			poolManager = ManagersContainer.Instance.GetManager<PoolManager> ();
			gameManager = ManagersContainer.Instance.GetManager<GameManager>();
			FeedPoolManager ();
		}
		#region IPoolFeeder implementation

		public void FeedPoolManager ()
		{
			poolManager.Init (new List<GameObject> (){ hitEffect });
		}

		#endregion
		void OnCollisionEnter(Collision coll){

			if (coll.collider.CompareTag("Character")) {
				gameManager.AddScore (-10);
				GameObject effect = poolManager.Spawn (hitEffect.name);
				effect.transform.position = new Vector3 (coll.transform.position.x, coll.transform.position.y + 1f, coll.transform.position.z);
				effect.SetActive (true);

				coll.gameObject.GetComponent<EventManager> ().TriggerEvent (Constants.DeadEvent);
				coll.gameObject.SetActive (false);
//				coll.gameObject.GetComponent<IDamagable> ().TakeDamage (100);
			}
		
		}

	}

}