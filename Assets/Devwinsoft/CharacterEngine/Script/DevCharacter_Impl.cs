//----------------------------------------------
// Title    : Devwin Character Engine
// Copyright: © 2012-2015 devwinsoft
// Contact  : maoshy@nate.com
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace Devwin
{
    public class DevCharacter_Impl : MonoBehaviour
    {
        public CharacterData Info = new CharacterData();
        public DevCharacter character = null;
        public bool is_face;
        public Animator anim;
        public Transform[] wings;
        public SpriteRenderer eye_normal;
        public SpriteRenderer eye_damage;
        public SpriteRenderer weapon_bow_0;
        public SpriteRenderer weapon_bow_1;
        public SpriteRenderer weapon_staff;
        public SpriteRenderer weapon_sword;
        public SpriteRenderer weapon_sub_arrow;
        public SpriteRenderer weapon_sub_shield;
        public SpriteRenderer weapon_sub_sword;

        public PACKAGE_TYPE main_weapon_type { get { return m_main_weapon == null ? PACKAGE_TYPE.NONE : m_main_weapon_pak.type; } }
        public PACKAGE_TYPE sub_weapon_type { get { return m_sub_weapon == null ? PACKAGE_TYPE.NONE : m_sub_weapon_pak.type; } }
        PackageData_Unit m_unit;
        PackageData_Weapon m_main_weapon;
        PackageData_Weapon m_sub_weapon;
        PackageData_Wing m_wing;
        DevPart m_unit_pak;
        DevPart m_main_weapon_pak;
        DevPart m_sub_weapon_pak;
        Material m_material = null;

        void OnEnable()
        {
            InitMaterial();
        }
        void InitMaterial()
        {
            if (m_material == null)
            {
                Shader shader = Shader.Find("devwin/SpriteChroma");
                if (shader == null)
                {
                    shader = Shader.Find("Sprites/Default");
                }
                m_material = new Material(shader);
                foreach (SpriteRenderer r in transform.GetComponentsInChildren<SpriteRenderer>())
                {
                    r.material = m_material;
                }
            }
        }

        void _set_sprite(SpriteRenderer _r, Sprite _s)
        {
            string temp_name = _r.sprite.name;
            if (_s != null)
            {
                _r.enabled = true;
                _r.sprite = _s;
                _r.sprite.name = temp_name;
            }
            else
            {
                _r.enabled = false;
            }
        }
        public void InitWithoutTextureBaking()
        {
            {
                m_unit = DevEngine.Instance.GetPackage_Unit(Info.unit_part, Info.unit_index);
                m_main_weapon = DevEngine.Instance.GetPackage_Weapon(Info.main_weapon_part, Info.main_weapon_index);
                m_sub_weapon = DevEngine.Instance.GetPackage_Weapon(Info.sub_weapon_part, Info.sub_weapon_index);
                m_wing = DevEngine.Instance.GetPackage_Wing(Info.wing_part, Info.wing_index);

                m_unit_pak = DevEngine.Instance.GetPackage(Info.unit_part);
                m_main_weapon_pak = DevEngine.Instance.GetPackage(Info.main_weapon_part);
                m_sub_weapon_pak = DevEngine.Instance.GetPackage(Info.sub_weapon_part);
            }

            DevPart part_unit = DevEngine.Instance.GetPackage(Info.unit_part);
            DevPart part_armor = DevEngine.Instance.GetPackage(Info.armor_part);
            DevPart part_main = DevEngine.Instance.GetPackage(Info.main_weapon_part);
            DevPart part_sub = DevEngine.Instance.GetPackage(Info.sub_weapon_part);
            DevPart part_wing = DevEngine.Instance.GetPackage(Info.wing_part);

            PackageData_Unit pak_unit = part_unit != null ? part_unit.GetUnit(Info.unit_index) : null;
            PackageData_Armor pak_armor = part_armor != null ? part_armor.GetArmor(Info.armor_index, Info.armor_color) : null;
            PackageData_Weapon pak_main = part_main != null ? part_main.GetWeapon(Info.main_weapon_index) : null;
            PackageData_Weapon pak_sub = part_sub != null ? part_sub.GetWeapon(Info.sub_weapon_index) : null;
            PackageData_Wing pak_wing = part_wing != null ? part_wing.GetWing(Info.wing_index) : null;

            foreach (SpriteRenderer r in transform.GetComponentsInChildren<SpriteRenderer>(true))
            {
                if (r.name == "head")
                {
                    if (pak_armor != null)
                    {
                        switch (pak_armor.option)
                        {
                            case SHOW_OPTION.HIDE_FACE:
                                r.sprite = null;
                                break;
                            case SHOW_OPTION.SHOW_HAIR:
                                r.sprite = pak_unit != null ? pak_unit.sprite_face_normal : null;
                                break;
                            case SHOW_OPTION.NONE:
                            default:
                                r.sprite = pak_unit != null ? pak_unit.sprite_face_equiped : null;
                                break;
                        }
                    }
                    else
                    {
                        r.sprite = pak_unit != null ? pak_unit.sprite_face_normal : null;
                    }
                }
                else if (r.name == "eye_normal")
                {
                    if (pak_armor != null && pak_armor.option == SHOW_OPTION.HIDE_FACE)
                    {
                        r.sprite = null;
                    }
                    else if (part_unit != null)
                    {
                        PackageData_Unit temp_pak = pak_unit;
                        if (temp_pak == null || temp_pak.sprite_eye_normal == null) temp_pak = part_unit.GetUnit(0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_eye_normal : null;
                    }
                    else
                    {
                        r.sprite = null;
                    }
                    r.color = pak_unit != null ? pak_unit.eye_color : Color.white;
                }
                else if (r.name == "eye_damage")
                {
                    if (pak_armor != null && pak_armor.option == SHOW_OPTION.HIDE_FACE)
                    {
                        r.sprite = null;
                    }
                    else if (part_unit != null)
                    {
                        PackageData_Unit temp_pak = pak_unit;
                        if (temp_pak == null || temp_pak.sprite_eye_damage == null) temp_pak = part_unit.GetUnit(0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_eye_damage : null;
                    }
                    else
                    {
                        r.sprite = null;
                    }
                    r.color = pak_unit != null ? pak_unit.eye_color : Color.white;
                }
                else if (r.name == "arm-back")
                {
                    // color
                    if (pak_armor != null)
                    {
                        r.color = pak_armor.arm_color;
                    }
                    else
                    {
                        r.color = pak_unit != null ? pak_unit.arm_color : Color.white;
                    }
                    // sprite
                    if (pak_armor != null)
                    {
                        PackageData_Armor temp_pak = pak_armor;
                        if (temp_pak == null || temp_pak.sprite_arm_main == null) temp_pak = part_armor.GetArmor(0, Info.armor_color);
                        if (temp_pak == null || temp_pak.sprite_arm_main == null) temp_pak = part_armor.GetArmor(0, 0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_arm_main : null;
                    }
                    else if (part_unit != null)
                    {
                        PackageData_Unit temp_pak = pak_unit;
                        if (temp_pak == null || temp_pak.sprite_arm_main == null) temp_pak = part_unit.GetUnit(0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_arm_main : null;
                    }
                    else
                    {
                        r.sprite = null;
                    }
                }
                else if (r.name == "arm-front")
                {
                    // color
                    if (pak_armor != null)
                    {
                        r.color = pak_armor.arm_color;
                    }
                    else
                    {
                        r.color = pak_unit != null ? pak_unit.arm_color : Color.white;
                    }
                    // sprite
                    if (pak_armor != null)
                    {
                        PackageData_Armor temp_pak = pak_armor;
                        if (temp_pak == null || temp_pak.sprite_arm_sub == null) temp_pak = part_armor.GetArmor(0, Info.armor_color);
                        if (temp_pak == null || temp_pak.sprite_arm_sub == null) temp_pak = part_armor.GetArmor(0, 0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_arm_sub : null;
                    }
                    else if (part_unit != null)
                    {
                        PackageData_Unit temp_pak = pak_unit;
                        if (temp_pak == null || temp_pak.sprite_arm_sub == null) temp_pak = part_unit.GetUnit(0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_arm_sub : null;
                    }
                    else
                    {
                        r.sprite = null;
                    }
                }
                else if (r.name == "body")
                {
                    if (part_armor != null)
                    {
                        PackageData_Armor temp_pak = pak_armor;
                        if (temp_pak == null || temp_pak.sprite_body == null) temp_pak = part_armor.GetArmor(0, Info.armor_color);
                        if (temp_pak == null || temp_pak.sprite_body == null) temp_pak = part_armor.GetArmor(0, 0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_body : null;
                    }
                    else if (part_unit != null)
                    {
                        PackageData_Unit temp_pak = pak_unit;
                        if (temp_pak == null || temp_pak.sprite_body == null) temp_pak = part_unit.GetUnit(0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_body : null;
                    }
                    else
                    {
                        r.sprite = null;
                    }
                }
                else if (r.name == "glove_back")
                {
                    // color
                    if (pak_armor != null)
                    {
                        r.color = pak_armor.glove_color;
                    }
                    else
                    {
                        r.color = pak_unit != null ? pak_unit.glove_color : Color.white;
                    }
                    // sprite
                    if (pak_armor != null)
                    {
                        PackageData_Armor temp_pak = pak_armor;
                        if (temp_pak == null || temp_pak.sprite_glove_main == null) temp_pak = part_armor.GetArmor(0, Info.armor_color);
                        if (temp_pak == null || temp_pak.sprite_glove_main == null) temp_pak = part_armor.GetArmor(0, 0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_glove_main : null;
                    }
                    else if (part_unit != null)
                    {
                        PackageData_Unit temp_pak = pak_unit;
                        if (temp_pak == null || temp_pak.sprite_glove_main == null) temp_pak = part_unit.GetUnit(0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_glove_main : null;
                    }
                    else
                    {
                        r.sprite = null;
                    }
                }
                else if (r.name == "glove_front")
                {
                    // color
                    if (pak_armor != null)
                    {
                        r.color = pak_armor.glove_color;
                    }
                    else
                    {
                        r.color = pak_unit != null ? pak_unit.glove_color : Color.white;
                    }
                    // sprite
                    if (pak_armor != null)
                    {
                        PackageData_Armor temp_pak = pak_armor;
                        if (temp_pak == null || temp_pak.sprite_glove_sub == null) temp_pak = part_armor.GetArmor(0, Info.armor_color);
                        if (temp_pak == null || temp_pak.sprite_glove_sub == null) temp_pak = part_armor.GetArmor(0, 0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_glove_sub : null;
                    }
                    else if (part_unit != null)
                    {
                        PackageData_Unit temp_pak = pak_unit;
                        if (temp_pak == null || temp_pak.sprite_glove_sub == null) temp_pak = part_unit.GetUnit(0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_glove_sub : null;
                    }
                    else
                    {
                        r.sprite = null;
                    }
                }
                else if (r.name == "leg_0")
                {
                    if (part_armor != null)
                    {
                        PackageData_Armor temp_pak = pak_armor;
                        if (temp_pak == null || temp_pak.sprite_leg0 == null) temp_pak = part_armor.GetArmor(0, Info.armor_color);
                        if (temp_pak == null || temp_pak.sprite_leg0 == null) temp_pak = part_armor.GetArmor(0, 0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_leg0 : null;
                    }
                    else
                    {
                        PackageData_Unit temp_pak = pak_unit;
                        if (temp_pak == null || temp_pak.sprite_leg0 == null) temp_pak = part_unit != null ? part_unit.GetUnit(0) : null;
                        r.sprite = temp_pak != null ? temp_pak.sprite_leg0 : null;
                    }
                }
                else if (r.name == "leg_1")
                {
                    if (part_armor != null)
                    {
                        PackageData_Armor temp_pak = pak_armor;
                        if (temp_pak == null || temp_pak.sprite_leg1 == null) temp_pak = part_armor.GetArmor(0, Info.armor_color);
                        if (temp_pak == null || temp_pak.sprite_leg1 == null) temp_pak = part_armor.GetArmor(0, 0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_leg1 : null;
                    }
                    else
                    {
                        PackageData_Unit temp_pak = pak_unit;
                        if (temp_pak == null || temp_pak.sprite_leg1 == null) temp_pak = part_unit != null ? part_unit.GetUnit(0) : null;
                        r.sprite = temp_pak != null ? temp_pak.sprite_leg1 : null;
                    }
                }
                else if (r.name == "helm")
                {
                    r.sprite = pak_armor != null ? pak_armor.sprite_helm : null;
                }
                else if (r.name == "neck")
                {
                    r.color = pak_armor != null ? pak_armor.arm_color : Color.white;
                    if (part_armor != null)
                    {
                        PackageData_Armor temp_pak = pak_armor;
                        if (temp_pak == null || temp_pak.sprite_neck == null) temp_pak = part_armor.GetArmor(0, Info.armor_color);
                        if (temp_pak == null || temp_pak.sprite_neck == null) temp_pak = part_armor.GetArmor(0, 0);
                        r.sprite = temp_pak != null ? temp_pak.sprite_neck : null;
                    }
                    else
                    {
                        r.sprite = null;
                    }
                }
                else if (r.sprite != null && r.sprite.name == "weapon_back")
                {
                    _set_sprite(r, pak_main != null ? pak_main.sprite_weapon : null);
                }
                else if (r.sprite != null && r.sprite.name == "weapon_front")
                {
                    _set_sprite(r, pak_sub != null ? pak_sub.sprite_weapon : null);
                }
                else if (r.sprite != null && r.sprite.name == "bow_0")
                {
                    if (pak_main == null)
                    {
                        r.enabled = false;
                    }
                    else
                    {
                        Texture2D temp_texture = pak_main.sprite_weapon.texture;
                        Sprite new_sprite = Sprite.Create(temp_texture, new Rect(0.5f * temp_texture.width, 0, 0.5f * temp_texture.width, temp_texture.height), new Vector3(0.5f, 0.5f), r.sprite.pixelsPerUnit);
                        r.enabled = true;
                        r.sprite = new_sprite;
                        r.sharedMaterial.mainTexture = pak_main.sprite_weapon.texture;
                        r.sprite.name = "bow_0";
                    }
                }
                else if (r.sprite != null && r.sprite.name == "bow_1")
                {
                    if (pak_main == null)
                    {
                        r.enabled = false;
                    }
                    else
                    {
                        Texture2D temp_texture = pak_main.sprite_weapon.texture;
                        Sprite new_sprite = Sprite.Create(temp_texture, new Rect(0, 0, 0.5f * temp_texture.width, temp_texture.height), new Vector3(0.5f, 0.5f), r.sprite.pixelsPerUnit);
                        r.enabled = true;
                        r.sprite = new_sprite;
                        r.sharedMaterial.mainTexture = pak_main.sprite_weapon.texture;
                        r.sprite.name = "bow_1";
                    }
                }
                else if (r.name == "cape")
                {
                    r.sprite = pak_wing != null ? pak_wing.sprite_wing : null;
                }
            }
            _fix_sprite_property();
            SetOrder(Info.order);
        }

        public Texture2D GetMaterialTexture()
        {
            foreach (SpriteRenderer r in transform.GetComponentsInChildren<SpriteRenderer>())
            {
                return r.sprite.texture;
            }
            return null;
        }
        public void SetMaterialTexture(Texture2D _texture)
        {
            m_material.mainTexture = _texture;
            foreach (SpriteRenderer r in transform.GetComponentsInChildren<SpriteRenderer>(true))
            {
                Sprite new_sprite = Sprite.Create(_texture, r.sprite.rect, new Vector3(0.5f, 0.5f), r.sprite.pixelsPerUnit);
                r.sprite = new_sprite;
                r.sortingOrder = DevEngine.MakeDepthValue(Info.order, r.sortingOrder % 100);
                r.sharedMaterial.mainTexture = _texture;
            }
        }
        public void SetAlpha(float _value)
        {
            foreach (SpriteRenderer r in transform.GetComponentsInChildren<SpriteRenderer>())
            {
                Color temp_color = r.color;
                temp_color.a = _value;
                r.sharedMaterial.SetColor("_Color", temp_color);
                break;
            }
        }
        public void SetColor(Color _value)
        {
            foreach (SpriteRenderer r in transform.GetComponentsInChildren<SpriteRenderer>())
            {
                r.sharedMaterial.SetColor("_Color", _value);
                break;
            }
        }
        public void SetChroma(float _value)
        {
            foreach (SpriteRenderer r in transform.GetComponentsInChildren<SpriteRenderer>())
            {
                r.sharedMaterial.SetFloat("_Chroma", _value);
                break;
            }
        }

        public void PlayAnimation(string _anim, bool _reset)
        {
            if (_reset)
            {
                anim.Play(_anim, -1, 0f);
            }
            else
            {
                anim.CrossFade(_anim, 0.1f);
            }
        }

        Color _HexToColor(string hex)
        {
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color32(r, g, b, 255);
        }

        public void UpdateView()
        {
            UpdateView(DevEngine.Instance.CreateCharacterTexture(Info));
        }
        public void UpdateView(Texture2D _texture)
        {
            InitMaterial();

            m_unit = DevEngine.Instance.GetPackage_Unit(Info.unit_part, Info.unit_index);
            m_main_weapon = DevEngine.Instance.GetPackage_Weapon(Info.main_weapon_part, Info.main_weapon_index);
            m_sub_weapon = DevEngine.Instance.GetPackage_Weapon(Info.sub_weapon_part, Info.sub_weapon_index);
            m_wing = DevEngine.Instance.GetPackage_Wing(Info.wing_part, Info.wing_index);

            m_unit_pak = DevEngine.Instance.GetPackage(Info.unit_part);
            m_main_weapon_pak = DevEngine.Instance.GetPackage(Info.main_weapon_part);
            m_sub_weapon_pak = DevEngine.Instance.GetPackage(Info.sub_weapon_part);

            _fix_sprite_property();
            this.SetMaterialTexture(_texture);
        }

        void _fix_sprite_property()
        {
            // init eye
            if (m_unit != null)
            {
                // eye position
                eye_normal.transform.localPosition = m_unit_pak != null ? 0.01f * (Vector3)m_unit_pak.eye_pos : Vector3.zero;
                eye_damage.transform.localPosition = eye_normal.transform.localPosition;
            }

            // init weapon
            switch (main_weapon_type)
            {
                case PACKAGE_TYPE.NONE:
                    if (weapon_bow_0 != null) weapon_bow_0.enabled = false;
                    if (weapon_bow_1 != null) weapon_bow_1.enabled = false;
                    if (weapon_staff != null) weapon_staff.enabled = false;
                    if (weapon_sword != null) weapon_sword.enabled = false;
                    break;
                case PACKAGE_TYPE.WEAPON_STAFF:
                    if (weapon_bow_0 != null) weapon_bow_0.enabled = false;
                    if (weapon_bow_1 != null) weapon_bow_1.enabled = false;
                    if (weapon_staff != null) weapon_staff.enabled = true;
                    if (weapon_sword != null) weapon_sword.enabled = false;
                    break;
                case PACKAGE_TYPE.WEAPON_BOW:
                    if (weapon_bow_0 != null) weapon_bow_0.enabled = true;
                    if (weapon_bow_1 != null) weapon_bow_1.enabled = true;
                    if (weapon_staff != null) weapon_staff.enabled = false;
                    if (weapon_sword != null) weapon_sword.enabled = false;
                    break;
                default:
                    if (weapon_bow_0 != null) weapon_bow_0.enabled = false;
                    if (weapon_bow_1 != null) weapon_bow_1.enabled = false;
                    if (weapon_staff != null) weapon_staff.enabled = false;
                    if (weapon_sword != null) weapon_sword.enabled = true;
                    break;
            }
            switch (sub_weapon_type)
            {
                case PACKAGE_TYPE.NONE:
                    if (weapon_sub_arrow != null) weapon_sub_arrow.enabled = false;
                    if (weapon_sub_shield != null) weapon_sub_shield.enabled = false;
                    if (weapon_sub_sword != null) weapon_sub_sword.enabled = false;
                    break;
                case PACKAGE_TYPE.WEAPON_ARROW:
                    if (weapon_sub_arrow != null) weapon_sub_arrow.enabled = true;
                    if (weapon_sub_shield != null) weapon_sub_shield.enabled = false;
                    if (weapon_sub_sword != null) weapon_sub_sword.enabled = false;
                    break;
                case PACKAGE_TYPE.WEAPON_SHIELD:
                    if (weapon_sub_arrow != null) weapon_sub_arrow.enabled = false;
                    if (weapon_sub_shield != null) weapon_sub_shield.enabled = true;
                    if (weapon_sub_sword != null) weapon_sub_sword.enabled = false;
                    break;
                default:
                    if (weapon_sub_arrow != null) weapon_sub_arrow.enabled = false;
                    if (weapon_sub_shield != null) weapon_sub_shield.enabled = false;
                    if (weapon_sub_sword != null) weapon_sub_sword.enabled = true;
                    break;
            }

            // fix cape rotation position
            if (m_wing != null)
            {
                if (wings[0] != null) wings[0].localPosition = new Vector2(0.22f, 0.05f) + 0.01f * m_wing.rot_pos;
                if (wings[1] != null) wings[1].localPosition = new Vector2(0.58f, 0.03f) - 0.01f * (m_wing.rot_pos - m_wing.wing_pos);
            }
        }

        public void SetOrder(int _depth_layer)
        {
            Info.order = _depth_layer;
            foreach (SpriteRenderer r in transform.GetComponentsInChildren<SpriteRenderer>(true))
            {
                r.sortingOrder = DevEngine.MakeDepthValue(Info.order, r.sortingOrder % 100);
            }
        }

        void _OnAttackMove()
        {
            character._OnAttackMove();
        }
        void _OnHitting(int _index)
        {
            character._OnHitting(_index);
        }
    }
}