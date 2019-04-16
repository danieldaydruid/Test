﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaffMovement : MonoBehaviour {
	public GameObject _Player_control;
	public float speed;
	private float waitTime;
	public float startWaitTime;

	public Transform[] moveSpots;
	private int randomSpot;

	void Start() {
		randomSpot = Random.Range(0, moveSpots.Length);
	}

	void Update() {
		if (_Player_control.GetComponent<Player_control>().PlayerIsMoving())
		{
			//Can un-comment this if you want the staff to spin around in a circle,
			//or you can modify the 3 float values (x, y, z) to make it do rotate other ways.
			//transform.Rotate(10f, 0f, 10f, Space.Self);
			transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
			if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
				if(waitTime <= 0) {
					randomSpot = Random.Range(0, moveSpots.Length);
					waitTime = startWaitTime;
				}
				else {
					waitTime -= Time.deltaTime;
				}
			}
		}
	}
}