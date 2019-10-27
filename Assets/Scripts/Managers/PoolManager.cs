using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ArShooter.Managers.Helpers;
using ArShooter.Managers.Interfaces;

namespace ArShooter.Managers
{


	public class PoolManager : MonoBehaviour,IPool
	{
		[SerializeField]
		Dictionary <string,List<GameObject>> pools;
		[SerializeField]
		GameObject arParent;
		private string parentSufix = "_Parent";
		private string newPoolSufix = "_Pool";


		void Awake ()
		{
			pools = new Dictionary<string, List<GameObject>> ();
//			Init ();

		}

		public void ShowAllDictKeys ()
		{
		
			for (int i = 0; i < pools.Keys.Count; i++) {
				Debug.Log (pools.Keys.ToList () [i]);
			}
		}

		public GameObject Despawn (string key, string name, bool detach = false)
		{
			GameObject go = pools [key + newPoolSufix].Find (x => x.activeSelf == true && x.name == name);
			if (go != null) {
				go.SetActive (false);
				if (detach) {
					Transform poolParent = transform.Find (name + parentSufix);
					if (poolParent == null) {
						Debug.LogError ("PoolParent for " + name + " does not exist");
					}
					go.transform.SetParent (poolParent);
				}
		
			}
			return go;
		}

		public GameObject Spawn (string key)
		{
//			Debug.Log ("key ; " + key);
			GameObject go = pools [key + newPoolSufix].Find (x => x.activeInHierarchy == false);
//			Debug.Log ("index of spanwed obejct : " + pools [key + newPoolSufix].IndexOf (go));
			if (go != null) {
				go.SetActive (true);
				return go;
			} else {
//				Debug.LogError ("Object not found : " + key);
				go = Instantiate (pools [key + newPoolSufix].FirstOrDefault ());
				go.name = go.name.Replace ("(Clone)", "");
				pools [key + newPoolSufix].Add (go);

//				Debug.Log ("go.name + parentSufix ; " + go.name + parentSufix);
				go.transform.SetParent (transform.Find (go.name + parentSufix));
			}

			return go;
		}

		public void Init (List<GameObject> poolablesGo, bool isAr=false)
		{
		

//			Debug.Log ("Init POOL ");
			List<IPoolable> poolables = new List<IPoolable> ();

			if (poolablesGo == null) {
				poolables = GetComponentsInChildren<IPoolable> ().ToList ();
			} else {
				poolables = new List<IPoolable> ();
				for (int i = 0; i < poolablesGo.Count; i++) {
					poolables.Add (poolablesGo [i].GetComponent<IPoolable> ());
				}
			}

//			Debug.Log ("poolables : " + poolables[0].Name);
//			Debug.Log ("poolables : " + poolables[1].Name);

			foreach (IPoolable item in poolables) {
				string newKey = item.Name + newPoolSufix;
				if (!pools.ContainsKey (newKey)) {
					
					List<GameObject> newPool = new List<GameObject> ();
					Debug.Log ("item.Name + newPoolSufix : " + item.Name + newPoolSufix);
					pools.Add (newKey, newPool);
					GameObject poolParent = new GameObject ();
	
					poolParent.name = item.Name + parentSufix;
					poolParent.transform.SetParent (transform);
					if (isAr) {
						poolParent.transform.SetParent (arParent.transform);
					}
					for (int i = 0; i < item.Count; i++) {
						GameObject newGo = Instantiate (item.MyTransform.gameObject);
						newGo.SetActive (false);
						newGo.name = item.MyTransform.name; //+ i.ToString (); 
						newGo.transform.SetParent (poolParent.transform);
						newPool.Add (newGo);
					}
				}

			}
		}


	}
}