using UnityEngine;
using System.Collections;

public class PortalTrap : MonoBehaviour {
	public int code;
	float disableTimer = 0;
	
	void Update() {
		if (disableTimer > 0)
			disableTimer -= Time.deltaTime;
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.name == "unitychan" && disableTimer <= 0) {
			foreach(PortalTrap pt in FindObjectsOfType<PortalTrap>()){
				if(pt.code == code && pt != this) {
					pt.disableTimer=2;
					Vector3 position = pt.gameObject.transform.position;
					position.y+=2;
					collider.gameObject.transform.position=position;
				}
			}
		}
	}
}