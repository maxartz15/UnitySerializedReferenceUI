﻿#if UNITY_EDITOR
using System;
using System.Collections.Generic; 
using UnityEditor;
using UnityEngine;

public static class SerializeReferenceInspectorButton
{
    /// Must be drawn before DefaultProperty in order to receive input
    public static void DrawSelectionButtonForManagedReference(this SerializedProperty property, Rect position, IEnumerable<Func<Type, bool>> filters = null)  
    {
        Rect buttonPosition = position;
        buttonPosition.x += EditorGUIUtility.labelWidth + 1 * EditorGUIUtility.standardVerticalSpacing;
        buttonPosition.width = position.width - EditorGUIUtility.labelWidth - 1 * EditorGUIUtility.standardVerticalSpacing;
        buttonPosition.height = EditorGUIUtility.singleLineHeight;

        Color storedColor = GUI.backgroundColor;
        int storedIndent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        (string AssemblyName, string ClassName) = ManagedReferenceUtility.GetSplitNamesFromTypename(property.managedReferenceFullTypename);
       
        bool isNull = string.IsNullOrEmpty(ClassName);
        GUI.backgroundColor = isNull ? Color.red : storedColor;
        
        string className = isNull ? "Null (Assign)" : ClassName;
        string assemblyName = AssemblyName;

        if (GUI.Button(buttonPosition, new GUIContent(className, className + "  ( "+ assemblyName +" )")))
        {
            property.ShowContextMenuForManagedReference(buttonPosition, filters);
        }
        
        GUI.backgroundColor = storedColor;
        EditorGUI.indentLevel = storedIndent;
    }
}
#endif