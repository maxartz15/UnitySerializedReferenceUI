﻿
#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor; 
using UnityEngine;

namespace Textus.SerializeReferenceUI.Editor
{
    [CustomPropertyDrawer(typeof(SerializeReferenceButtonAttribute))]
    public class SerializeReferenceButtonAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect labelPosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(labelPosition, label);

            IEnumerable<Func<Type, bool>> typeRestrictions = SerializedReferenceUIDefaultTypeRestrictions.GetAllBuiltInTypeRestrictions(fieldInfo);
            property.DrawSelectionButtonForManagedReference(position, typeRestrictions);

            EditorGUI.PropertyField(position, property, GUIContent.none, true);
        }
    }
}
#endif