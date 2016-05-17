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
    void DrawItem_Weapon(int _index)
    {
        if (!DevwinEditor.DrawHeader(string.Format("Element {0}", _index))) return;
        if (_index >= GetWeaponProperty().arraySize) return;
        PackageData_Weapon temp_data = m_scrypt.items_weapon[_index];

        EditorGUI.indentLevel++;
        GUI.backgroundColor = m_color_green;

        GUILayout.BeginHorizontal();
        GUILayout.Label("sprite_weapon");
        GetWeaponProperty(_index, "sprite_weapon").objectReferenceValue = EditorGUILayout.ObjectField(temp_data.sprite_weapon, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        //GUILayout.BeginHorizontal();
        //temp_data.weapon_pos = EditorGUILayout.Vector2Field("weapon_pos", temp_data.weapon_pos);
        //GUILayout.EndHorizontal();

        GUI.backgroundColor = m_color_old;
        EditorGUI.indentLevel--;
    }
}
