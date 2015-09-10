using UnityEngine;
using System.Collections;
namespace Name_Maze{
	public abstract class Character : MonoBehaviour{
		public static CharacterState Character_State;
		public Vector3 CurrentPosition;
		public SpriteRenderer Character_Image;
		public int Number;
		public static Grade Character_Grade;
		public float Hp;
		public float Ad;
		public float Defensive;
		public float Ad_Speed;
		public float Rotate_Speed;
		public int AttackCombo;


		abstract public bool Death();
		abstract public void ComboSuccess();
		abstract public void OnColliderEnter();
		abstract public void EnergyBar_Fill();
		abstract public void EnergyBar_Decrease();
		//abstract void SetAttack(Attack attack);
		abstract public bool Target();
		abstract public void Attack();
	
	}
}