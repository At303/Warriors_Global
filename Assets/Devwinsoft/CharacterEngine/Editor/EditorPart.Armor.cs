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
    void DrawItem_Armor(int _index, int _color)
    {
        if (!DevwinEditor.DrawHeader(string.Format("Element {0} \t Color {1}", _index, _color), (_index * 1000 + _color + 1).ToString())) return;
        if (_index >= GetArmorProperty().arraySize) return;
        PackageData_Armor temp_data = m_scrypt.GetArmor(_index, _color);
        if (temp_data == null) return;

        EditorGUI.indentLevel++;

        if (_index == 0 && _color == 0)
        {
            GUI.backgroundColor = m_color_green;
        }
        GUILayout.BeginHorizontal();
        GUILayout.Label("arm_main");
        GetArmorProperty(_index, _color, "sprite_arm_main").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_arm_main, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("arm_sub");
        GetArmorProperty(_index, _color, "sprite_arm_sub").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_arm_sub, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        if ((_index == 0 && _color != 0))
        {
            GUI.backgroundColor = m_color_green;
        }
        GUILayout.BeginHorizontal();
        GUILayout.Label("body");
        GetArmorProperty(_index, _color, "sprite_body").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_body, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        if ((_index == 0 && _color != 0))
        {
            GUI.backgroundColor = m_color_old;
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label("glove_main");
        GetArmorProperty(_index, _color, "sprite_glove_main").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_glove_main, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("glove_sub");
        GetArmorProperty(_index, _color, "sprite_glove_sub").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_glove_sub, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        if (_index != 0 || (_index == 0 && _color != 0))
        {
            GUI.backgroundColor = m_color_green;
        }
        GUILayout.BeginHorizontal();
        GUILayout.Label("helm");
        GetArmorProperty(_index, _color, "sprite_helm").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_helm, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        if (_index != 0 || (_index == 0 && _color != 0))
        {
            GUI.backgroundColor = m_color_old;
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label("leg0");
        GetArmorProperty(_index, _color, "sprite_leg0").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_leg0, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("leg1");
        GetArmorProperty(_index, _color, "sprite_leg1").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_leg1, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("neck");
        GetArmorProperty(_index, _color, "sprite_neck").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_neck, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUI.backgroundColor = m_color_old;
        GUILayout.Space(10f);

        GUILayout.BeginHorizontal();
        GUILayout.Label("option");
        GetArmorProperty(_index, _color, "option").enumValueIndex = (int)(SHOW_OPTION)EditorGUILayout.EnumPopup(temp_data.option, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("arm_color");
        GetArmorProperty(_index, _color, "arm_color").colorValue = EditorGUILayout.ColorField(temp_data.arm_color, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("glove_color");
        GetArmorProperty(_index, _color, "glove_color").colorValue = EditorGUILayout.ColorField(temp_data.glove_color, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        EditorGUI.indentLevel--;

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Get default value", GUILayout.Width(250f)))
        {
            if (_index == 0)
            {
                GetArmorProperty(_index, _color, "arm_color").colorValue = Color.white;
                GetArmorProperty(_index, _color, "glove_color").colorValue = Color.white;
            }
            else
            {
                PackageData_Armor default_data = m_scrypt.GetArmor(0, _color);
                if (default_data != null)
                {
                    GetArmorProperty(_index, _color, "arm_color").colorValue = default_data.arm_color;
                    GetArmorProperty(_index, _color, "glove_color").colorValue = default_data.glove_color;
                }
            }
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
}
