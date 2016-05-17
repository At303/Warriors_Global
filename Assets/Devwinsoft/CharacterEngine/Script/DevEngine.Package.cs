//----------------------------------------------
// Title    : Devwin Character Engine
// Copyright: © 2012-2015 devwinsoft
// Contact  : maoshy@nate.com
//----------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Devwin
{
    public partial class DevEngine
    {
        public DevPart GetPackage(string _package_name)
        {
            DevPart value = null;
            m_package_list.TryGetValue(_package_name, out value);
            return value;
        }

        public PackageData_Armor GetPackage_Armor(string _package_name, int _index, int _color)
        {
            DevPart value = null;
            if (m_package_list.TryGetValue(_package_name, out value))
            {
                return value.GetArmor(_index, _color);
            }
            return null;
        }
        public PackageData_Unit GetPackage_Unit(string _package_name, int _index)
        {
            DevPart value = null;
            if (m_package_list.TryGetValue(_package_name, out value))
            {
                if (value.items_unit.Count > _index)
                    return value.items_unit[_index];
            }
            return null;
        }
        public PackageData_Weapon GetPackage_Weapon(string _package_name, int _index)
        {
            DevPart value = null;
            if (m_package_list.TryGetValue(_package_name, out value))
            {
                if (value.items_weapon.Count > _index)
                    return value.items_weapon[_index];
            }
            return null;
        }
        public PackageData_Wing GetPackage_Wing(string _package_name, int _index)
        {
            DevPart value = null;
            if (m_package_list.TryGetValue(_package_name, out value))
            {
                if (value.items_wing.Count > _index)
                    return value.items_wing[_index];
            }
            return null;
        }


        public int GetPackageItemCount(string _addon_name)
        {
            DevPart temp = GetPackage(_addon_name);
            return temp != null ? temp.item_count : 0;
        }
        public int GetPackageColorCount(string _addon_name)
        {
            DevPart temp = GetPackage(_addon_name);
            return temp != null ? temp.color_count : 0;
        }
        public int GetPackageList(out DevPart[] _list, params PACKAGE_TYPE[] _pak_types)
        {
            List<DevPart> temp_list = new List<DevPart>();
            foreach (DevPart temp in m_package_list.Values)
            {
                foreach (PACKAGE_TYPE temp_type in _pak_types)
                {
                    if (temp.type == temp_type)
                    {
                        int temp_insert;
                        for (temp_insert = 0; temp_insert < temp_list.Count; temp_insert++)
                        {
                            if (temp.search_order < temp_list[temp_insert].search_order)
                                break;
                        }
                        temp_list.Insert(temp_insert, temp);
                    }
                }
            }
            _list = temp_list.ToArray();
            return _list.Length;
        }
    }
}