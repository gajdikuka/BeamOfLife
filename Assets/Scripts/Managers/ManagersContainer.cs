using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArShooter.Managers;

namespace ArShooter.Managers
{

	public class ManagersContainer : MonoBehaviour
	{
		public static ManagersContainer Instance;
//		public PoolManager poolManager;
//		public WavesManager wavesManager;
//		public EventManager globalEventsManager;
		// Use this for initialization
		void Awake ()
		{
			if (Instance == null) {
				Instance = this;
			} else {
				Destroy (gameObject);
			}
		
		}
		public T GetManager<T>(){
			T manager =  GetComponent<T> ();
			if (manager==null) {
				Debug.LogError ( "Manager does not exist");
			}
			return manager;
		}
	}
}