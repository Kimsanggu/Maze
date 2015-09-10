using UnityEngine;
using System.Collections;

public class AirBombTrap : MonoBehaviour {
	float BombTime = 5.0f;
	public GameObject BombPrefab;
	private Transform PlayerTr;
	private Vector3 PlayerV3;
	private Vector3 PlayerV4;
	private Vector3 PlayerV=new Vector3(0.0f,0.0f,0.0f);
	private bool TrapOn = true;
	private float Trapdist=20.0f;
	private int TrapCount = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//StartCoroutine (Delay (2.0f));
	}

	

	
	void OnTriggerEnter(Collider col) {
		PlayerV = new Vector3 (0.0f, 0.0f, 0.0f);
		if (col.gameObject.tag=="Player") {
			PlayerTr = col.GetComponent<Transform>();
			PlayerV3 = col.gameObject.transform.position;
		}
	}
	void OnTriggerStay(Collider col){
		if (PlayerV == new Vector3 (0.0f, 0.0f, 0.0f)) {
			if (col.gameObject.tag == "Player") {
				PlayerV4 = col.transform.position;
				PlayerV = PlayerV4 - PlayerV3;
				Debug.Log (PlayerV);
			}

		} else {
			if(TrapCount<2){
				StartCoroutine(BombDrop(0.5f));
				TrapCount++;
			}

		}
	}
	void OnTriggerExit(Collider col){
		TrapCount = 1;
	}
	
	IEnumerator BombDrop(float waitTime){
		for (int i=1; i<4; i++) {
			yield return new WaitForSeconds (waitTime);
			Instantiate (BombPrefab, PlayerV3 + new Vector3 (0, 8, 0) + (PlayerV * Trapdist*i), Quaternion.identity);
		}
	}

}


