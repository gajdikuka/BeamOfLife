using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ArShooter.Managers
{
	

	public class CustomUnityEvent : UnityEvent<Hashtable>
	{
	}

	public class EventManager : MonoBehaviour
	{

		private Dictionary  <string, CustomUnityEvent> eventDictionary;

		void Awake ()
		{
			Init ();
		}

		void Init ()
		{
			if (eventDictionary == null) {
				eventDictionary = new Dictionary<string, CustomUnityEvent> ();
			}
		}

		public  void StartListening (string eventName, UnityAction<Hashtable>listener)
		{
			CustomUnityEvent thisEvent = null;
			if (eventDictionary.TryGetValue (eventName, out thisEvent)) {
				thisEvent.AddListener (listener);
			} else {
				thisEvent = new CustomUnityEvent ();
				thisEvent.AddListener (listener);
				eventDictionary.Add (eventName, thisEvent);
			}
		}

		public  void StopListening (string eventName, UnityAction<Hashtable> listener)
		{
			CustomUnityEvent thisEvent = null;
			if (eventDictionary.TryGetValue (eventName, out thisEvent)) {
				thisEvent.RemoveListener (listener);
			}
		}

		public  void TriggerEvent (string eventName, Hashtable eventParams = default(Hashtable))
		{
			CustomUnityEvent thisEvent = null;
			if (eventDictionary.TryGetValue (eventName, out thisEvent)) {
				thisEvent.Invoke (eventParams);
			}
		}

		public  void TriggerEvent (string eventName)
		{
			TriggerEvent (eventName, null);
		}
	}
}