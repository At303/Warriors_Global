//----------------------------------------------
// Title    : Devwin Character Engine
// Copyright: © 2012-2015 devwinsoft
// Contact  : maoshy@nate.com
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Devwin;

public partial class EditorPart
{
    void DrawItem_Unit(int _index)
    {
        if (!DevwinEditor.DrawHeader(string.Format("Element {0}", _index))) return;
        if (_index >= GetUnitProperty().arraySize) return;
        PackageData_Unit temp_data = m_scrypt.items_unit[_index];

        EditorGUI.indentLevel++;

        if (_index == 0)
        {
            GUI.backgroundColor = m_color_green;
        }
        GUILayout.BeginHorizontal();
        GUILayout.Label("arm_main");
        GetUnitProperty(_index, "sprite_arm_main").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_arm_main, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("arm_sub");
        GetUnitProperty(_index, "sprite_arm_sub").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_arm_sub, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("body");
        GetUnitProperty(_index, "sprite_body").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_body, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("eye_damage");
        GetUnitProperty(_index, "sprite_eye_damage").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_eye_damage, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        GUILayout.Label("eye_normal");
        GetUnitProperty(_index, "sprite_eye_normal").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_eye_normal, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUI.backgroundColor = m_color_green;
        GUILayout.BeginHorizontal();
        GUILayout.Label("face_equiped");
        GetUnitProperty(_index, "sprite_face_equiped").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_face_equiped, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("face_normal");
        GetUnitProperty(_index, "sprite_face_normal").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_face_normal, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        if (_index != 0)
        {
            GUI.backgroundColor = m_color_old;
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label("glove_main");
        GetUnitProperty(_index, "sprite_glove_main").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_glove_main, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("glove_sub");
        GetUnitProperty(_index, "sprite_glove_sub").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_glove_sub, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("leg0");
        GetUnitProperty(_index, "sprite_leg0").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_leg0, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("leg1");
        GetUnitProperty(_index, "sprite_leg1").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_leg1, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUI.backgroundColor = m_color_old;

        GUILayout.Space(10f);

        GUILayout.BeginHorizontal();
        GUILayout.Label("arm_color");
        GetUnitProperty(_index, "arm_color").colorValue = EditorGUILayout.ColorField(temp_data.arm_color, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("eye_color");
        GetUnitProperty(_index, "eye_color").colorValue = EditorGUILayout.ColorField(temp_data.eye_color, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("glove_color");
        GetUnitProperty(_index, "glove_color").colorValue = EditorGUILayout.ColorField(temp_data.glove_color, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        EditorGUI.indentLevel--;

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Get default value", GUILayout.Width(250f)))
        {
            if (_index == 0)
            {
                GetUnitProperty(_index, "arm_color").colorValue = Color.white;
                GetUnitProperty(_index, "eye_color").colorValue = Color.white;
                GetUnitProperty(_index, "glove_color").colorValue = Color.white;
            }
            else
            {
                PackageData_Unit default_data = m_scrypt.items_unit[0];
                if (default_data != null)
                {
                    GetUnitProperty(_index, "arm_color").colorValue = default_data.arm_color;
                    GetUnitProperty(_index, "eye_color").colorValue = default_data.eye_color;
                    GetUnitProperty(_index, "glove_color").colorValue = default_data.glove_color;
                }
            }
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
}

