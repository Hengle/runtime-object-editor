﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	/// <summary>
	/// オブジェクトの編集
	/// </summary>
	public class ObjectViewer : Viewer
	{
		private object _model;

		private ObjectViewer _parent;

		private int Indent
		{
			get
			{
				if (_parent == null)
				{
					return 0;
				}
				return _parent.Indent + 1;
			}
		}

		private bool _foldout = true;

		private List<Viewer> _viewers;

		public ObjectViewer(object model, ObjectViewer parent = null)
		{
			_model = model;
			SetParent(parent);
			_viewers = new List<Viewer>();

			foreach (FieldInfo fieldInfo in _model.GetType().GetFields())
			{
				Viewer viewer = Factory.Create(this, _model, fieldInfo);
				if (viewer == null)
				{
					Debug.LogWarning("viewer is null.");
					continue;
				}

				_viewers.Add(viewer);
			}
		}

		public void SetParent(ObjectViewer parent = null)
		{
			_parent = parent;
		}

		public override void OnGUI()
		{
			// TODO: field名が欲しい
			if (_parent != null)
			{
				using(new FieldScope(false))
				{
					if (GUILayout.Button(_foldout ? "▼" : "▶︎", GUILayout.ExpandWidth(false)))
					{
						_foldout = !_foldout;
					}
					GUILayout.Label(_model.GetType().Name);
				}
			}

			if (_foldout)
			{
				using(new IndentScope(Indent))
				{
					foreach (Viewer viewer in _viewers)
					{
						viewer.OnGUI();
					}
				}
			}
		}
	}
}