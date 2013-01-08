using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SEX{
	MALE,
	FEMALE,
	ASEXUAL
};

public class CharacterBase : MonoBehaviour {

	public string firstName;
	public string lastName;
	public string job;
	public string description;
	public bool canUseDrive;
	public SEX sex;
	public List<Power> powers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}