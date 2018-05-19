﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerAM : MonoBehaviour {
	private string[,] names = new string[,]{{"vibir","false"},{"vivir","true"}};
	private string[,] ecuaciones = new string[,]{{"3+2=5","true"},{"7*8=57","false"},{"6*8=48","true"},{"6*9=53","false"}};
	public GameObject boton;
	GameObject go;
	float time = 0f;
	float delta = 0f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		delta += Time.deltaTime;
		if(delta > 1f)
		{
			time += 1;
			delta = 0;
		}
		if (time == 1) {
			float x = Random.Range (-350,350);
			int i = Random.Range (0,ecuaciones.GetLength(0));
			string nombre = ecuaciones [i, 0];
			bool verdadero = false;
			bool.TryParse(ecuaciones [i, 1],out verdadero);
			//Transform t = this.transform;
			//t.transform.position = new Vector3 (x, 410f, 0f);
			go = (GameObject)Instantiate(boton,this.transform);
			go.GetComponent<RectTransform>().localPosition = new Vector3 (x, 410f, 0f);
			go.GetComponentInChildren<Text> ().text = nombre;
			go.GetComponent<AgilidadMental> ().SetName (nombre);
			go.GetComponent<AgilidadMental> ().SetCorrecta (verdadero);
			go.GetComponent<AgilidadMental> ().SetVelocidad (4);
			time = 0f;
		}
	}
}