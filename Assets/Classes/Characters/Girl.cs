using UnityEngine;
using System.Collections;

public class Girl : CharacterBase {

	// Use this for initialization
	void Start () {
		Power hj = GetComponent<HighJump>();
		powers.Add(hj);
		Debug.Log(powers);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
