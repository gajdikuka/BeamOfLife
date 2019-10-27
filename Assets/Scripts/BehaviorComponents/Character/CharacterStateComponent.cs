using UnityEngine;
using System.Collections;
using ArShooter.BehaviorComponents;

namespace ArShooter.BehaviorComponents
{
	

	public enum CharacterState
	{
		Idle,
		CastAttack,
		Attack
	}

	public class CharacterStateComponent : BaseStateComponent<CharacterState>
	{
		void Awake(){
			this.currentState = CharacterState.Idle;
		}
	}

}