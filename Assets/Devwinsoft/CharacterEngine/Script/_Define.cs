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
    public enum PACKAGE_TYPE
    {
        NONE,
        UNIT,
        ARMOR,

        // main weapons
        WEAPON_BOW,
        WEAPON_STAFF,
        WEAPON_MELEE,

        // sub weapons
        WEAPON_ARROW,
        WEAPON_SHIELD,

        WING,
    }

    public enum SHOW_OPTION
    {
        NONE,
        SHOW_HAIR,
        HIDE_FACE,
    }

    public interface IAnimEventListener
    {
        void OnAnimation_Hitting(int _index);
        void OnAnimation_AttackMove();
    }

    public class CharacterData
    {
        public int order;
        public string unit_part = "";
        public int unit_index;
        public string armor_part = "";
        public int armor_index;
        public int armor_color;
        public string main_weapon_part = "";
        public int main_weapon_index;
        public string sub_weapon_part = "";
        public int sub_weapon_index;
        public string wing_part = "";
        public int wing_index;
        public void Copy(CharacterData _in)
        {
            order = _in.order;
            unit_part = _in.unit_part;
            unit_index = _in.unit_index;
            armor_part = _in.armor_part;
            armor_index = _in.armor_index;
            armor_color = _in.armor_color;
            main_weapon_part = _in.main_weapon_part;
            main_weapon_index = _in.main_weapon_index;
            sub_weapon_part = _in.sub_weapon_part;
            sub_weapon_index = _in.sub_weapon_index;
            wing_part = _in.wing_part;
            wing_index = _in.wing_index;
        }
    }

    public enum CHARACTER_PART
    {
        ARM_MAIN,
        ARM_SUB,
        BODY,
        EYE,
        GLOVE_MAIN,
        GLOVE_SUB,
        FACE,
        HELM,
        NECK,
        LEG_0,
        LEG_1,
        _COUNT,
    }

    [System.Serializable]
    public class PackageData_Armor
    {
        public PackageData_Armor()
        {
            item_index = 0;
            color_index = 0;
            arm_color = Color.white;
            glove_color = Color.white;
        }
        public int item_index;
        public int color_index;
        public Sprite sprite_helm;
        public Sprite sprite_arm_main;
        public Sprite sprite_arm_sub;
        public Sprite sprite_body;
        public Sprite sprite_glove_main;
        public Sprite sprite_glove_sub;
        public Sprite sprite_leg0;
        public Sprite sprite_leg1;
        public Sprite sprite_neck;

        public SHOW_OPTION option;
        public Color arm_color;
        public Color glove_color;
    }

    [System.Serializable]
    public class PackageData_Unit
    {
        public PackageData_Unit()
        {
            arm_color = Color.white;
            eye_color = Color.white;
            glove_color = Color.white;
        }
        public Sprite sprite_arm_main;
        public Sprite sprite_arm_sub;
        public Sprite sprite_body;
        public Sprite sprite_eye_damage;
        public Sprite sprite_eye_normal;
        public Sprite sprite_face_equiped;
        public Sprite sprite_face_normal;
        public Sprite sprite_glove_main;
        public Sprite sprite_glove_sub;
        public Sprite sprite_leg0;
        public Sprite sprite_leg1;
        public Color arm_color;
        public Color eye_color;
        public Color glove_color;
    }

    [System.Serializable]
    public class PackageData_Weapon
    {
        public PackageData_Weapon()
        {
        }
        public Sprite sprite_weapon;
        //public Vector2 weapon_pos = Vector2.zero;
    }

    [System.Serializable]
    public class PackageData_Wing
    {
        public PackageData_Wing()
        {
        }
        public Sprite sprite_wing;
        public Vector2 wing_pos = Vector2.zero;
        public Vector2 rot_pos = Vector2.zero;
    }

}