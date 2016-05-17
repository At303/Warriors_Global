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
    void DrawItem_Wing(int _index)
    {
        if (!DevwinEditor.DrawHeader(string.Format("Element {0}", _index))) return;
        if (_index >= GetWingProperty().arraySize) return;
        PackageData_Wing temp_data = m_scrypt.items_wing[_index];

        EditorGUI.indentLevel++;
        GUI.backgroundColor = m_color_green;

        GUILayout.BeginHorizontal();
        GUILayout.Label("sprite_wing");
        GetWingProperty(_index, "sprite_wing").objectReferenceValue = (Sprite)EditorGUILayout.ObjectField(temp_data.sprite_wing, typeof(Sprite), false, GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GetWingProperty(_index, "wing_pos").vector2Value = EditorGUILayout.Vector2Field("wing_pos", temp_data.wing_pos);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GetWingProperty(_index, "rot_pos").vector2Value = EditorGUILayout.Vector2Field("rot_pos", temp_data.rot_pos);
        GUILayout.EndHorizontal();

        GUI.backgroundColor = m_color_old;
        EditorGUI.indentLevel--;
    }
}
