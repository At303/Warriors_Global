//----------------------------------------------
// Title    : Devwin Character Engine
// Copyright: © 2012-2015 devwinsoft
// Contact  : maoshy@nate.com
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;
using Devwin;

[CustomEditor(typeof(DevPart))]
public partial class EditorPart : Editor
{
    Color m_color_old = GUI.backgroundColor;
    Color m_color_blue = new Color(0.2f, 1f, 1f, 1f);
    Color m_color_green = new Color(0.3f, 0.9f, 0f, 1f);

    DevPart m_scrypt;
    SerializedObject m_target;
    SerializedProperty m_items_unit;
    SerializedProperty m_items_armor;
    SerializedProperty m_items_weapon;
    SerializedProperty m_items_wing;
    SerializedProperty items
    {
        get
        {
            switch (m_scrypt.type)
            {
                case PACKAGE_TYPE.UNIT:
                    return m_items_unit;
                case PACKAGE_TYPE.ARMOR:
                    return m_items_armor;
                case PACKAGE_TYPE.WING:
                    return m_items_wing;
                default:
                    return m_items_weapon;
            }
        }
    }
    PACKAGE_TYPE m_type = PACKAGE_TYPE.NONE;
    int m_item_count = 0;
    int m_color_count = 0;

    void OnEnable()
    {
        m_scrypt = (DevPart)target;
        m_target = new SerializedObject(target);
        m_type = m_scrypt.type;
        m_items_unit = m_target.FindProperty("m_items_unit");
        m_items_armor = m_target.FindProperty("m_items_armor");
        m_items_weapon = m_target.FindProperty("m_items_weapon");
        m_items_wing = m_target.FindProperty("m_items_wing");
        m_item_count = m_scrypt.item_count;
        if (m_type == PACKAGE_TYPE.ARMOR)
        {
            m_color_count = m_scrypt.color_count;
            m_scrypt.UpdateList(m_color_count);
        }
        else
        {
            m_color_count = 1;
        }
    }
    void OnDisable()
    {
    }


    SerializedProperty GetArmorProperty()
    {
        return m_target.FindProperty("m_items_armor");
    }
    SerializedProperty GetArmorProperty(int _index, int _color, string _name)
    {
        return m_target.FindProperty("m_items_armor").GetArrayElementAtIndex(_index * m_color_count + _color).FindPropertyRelative(_name);
    }

    SerializedProperty GetUnitProperty()
    {
        return m_target.FindProperty("m_items_unit");
    }
    SerializedProperty GetUnitProperty(int _index, string _name)
    {
        return m_target.FindProperty("m_items_unit").GetArrayElementAtIndex(_index).FindPropertyRelative(_name);
    }

    SerializedProperty GetWeaponProperty()
    {
        return m_target.FindProperty("m_items_weapon");
    }
    SerializedProperty GetWeaponProperty(int _index, string _name)
    {
        return m_target.FindProperty("m_items_weapon").GetArrayElementAtIndex(_index).FindPropertyRelative(_name);
    }

