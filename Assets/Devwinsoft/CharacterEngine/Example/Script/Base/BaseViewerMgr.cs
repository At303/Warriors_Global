using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Devwin
{
    public class BaseViewerMgr : MonoBehaviour
    {
        public enum HIGHLIGHT
        {
            UNIT,
            ARMOR,
            MAIN_WEAPON,
            SUB_WEAPON,
            WING,
        }

        public Transform prefab_character_engine;
        public DemoCharacter character;
        public SpriteRenderer[] backgrounds;
        public List<DevPart> packages = new List<DevPart>();
        public string prefix { get { return m_prefix; } set { m_prefix = value; } }
        string m_prefix = "";
        int selected_background = 0;

        string[] l_body_stat = { "normal", "burning", "freezing", "poisoned", "stone" };

        string[] l_unit_types;
        string[] l_unit_index = { };
        string[] l_armor_types;
        string[] l_armor_index = { };
        string[] l_armor_colors = { };
        string[] l_main_weapon_types;
        string[] l_main_weapon_index = { };
        string[] l_sub_weapon_types;
        string[] l_sub_weapon_index = { };
        string[] l_wing_type;
        string[] l_cape_index = { };

        int selected_body_stat = 0;

        int selected_unit_type = 0;
        int selected_unit_index = 0;
        int selected_armor_type = 0;
        int selected_armor_index = 0;
        int selected_armor_color = 0;
        int selected_main_weapon_type = 0;
        int selected_main_weapon_index = 0;
        int selected_sub_weapon_type = 0;
        int selected_sub_weapon_index = 0;
        int selected_cape_type = 0;
        int selected_wing_index = 0;
        List<HIGHLIGHT> m_highlight = new List<HIGHLIGHT>();

        void OnEnable()
        {
            DevEngine.Instance.LoadPackages(packages.ToArray());
            for (int i = 0; i < backgrounds.Length; i++)
            {
                if (i == selected_background)
                    backgrounds[i].enabled = true;
                else
                    backgrounds[i].enabled = false;
            }
        }
        public void AddHighLight(HIGHLIGHT _value)
        {
            if (m_highlight.Contains(_value) == false)
            {
                m_highlight.Add(_value);
            }
        }
        public void OnStart()
        {
            DevPart[] temp_pak;
            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.UNIT);
            _init_array(temp_pak, false, out l_unit_types);
            character.actor.Info.unit_part = l_unit_types.Length > 0 ? l_unit_types[0] : "";

            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.ARMOR);
            _init_array(temp_pak, true, out l_armor_types);

            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.WEAPON_MELEE, PACKAGE_TYPE.WEAPON_BOW, PACKAGE_TYPE.WEAPON_STAFF);
            _init_array(temp_pak, true, out l_main_weapon_types);

            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.WEAPON_ARROW, PACKAGE_TYPE.WEAPON_SHIELD);
            _init_array(temp_pak, true, out l_sub_weapon_types);

            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.WING);
            _init_array(temp_pak, true, out l_wing_type);

            UpdateCharacter(true);
        }

        void OnGUI()
        {
            int temp_value;
            Color temp_color0 = GUI.backgroundColor;
            Color temp_color1 = GUI.contentColor;

#if PREVIEW
            // move scene
            if (GUI.Button(new Rect(5, 5, 150, 40), "Show Samples"))
            {
                Application.LoadLevel(string.Format("{0}Samples", m_prefix));
            }
            if (GUI.Button(new Rect(5, 50, 150, 40), "Change Background"))
            {
                selected_background = (selected_background + 1) % backgrounds.Length;
                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (i == selected_background)
                        backgrounds[i].enabled = true;
                    else
                        backgrounds[i].enabled = false;
                }
            }
#else
            if (GUI.Button(new Rect(5, 5, 150, 40), "Change Background"))
            {
                selected_background = (selected_background + 1) % backgrounds.Length;
                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (i == selected_background)
                        backgrounds[i].enabled = true;
                    else
                        backgrounds[i].enabled = false;
                }
            }
