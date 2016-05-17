//----------------------------------------------
// Title    : Devwin Character Engine
// Copyright: © 2012-2015 devwinsoft
// Contact  : maoshy@nate.com
//----------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Devwin;

public class DevPart : MonoBehaviour
{
    public string package_name { get { return m_package_name; } }
    public PACKAGE_TYPE type { get { return m_type; } }
    public int search_order { get { return m_search_order; } }
    public Vector2 eye_pos { get { return m_eye_pos; } }
    public int color_count { get { return m_color_count; } }
    public List<PackageData_Armor> items_armor { get { return m_items_armor; } }
    public List<PackageData_Unit> items_unit { get { return m_items_unit; } }
    public List<PackageData_Weapon> items_weapon { get { return m_items_weapon; } }
    public List<PackageData_Wing> items_wing { get { return m_items_wing; } }

    [HideInInspector][SerializeField] string m_package_name = "";
    [HideInInspector][SerializeField] PACKAGE_TYPE m_type = PACKAGE_TYPE.NONE;
    [HideInInspector][SerializeField] int m_search_order = 0;
    [HideInInspector][SerializeField] Vector2 m_eye_pos = Vector2.zero; // unit only
    [HideInInspector][SerializeField] int m_color_count = 1; // armor only

    [HideInInspector][SerializeField] List<PackageData_Armor> m_items_armor = new List<PackageData_Armor>();
    [HideInInspector][SerializeField] List<PackageData_Unit> m_items_unit = new List<PackageData_Unit>();
    [HideInInspector][SerializeField] List<PackageData_Weapon> m_items_weapon = new List<PackageData_Weapon>();
    [HideInInspector][SerializeField] List<PackageData_Wing> m_items_wing = new List<PackageData_Wing>();

    Dictionary<int, PackageData_Armor> m_items_armor_dict = new Dictionary<int, PackageData_Armor>();

    public int item_count
    {
        get
        {
            switch (m_type)
            {
                case PACKAGE_TYPE.NONE:
                    return 0;
                case PACKAGE_TYPE.UNIT:
                    return m_items_unit.Count;
                case PACKAGE_TYPE.ARMOR:
                    return m_items_armor.Count / m_color_count;
                case PACKAGE_TYPE.WING:
                    return m_items_wing.Count;
                default:
                    return m_items_weapon.Count;
            }
        }
    }
    public PackageData_Armor GetArmor(int _index, int _color)
    {
        int temp_index = _index * m_color_count + _color;
        if (temp_index < m_items_armor.Count)
            return m_items_armor[temp_index];
        return null;
    }
    public PackageData_Unit GetUnit(int _index)
    {
        if (_index < m_items_unit.Count)
            return m_items_unit[_index];
        return null;
    }
    public PackageData_Weapon GetWeapon(int _index)
    {
        if (_index < m_items_weapon.Count)
            return m_items_weapon[_index];
        return null;
    }
    public PackageData_Wing GetWing(int _index)
    {
        if (_index < m_items_wing.Count)
            return m_items_wing[_index];
        return null;
    }
    public void UpdateList(int _color_cnt)
    {
        m_color_count = _color_cnt;
        m_items_armor_dict.Clear();
        for (int i = 0; i < m_items_armor.Count; i++)
        {
            PackageData_Armor obj = m_items_armor[i];
            obj.item_index = i / _color_cnt;
            obj.color_index = i % _color_cnt;
            int key = obj.item_index * 1000 + obj.color_index;
            m_items_armor_dict.Add(key, obj);
        }
    }
    public void Cleanup()
    {
        switch (m_type)
        {
            case PACKAGE_TYPE.NONE:
                m_color_count = 1;
                m_items_armor.Clear();
                m_items_armor_dict.Clear();
                m_items_unit.Clear();
                m_items_weapon.Clear();
                m_items_wing.Clear();
                break;
            case PACKAGE_TYPE.ARMOR:
                m_items_unit.Clear();
                m_items_weapon.Clear();
                m_items_wing.Clear();
                break;
            case PACKAGE_TYPE.UNIT:
                m_items_armor.Clear();
                m_items_armor_dict.Clear();
                m_items_weapon.Clear();
                m_items_wing.Clear();
                break;
            case PACKAGE_TYPE.WING:
                m_items_armor.Clear();
                m_items_armor_dict.Clear();
                m_items_unit.Clear();
                m_items_weapon.Clear();
                break;
            default:
                m_items_armor.Clear();
                m_items_armor_dict.Clear();
                m_items_unit.Clear();
                m_items_wing.Clear();
                break;
        }
    }
}