    SerializedProperty GetWingProperty()
    {
        return m_target.FindProperty("m_items_wing");
    }
    SerializedProperty GetWingProperty(int _index, string _name)
    {
        return m_target.FindProperty("m_items_wing").GetArrayElementAtIndex(_index).FindPropertyRelative(_name);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        m_target.Update();

        GUI.backgroundColor = m_color_blue;
        GUILayout.BeginHorizontal();
        GUILayout.Label("Package Name");
        m_target.FindProperty("m_package_name").stringValue = EditorGUILayout.TextField(m_scrypt.package_name);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        m_target.FindProperty("m_search_order").intValue = EditorGUILayout.IntField("Order", m_scrypt.search_order);
        GUILayout.EndHorizontal();

        GUI.backgroundColor = m_color_old;
        GUILayout.BeginHorizontal();
        PACKAGE_TYPE temp_type = (PACKAGE_TYPE)EditorGUILayout.EnumPopup("Package Type", m_scrypt.type);
        if (temp_type != m_type)
        {
            m_type = temp_type;
            m_target.FindProperty("m_type").enumValueIndex = (int)temp_type;
            m_target.ApplyModifiedProperties();

            if (m_type == PACKAGE_TYPE.ARMOR)
            {
                m_scrypt.UpdateList(m_scrypt.color_count);
                m_item_count = m_scrypt.item_count;
                m_color_count = m_scrypt.color_count;
            }
            else
            {
                m_item_count = m_scrypt.item_count;
                m_color_count = 1;
            }
        }
        GUILayout.EndHorizontal();

        GUI.backgroundColor = m_color_blue;
        if (m_type != PACKAGE_TYPE.NONE)
        {
            int temp_value;
            switch (m_type)
            {
                case PACKAGE_TYPE.UNIT:
                    {
                        GUILayout.BeginHorizontal();
                        m_target.FindProperty("m_eye_pos").vector2Value = EditorGUILayout.Vector2Field("eye_pos", m_scrypt.eye_pos);
                        GUILayout.EndHorizontal();
                    }
                    break;
                default:
                    break;
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label("Item Count");
            temp_value = EditorGUILayout.IntField(m_item_count);
            temp_value = Mathf.Max(0, temp_value);
            if (m_item_count != temp_value)
            {
                ChangeIndexCount(items, m_item_count, temp_value);
                m_item_count = temp_value;
            }
            GUILayout.EndHorizontal();

            switch (m_type)
            {
                case PACKAGE_TYPE.ARMOR:
                    {
                        GUILayout.BeginHorizontal();
                        GUILayout.Label("Color Count");
                        temp_value = EditorGUILayout.IntField(m_color_count);
                        temp_value = Mathf.Max(1, temp_value);
                        if (m_color_count != temp_value)
                        {
                            ChangeColorCount(items, m_color_count, temp_value);
                            m_color_count = temp_value;
                        }
                        GUILayout.EndHorizontal();
                    }
                    break;
                default:
                    break;
            }
            GUI.backgroundColor = m_color_old;

            for (int i = 0; i < m_item_count; i++)
            {
                switch (m_scrypt.type)
                {
                    case PACKAGE_TYPE.UNIT:
                        DevwinEditor.BeginBox();
                        DrawItem_Unit(i);
                        DevwinEditor.EndBox();
                        break;
                    case PACKAGE_TYPE.ARMOR:
                        for (int c = 0; c < m_color_count; c++)
                        {
                            DevwinEditor.BeginBox();
                            DrawItem_Armor(i, c);
                            DevwinEditor.EndBox();
                        }
                        break;
                    case PACKAGE_TYPE.WING:
                        DevwinEditor.BeginBox();
                        DrawItem_Wing(i);
                        DevwinEditor.EndBox();
                        break;
                    default:
                        // weapon
                        DevwinEditor.BeginBox();
                        DrawItem_Weapon(i);
                        DevwinEditor.EndBox();
                        break;
                }
            }
        }

        GUI.backgroundColor = m_color_blue;
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Clean up un-used data", GUILayout.Width(250f)))
        {
            m_scrypt.Cleanup();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUI.backgroundColor = m_color_old;
        m_target.ApplyModifiedProperties();
    }

    public void ChangeIndexCount(SerializedProperty _list, int _from, int _to)
    {
        int cnt = Mathf.Abs(_to - _from);
        if (_to > _from)
        {
            // add
            for (int c = 0; c < m_color_count; c++)
            {
                for (int i = 0; i < cnt; i++)
                {
                    _list.InsertArrayElementAtIndex(_from * m_color_count);
                }
            }
        }
        else
        {
            // remove
            for (int c = 0; c < m_color_count; c++)
            {
                for (int i = 0; i < cnt; i++)
                {
                    _list.DeleteArrayElementAtIndex(_to * m_color_count);
                }
            }
        }

        m_target.ApplyModifiedProperties();
        if (m_type == PACKAGE_TYPE.ARMOR)
        {
            m_scrypt.UpdateList(m_color_count);
        }
    }

    public void ChangeColorCount(SerializedProperty _list, int _from, int _to)
    {
        if (_to < 1 || _to > 100)
        {
            return;
        }
        int cnt = Mathf.Abs(_to - _from);
        if (_to > _from)
        {
            // add
            for (int i = 0; i < m_item_count; i++)
            {
                for (int c = 0; c < cnt; c++)
                {
                    _list.InsertArrayElementAtIndex(m_item_count * m_color_count - i * m_color_count);
                }
            }
        }
        else
        {
            // remove
            for (int i = 0; i < m_item_count; i++)
            {
                for (int c = 0; c < cnt; c++)
                {
                    _list.DeleteArrayElementAtIndex(m_item_count * m_color_count - cnt - i * m_color_count);
                }
            }
        }

        m_target.ApplyModifiedProperties();
        if (m_type == PACKAGE_TYPE.ARMOR)
        {
            m_scrypt.UpdateList(_to);
        }
    }
}
