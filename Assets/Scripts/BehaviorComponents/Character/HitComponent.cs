using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArShooter.BehaviorComponents.Interfaces;
using ArShooter.Managers;

namespace ArShooter.BehaviorComponents.Character
{
	public class HitComponent : MonoBehaviour, IPoolFeeder
	{
		public float power;
		[SerializeField]
		GameObject hitEffect;
		PoolManager poolManager;
		// Use this for initialization
		void Start ()
		{
			poolManager = ManagersContainer.Instance.GetManager<PoolManager>()	;
			FeedPoolManager ();	
		}

		#region IPoolFeeder implementation

		public void FeedPoolManager ()
		{
			poolManager.Init (new List<GameObject> (){ hitEffect });
		}

		#endregion

		void OnTriggerEnter (Collider coll)
		{
			Debug.Log ("Collision : " + coll.name);
			if (coll.CompareTag ("Character")) {
				coll.GetComponent<IDamagable> ().TakeDamage (power);

			}
			GameObject explosion = poolManager.Spawn (hitEffect.name);
			explosion.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			gameObject.SetActive (false);
		}
	}
}