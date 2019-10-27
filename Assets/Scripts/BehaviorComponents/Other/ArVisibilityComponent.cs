using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArShooter.Managers;

namespace ArShooter.BehaviorComponents.Other
{
	

	public class ArVisibilityComponent : MonoBehaviour
	{
		EventManager globalEventsManager;
		[SerializeField]
		GameObject childGo;
//		[SerializeField]
		GameObject arParent;
		// Use this for initialization

		void Awake(){
//			arParent = GameObject.FindGameObjectWithTag ("ArParent").gameObject;
//			gameObject.transform.SetParent (arParent.transform);
		}
		void Start ()
		{
			globalEventsManager = ManagersContainer.Instance.GetManager<EventManager> ();
			globalEventsManager.StartListening(Constants.MarkerTrackEvent,OnTrackedMarkerChanged);


		}
		void OnTrackedMarkerChanged(Hashtable eventParams){
			if (eventParams.ContainsKey(Constants.NewValueParam1)) {
				bool shouldShow = (bool) eventParams [Constants.NewValueParam1];
//				childGo.SetActive (shouldShow);
				if (shouldShow) {
//					childGo.transform.SetParent (arParent.transform);
				}

				                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        		}
		}
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}