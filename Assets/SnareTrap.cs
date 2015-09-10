using UnityEngine;
using System.Collections;

public class SnareTrap : MonoBehaviour {
	private Transform tr;
	private Transform colltr;
	private PlayerCtrl pl;

	private float time=0.0f;
	private float checktimer=2.0f;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		pl = GameObject.FindWithTag ("Player").GetComponent<PlayerCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (pl.CS == Name_Maze.CharacterState.Disabled) {
			if(time>checktimer){
				pl.CS=Name_Maze.CharacterState.Idle;
			}
		}
	}
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Player") {
			colltr=coll.GetComponent<Transform>();
			colltr.position=tr.position;
			coll.GetComponent<PlayerCtrl>().CS=Name_Maze.CharacterState.Disabled;
			time=0.0f;
		}
	}
	IEnumerator Delay(float time){//호출주기가 느려서 뺌
		yield return new WaitForSeconds (time);
		pl.CS=Name_Maze.CharacterState.Idle;
		
	}
}
