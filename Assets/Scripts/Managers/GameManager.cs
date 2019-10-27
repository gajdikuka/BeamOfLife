using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace ArShooter.Managers
{
	

	public class GameManager : MonoBehaviour
	{
		public int score;
		EventManager globalEventsManager;
		// Use this for initialization
		void Start ()
		{
			globalEventsManager = ManagersContainer.Instance.GetManager<EventManager> ();
		}

		public void AddScore (int amount)
		{
			score += amount;
			globalEventsManager.TriggerEvent (Constants.ScoreEvent, new Hashtable () { { Constants.NewValueParam1, score } });
		}

		public void Restart(){
			SceneManager.LoadScene ("Scene1");
		}
	}

}