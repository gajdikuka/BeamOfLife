using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArShooter.Managers;

namespace ArShooter.Controllers.Ui
{
	

	public class HudController : MonoBehaviour
	{

		[SerializeField]
		Text timerText, waveText, scoreText;
		EventManager globalEventsManager;

		// Use this for initialization
		void Start ()
		{
			globalEventsManager = ManagersContainer.Instance.GetManager<EventManager>();
			globalEventsManager.StartListening (Constants.TimerUpdatedEvent, OnTimerUpdated);
			globalEventsManager.StartListening (Constants.ScoreEvent, OnScoreChanged);
			globalEventsManager.StartListening (Constants.WaveEvent, OnWaveChanged);
		}

		void OnTimerUpdated (Hashtable eventParams)
		{
			if (eventParams.Contains (Constants.NewValueParam1)) {
				float time = (float)eventParams [Constants.NewValueParam1];
				string timeToDisplay = (time / 60).ToString ("00") + ":" + (time % 60).ToString ("00");
				timerText.text = timeToDisplay;
			}
		}

		void OnWaveChanged (Hashtable eventParams)
		{
			if (eventParams.Contains (Constants.NewValueParam1)) {
				waveText.text = "Wave :" +  ((int) eventParams[Constants.NewValueParam1]).ToString();
			}	
		}

		void OnScoreChanged (Hashtable eventParams)
		{
			if (eventParams.Contains (Constants.NewValueParam1)) {
				scoreText.text =  "Score : " + ((int) eventParams[Constants.NewValueParam1]).ToString();
			}	
		}
	}

}