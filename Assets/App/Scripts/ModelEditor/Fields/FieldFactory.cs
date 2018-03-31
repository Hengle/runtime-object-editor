﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public static class FieldFactory
	{
		public static FieldViewer Create(object model, FieldInfo fieldInfo)
		{
			return new FieldViewer(model, fieldInfo);
		}
	}
}