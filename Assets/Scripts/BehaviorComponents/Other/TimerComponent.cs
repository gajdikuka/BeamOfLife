using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArShooter.Managers;

public class TimerComponent : MonoBehaviour {

	float timer;
	EventManager globalEventsManager;
	// Use this for initialization
	void Start () {
		timer = 0;
		globalEventsManager = ManagersContainer.Instance.GetManager<EventManager>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		globalEventsManager.TriggerEvent (Constants.TimerUpdatedEvent, new Hashtable (){ { Constants.NewValueParam1, timer } });
	}
}
