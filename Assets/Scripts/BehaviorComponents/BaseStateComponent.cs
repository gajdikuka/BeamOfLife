using UnityEngine;
using System.Collections;
using ArShooter.BehaviorComponents.Interfaces;

namespace ArShooter.BehaviorComponents
{
	

	public abstract class BaseStateComponent<T> : MonoBehaviour, IState<T>
	{
		public T currentState;
		public T previousState;

		public void ChangeState (T newState)
		{
			previousState = currentState;
			currentState = newState;
		}
	}

}