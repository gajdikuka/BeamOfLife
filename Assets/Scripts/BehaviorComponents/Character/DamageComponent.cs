using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArShooter.Managers;
using ArShooter.BehaviorComponents.Interfaces;

namespace ArShooter.BehaviorComponents.Character
{
	[RequireComponent (typeof(EventManager))]
	public class DamageComponent : MonoBehaviour, IDamagable, IPoolFeeder
	{
		[SerializeField]
		GameObject damageEffect;
		EventManager eventManager;
		PoolManager poolManager;

		void Awake ()
		{
			
		}
		// Use this for initialization
		void Start ()
		{
			poolManager = ManagersContainer.Instance.GetManager<PoolManager> ();
			eventManager = GetComponent<EventManager> ();
			FeedPoolManager ();
		}

		#region IPoolFeeder implementation

		public void FeedPoolManager ()
		{
			poolManager.Init (new List<GameObject> (){ damageEffect });
		}

		#endregion

		public void TakeDamage (float amount)
		{
			Debug.Log ("Take damage");
			GameObject effect = poolManager.Spawn (damageEffect.name);
			effect.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			effect.SetActive (true);
			eventManager.TriggerEvent (Constants.DamageEvent, new Hashtable (){ { Constants.NewValueParam1, amount } });

		}

	}
}