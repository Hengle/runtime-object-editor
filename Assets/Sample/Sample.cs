﻿using System.Collections;
using System.Collections.Generic;
using SerializableModelEditor;
using UnityEngine;

public class Sample : MonoBehaviour
{
	[System.Serializable]
	public class TestModel
	{
		public string name;

		public int count;

		public float range;

		public Test2Model test2;
	}

	[System.Serializable]
	public class Test2Model
	{
		public List<string> texts;
	}

	public Viewer viewer;

	public TestModel testModel = new TestModel
	{
		name = "test",
			count = 1,
			test2 = new Test2Model { texts = new List<string>() { "abc", "def", "ggg" } }
	};

	private void OnGUI()
	{
		using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, Screen.height)))
		{
			GUILayout.TextField("a");
		}
	}

	// Use this for initialization
	void Start()
	{
		viewer.Show(testModel);
	}

	// Update is called once per frame
	void Update()
	{

	}
}