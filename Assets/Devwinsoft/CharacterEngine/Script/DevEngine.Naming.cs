//----------------------------------------------
// Title    : Devwin Character Engine
// Copyright: © 2012-2015 devwinsoft
// Contact  : maoshy@nate.com
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace Devwin
{
    public partial class DevEngine
    {
        string ToString(CHARACTER_PART _value)
        {
            switch (_value)
            {
                case CHARACTER_PART.ARM_MAIN:
                    return "arm-main";
                case CHARACTER_PART.ARM_SUB:
                    return "arm-sub";
                case CHARACTER_PART.BODY:
                    return "body";
                case CHARACTER_PART.GLOVE_MAIN:
                    return "glove";
                case CHARACTER_PART.GLOVE_SUB:
                    return "glove";
                case CHARACTER_PART.HELM:
                    return "helm";
                case CHARACTER_PART.NECK:
                    return "neck";
                case CHARACTER_PART.LEG_0:
                    return "leg0";
                case CHARACTER_PART.LEG_1:
                    return "leg1";
                default:
                    return "";
            }
        }


        public Sprite GetSprite_Armor(string _pak_name, CHARACTER_PART _armor_part, int _index, int _color)
        {
            Sprite value = _GetSprite_Armor(_pak_name, _armor_part, _index, _color);
            if (value == null && _index > 0)
            {
                value = _GetSprite_Armor(_pak_name, _armor_part, 0, _color);
            }
            if (value == null && _color > 0)
            {
                value = _GetSprite_Armor(_pak_name, _armor_part, 0, 0);
            }
            return value;
        }
        Sprite _GetSprite_Armor(string _pak_name, CHARACTER_PART _armor_part, int _index, int _color)
        {
            DevPart pak = null;
            if (m_package_list.TryGetValue(_pak_name, out pak)
                && pak.type == PACKAGE_TYPE.ARMOR)
            {
                int temp_index = _index * pak.color_count + _color;
                if (temp_index >= pak.items_armor.Count)
                    return null;
                PackageData_Armor data = pak.items_armor[temp_index];
                switch (_armor_part)
                {
                    case CHARACTER_PART.ARM_MAIN:
                        return data.sprite_arm_main;
                    case CHARACTER_PART.ARM_SUB:
                        return data.sprite_arm_sub;
                    case CHARACTER_PART.BODY:
                        return data.sprite_body;
                    case CHARACTER_PART.GLOVE_MAIN:
                        return data.sprite_glove_main;
                    case CHARACTER_PART.GLOVE_SUB:
                        return data.sprite_glove_sub;
                    case CHARACTER_PART.HELM:
                        return data.sprite_helm;
                    case CHARACTER_PART.LEG_0:
                        return data.sprite_leg0;
                    case CHARACTER_PART.LEG_1:
                        return data.sprite_leg1;
                    case CHARACTER_PART.NECK:
                        return data.sprite_neck;
                    default:
                        break;
                }
            }
            return null;
        }

        public Sprite GetSprite_Unit(string _pak_name, CHARACTER_PART _armor_part, int _index)
        {
            return GetSprite_Unit(_pak_name, _armor_part, _index, false, false);
        }
        public Sprite GetSprite_Unit(string _pak_name, CHARACTER_PART _armor_part, int _index, bool _equiped, bool _damaged)
        {
            Sprite value = _GetSprite_Unit(_pak_name, _armor_part, _index, _equiped, _damaged);
            if (value == null && _index > 0)
            {
                value = _GetSprite_Unit(_pak_name, _armor_part, 0, _equiped, _damaged);
            }
            return value;
        }
        Sprite _GetSprite_Unit(string _pak_name, CHARACTER_PART _armor_part, int _index, bool _equiped, bool _damaged)
        {
            DevPart pak = null;
            if (m_package_list.TryGetValue(_pak_name, out pak)
                && pak.type == PACKAGE_TYPE.UNIT
                && _index < pak.items_unit.Count)
            {
                PackageData_Unit data = pak.items_unit[_index];
                switch (_armor_part)
                {
                    case CHARACTER_PART.ARM_MAIN:
                        return data.sprite_arm_main;
                    case CHARACTER_PART.ARM_SUB:
                        return data.sprite_arm_sub;
                    case CHARACTER_PART.BODY:
                        return data.sprite_body;
                    case CHARACTER_PART.EYE:
                        if (_damaged)
                            return data.sprite_eye_damage;
                        else
                            return data.sprite_eye_normal;
                    case CHARACTER_PART.FACE:
                        if (_equiped)
                            return data.sprite_face_equiped;
                        else
                            return data.sprite_face_normal;
                    case CHARACTER_PART.GLOVE_MAIN:
                        return data.sprite_glove_main;
                    case CHARACTER_PART.GLOVE_SUB:
                        return data.sprite_glove_sub;
                    case CHARACTER_PART.LEG_0:
                        return data.sprite_leg0;
                    case CHARACTER_PART.LEG_1:
                        return data.sprite_leg1;
                    default:
                        break;
                }
            }
            return null;
        }
        public Sprite GetSprite_Weapon(string _pak_name, int _index)
        {
            DevPart pak = null;
            if (m_package_list.TryGetValue(_pak_name, out pak)
                && _index < pak.items_weapon.Count)
            {
                switch (pak.type)
                {
                    case PACKAGE_TYPE.WEAPON_ARROW:
                    case PACKAGE_TYPE.WEAPON_BOW:
                    case PACKAGE_TYPE.WEAPON_MELEE:
                    case PACKAGE_TYPE.WEAPON_SHIELD:
                    case PACKAGE_TYPE.WEAPON_STAFF:
                        return pak.items_weapon[_index].sprite_weapon;
                    default:
                        break;
                }
            }
            return null;
        }
        public Sprite GetSprite_Wing(string _pak_name, int _index)
        {
            DevPart pak = null;
            if (m_package_list.TryGetValue(_pak_name, out pak)
                && _index < pak.items_wing.Count)
            {
                switch (pak.type)
                {
                    case PACKAGE_TYPE.WING:
                        return pak.items_wing[_index].sprite_wing;
                    default:
                        break;
                }
            }
            return null;
        }
    }
}