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

		public float range1;
		public float range2;
		public float range3;
		public float range4;
		public float range5;

		public Test2Model test2;
	}

	[System.Serializable]
	public class Test2Model
	{
		public string name;

		public int count;

		public float range;

		public float range1;
		public float range2;
		public float range3;
		public float range4;
		public float range5;

		public List<string> texts;
	}

	public ModelEditor modelEditor;

	public TestModel testModel = new TestModel
	{
		name = "test",
			count = 1,
			test2 = new Test2Model { texts = new List<string>() { "abc", "def", "ggg" } }
	};

	// private void OnGUI()
	// {
	// using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, Screen.height)))
	// 	{
	// 		using(new GUILayout.HorizontalScope())
	// 		{
	// 			GUILayout.Label("name");
	// 			GUILayout.TextField("aaaa");
	// 		}
	// 	}
	// }

	// Use this for initialization
	void Start()
	{
		modelEditor.Show(testModel, () =>
		{
			Debug.Log("closed");
		});
	}

	void OnGUI()
	{
		if (!modelEditor.Visible)
		{
			float headerHeight = Screen.height / 10f;

			using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, headerHeight)))
			{
				using(new GUILayout.HorizontalScope(GUI.skin.box))
				{
					GUILayout.Label("a", GUILayout.ExpandWidth(true));

					if (GUILayout.Button("X", GUILayout.ExpandWidth(false)))
					{
						modelEditor.Show(testModel);
					}
				}
			}
		}
	}
}