#endif
            // body stat
            selected_body_stat = GUI.SelectionGrid(new Rect(Screen.width / 2 - 200, 0f, 400, 32), selected_body_stat, l_body_stat, l_body_stat.Length);
            switch (selected_body_stat)
            {
                case 1:
                    character.actor.SetChroma(0f);
                    character.actor.SetColor(Color.Lerp(Color.white, Color.red, 0.5f));
                    break;
                case 2:
                    character.actor.SetChroma(0f);
                    character.actor.SetColor(Color.cyan);
                    break;
                case 3:
                    character.actor.SetChroma(0f);
                    character.actor.SetColor(Color.Lerp(Color.white, Color.green, 0.5f));
                    break;
                case 4:
                    character.actor.SetChroma(0f);
                    character.actor.SetColor(Color.white);
                    break;
                default:
                    character.actor.SetChroma(1f);
                    character.actor.SetColor(Color.white);
                    break;
            }

            // animation
            GUI.BeginGroup(new Rect(Screen.width - 160, 0f, 300, Screen.height - 150));
            GUI.Box(new Rect(0, 0, 150, 320), "Animations");
            if (GUI.Button(new Rect(10, 30, 130, 30), "Idle"))
            {
                character.Idle();
            }
            if (GUI.Button(new Rect(10, 65, 130, 30), "Jump Motion"))
            {
                character.Jump();
            }
            if (GUI.Button(new Rect(10, 100, 130, 30), "Walk"))
            {
                character.Walk();
            }

            switch (character.actor.main_weapon_type)
            {
                case PACKAGE_TYPE.WEAPON_BOW:
                    if (GUI.Button(new Rect(10, 135, 130, 30), "Shoot"))
                    {
                        character.Shoot();
                    }
                    break;
                case PACKAGE_TYPE.WEAPON_STAFF:
                    if (GUI.Button(new Rect(10, 135, 130, 30), "Attack1"))
                    {
                        character.Attack1();
                    }
                    if (GUI.Button(new Rect(10, 170, 130, 30), "Attack2 (Jump)"))
                    {
                        character.Attack2();
                    }
                    if (GUI.Button(new Rect(10, 205, 130, 30), "Casting"))
                    {
                        character.Casting();
                    }
                    break;
                default:
                    if (GUI.Button(new Rect(10, 135, 130, 30), "Attack1"))
                    {
                        character.Attack1();
                    }
                    if (GUI.Button(new Rect(10, 170, 130, 30), "Attack2 (Jump)"))
                    {
                        character.Attack2();
                    }
                    break;
            }
            if (GUI.Button(new Rect(10, 240, 130, 30), "Damage"))
            {
                character.Damage();
            }
            if (GUI.Button(new Rect(10, 275, 130, 30), "Die"))
            {
                character.Death();
            }
            GUI.EndGroup();


            // equip
            GUI.BeginGroup(new Rect(0, Screen.height - 390, Screen.width, 390));

            if (m_highlight.Contains(HIGHLIGHT.UNIT))
            {
                GUI.backgroundColor = Color.red;
                GUI.contentColor = Color.yellow;
            }
            GUI.Box(new Rect(0, 0, 150, 24), "Unit-Type");
            if (l_unit_types.Length <= 8)
            {
                temp_value = GUI.SelectionGrid(new Rect(160, 0, Screen.width - 160, 24), selected_unit_type, l_unit_types, 8);
            }
            else
            {
                temp_value = GUI.SelectionGrid(new Rect(160, 0, Screen.width - 160, 54), selected_unit_type, l_unit_types, 8);
            }
            if (temp_value != selected_unit_type)
            {
                selected_unit_type = temp_value;
                character.actor.Info.unit_part = l_unit_types[temp_value];

                UpdateIndex();
                if (character.actor.Info.unit_index >= l_unit_index.Length)
                {
                    selected_unit_index = l_unit_index.Length - 1;
                    character.actor.Info.unit_index = selected_unit_index;
                }
                UpdateCharacter();
            }

            GUI.Box(new Rect(0, 60, 150, 24), "Unit-Index");
            temp_value = GUI.SelectionGrid(new Rect(160, 60, Screen.width - 160, 24), selected_unit_index, l_unit_index, 16);
            if (temp_value != selected_unit_index)
            {
                selected_unit_index = temp_value;
                character.actor.Info.unit_index = temp_value;
                UpdateCharacter();
            }
            if (m_highlight.Contains(HIGHLIGHT.UNIT))
            {
                GUI.backgroundColor = temp_color0;
                GUI.contentColor = temp_color1;
            }



            if (m_highlight.Contains(HIGHLIGHT.ARMOR))
            {
                GUI.backgroundColor = Color.red;
                GUI.contentColor = Color.yellow;
            }
            GUI.Box(new Rect(0, 90, 150, 24), "Armor-Type");
            temp_value = GUI.SelectionGrid(new Rect(160, 90, Screen.width - 160, 24), selected_armor_type, l_armor_types, 12);
            if (temp_value != selected_armor_type)
            {
                selected_armor_type = temp_value;
                character.actor.Info.armor_part = l_armor_types[temp_value];
                UpdateIndex();
                if (character.actor.Info.armor_index >= l_armor_index.Length)
                {
                    selected_armor_index = Mathf.Max(0, l_armor_index.Length - 1);
                    character.actor.Info.armor_index = selected_armor_index;
                }
                if (character.actor.Info.armor_color >= l_armor_colors.Length)
                {
                    selected_armor_color = Mathf.Max(0, l_armor_colors.Length - 1);
                    character.actor.Info.armor_color = selected_armor_color;
                }
                UpdateCharacter();
            }
            GUI.Box(new Rect(0, 120, 150, 24), "Armor-Index");
            temp_value = GUI.SelectionGrid(new Rect(160, 120, Screen.width - 160, 24), selected_armor_index, l_armor_index, 16);
            if (temp_value != selected_armor_index)
            {
                selected_armor_index = temp_value;
                character.actor.Info.armor_index = temp_value;
                UpdateCharacter();
            }
            GUI.Box(new Rect(0, 150, 150, 24), "Armor-Color");
            temp_value = GUI.SelectionGrid(new Rect(160, 150, Screen.width - 160, 24), selected_armor_color, l_armor_colors, 16);
            if (temp_value != selected_armor_color)
            {
                selected_armor_color = temp_value;
                character.actor.Info.armor_color = temp_value;
                UpdateCharacter();
            }
            if (m_highlight.Contains(HIGHLIGHT.ARMOR))
            {
                GUI.backgroundColor = temp_color0;
                GUI.contentColor = temp_color1;
            }


            if (m_highlight.Contains(HIGHLIGHT.MAIN_WEAPON))
            {
                GUI.backgroundColor = Color.red;
                GUI.contentColor = Color.yellow;
            }
            GUI.Box(new Rect(0, 180, 150, 24), "Weapon #1");
            temp_value = GUI.SelectionGrid(new Rect(160, 180, Screen.width - 160, 24), selected_main_weapon_type, l_main_weapon_types, 12);
            if (temp_value != selected_main_weapon_type)
            {
                selected_main_weapon_type = temp_value;
                character.actor.Info.main_weapon_part = l_main_weapon_types[temp_value];
                DevPart temp_info = DevEngine.Instance.GetPackage(character.actor.Info.main_weapon_part);
                if (temp_info != null && temp_info.type == PACKAGE_TYPE.WEAPON_BOW)
                {
                    selected_sub_weapon_type = 1;
                    selected_sub_weapon_index = 0;
                    character.actor.Info.sub_weapon_part = l_sub_weapon_types[selected_sub_weapon_type];
                    character.actor.Info.sub_weapon_index = 0;
                }
                UpdateIndex();
                if (character.actor.Info.main_weapon_index >= l_main_weapon_index.Length)
                {
                    selected_main_weapon_index = Mathf.Max(0, l_main_weapon_index.Length - 1);
                    character.actor.Info.main_weapon_index = selected_main_weapon_index;
                }
                UpdateCharacter(true);
            }
            GUI.Box(new Rect(0, 210, 150, 24), "Weapon-index #1");
            if (l_main_weapon_index.Length <= 16)
            {
                temp_value = GUI.SelectionGrid(new Rect(160, 210, Screen.width - 160, 24), selected_main_weapon_index, l_main_weapon_index, 16);
            }
            else
            {
                temp_value = GUI.SelectionGrid(new Rect(160, 210, Screen.width - 160, 54), selected_main_weapon_index, l_main_weapon_index, 16);
            }
            if (temp_value != selected_main_weapon_index)
            {
                selected_main_weapon_index = temp_value;
                character.actor.Info.main_weapon_index = temp_value;
                UpdateCharacter();
            }
            if (m_highlight.Contains(HIGHLIGHT.MAIN_WEAPON))
            {
                GUI.backgroundColor = temp_color0;
                GUI.contentColor = temp_color1;
            }


            if (m_highlight.Contains(HIGHLIGHT.SUB_WEAPON))
            {
                GUI.backgroundColor = Color.red;
                GUI.contentColor = Color.yellow;
            }
            GUI.Box(new Rect(0, 270, 150, 24), "Weapon #2");
            temp_value = GUI.SelectionGrid(new Rect(160, 270, Screen.width - 160, 24), selected_sub_weapon_type, l_sub_weapon_types, 12);
            if (temp_value != selected_sub_weapon_type)
            {
                selected_sub_weapon_type = temp_value;
                character.actor.Info.sub_weapon_part = l_sub_weapon_types[temp_value];
                UpdateCharacter();
            }
            GUI.Box(new Rect(0, 300, 150, 24), "Weapon-index #2");
            temp_value = GUI.SelectionGrid(new Rect(160, 300, Screen.width - 160, 24), selected_sub_weapon_index, l_sub_weapon_index, 20);
            if (temp_value != selected_sub_weapon_index)
            {
                selected_sub_weapon_index = temp_value;
                character.actor.Info.sub_weapon_index = temp_value;
                UpdateCharacter();
            }
            if (m_highlight.Contains(HIGHLIGHT.SUB_WEAPON))
            {
                GUI.backgroundColor = temp_color0;
                GUI.contentColor = temp_color1;
            }


            if (m_highlight.Contains(HIGHLIGHT.WING))
            {
                GUI.backgroundColor = Color.red;
                GUI.contentColor = Color.yellow;
            }
            GUI.Box(new Rect(0, 330, 150, 24), "Wing-type");
            temp_value = GUI.SelectionGrid(new Rect(160, 330, Screen.width - 160, 24), selected_cape_type, l_wing_type, 12);
            if (temp_value != selected_cape_type)
            {
                selected_cape_type = temp_value;
                character.actor.Info.wing_part = l_wing_type[temp_value];
                UpdateCharacter();
            }
            GUI.Box(new Rect(0, 360, 150, 24), "Wing-index");
            temp_value = GUI.SelectionGrid(new Rect(160, 360, Screen.width - 160, 24), selected_wing_index, l_cape_index, 20);
            if (temp_value != selected_wing_index)
            {
                selected_wing_index = temp_value;
                character.actor.Info.wing_index = temp_value;
                UpdateCharacter();
            }
            if (m_highlight.Contains(HIGHLIGHT.WING))
            {
                GUI.backgroundColor = temp_color0;
                GUI.contentColor = temp_color1;
            }
            GUI.EndGroup();
        }

        void _init_array(DevPart[] _src, bool _add_default, out string[] _dest)
        {
            if (_add_default)
            {
                _dest = new string[_src.Length + 1];
                _dest[0] = "none";
                for (int i = 0; i < _src.Length; i++)
                {
                    _dest[i + 1] = _src[i].package_name;
                }
            }
            else
            {
                _dest = new string[_src.Length];
                for (int i = 0; i < _src.Length; i++)
                {
                    _dest[i] = _src[i].package_name;
                }
            }
        }

        void UpdateCharacter()
        {
            UpdateCharacter(false);
        }
        void UpdateCharacter(bool _reset_animation)
        {
            character.actor.UpdateView();
            //character.actor.InitWithoutTextureBaking();
            UpdateIndex();
            if (_reset_animation)
            {
                character.Idle();
            }
        }
        void UpdateIndex()
        {
            int temp_count = 0;

            // race index
            temp_count = DevEngine.Instance.GetPackageItemCount(character.actor.Info.unit_part);
            l_unit_index = new string[temp_count];
            for (int i = 0; i < temp_count; i++)
            {
                l_unit_index[i] = i.ToString();
            }

            // armor index
            temp_count = DevEngine.Instance.GetPackageItemCount(character.actor.Info.armor_part);
            l_armor_index = new string[temp_count];
            for (int i = 0; i < temp_count; i++)
            {
                l_armor_index[i] = i.ToString();
            }

            // armor color
            temp_count = DevEngine.Instance.GetPackageColorCount(character.actor.Info.armor_part);
            l_armor_colors = new string[temp_count];
            for (int i = 0; i < temp_count; i++)
            {
                l_armor_colors[i] = i.ToString();
            }

            // weapon index #1
            temp_count = DevEngine.Instance.GetPackageItemCount(character.actor.Info.main_weapon_part);
            l_main_weapon_index = new string[temp_count];
            for (int i = 0; i < temp_count; i++)
            {
                l_main_weapon_index[i] = i.ToString();
            }

            // weapon index #2
            temp_count = DevEngine.Instance.GetPackageItemCount(character.actor.Info.sub_weapon_part);
            l_sub_weapon_index = new string[temp_count];
            for (int i = 0; i < temp_count; i++)
            {
                l_sub_weapon_index[i] = i.ToString();
            }

            temp_count = DevEngine.Instance.GetPackageItemCount(character.actor.Info.wing_part);
            l_cape_index = new string[temp_count];
            for (int i = 0; i < temp_count; i++)
            {
                l_cape_index[i] = i.ToString();
            }
        }
    }
}