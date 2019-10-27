using UnityEngine;
using System.Collections;

namespace ArShooter.BehaviorComponents.Interfaces
{
	

	public interface IState<T>
	{

		void ChangeState (T newState);

	}
}

