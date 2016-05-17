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
    public partial class DevEngine : MonoBehaviour
    {
        public const int texture_size = 512;
        const int layer_devwin_render_texture = 31;
        const float half_view_size = (float)texture_size / 200f;

        private static DevEngine ms_instance;
        public static DevEngine Instance
        {
            get
            {
                if (ms_instance == null)
                {
                    GameObject container = new GameObject();
                    container.name = "CharacterEngine";
                    ms_instance = container.AddComponent(typeof(DevEngine)) as DevEngine;
                }
                if (ms_instance.m_init == false)
                {
                    ms_instance.Init();
                }
                return ms_instance;
            }
        }
        public static bool is_created
        {
            get
            {
                return ms_instance != null;
            }
        }
        public static int MakeDepthValue(int _character_order, int _parts_order)
        {
            return 100 * _character_order + _parts_order;
        }

        public List<DevPart> preload_packages = new List<DevPart>();
        Dictionary<string, DevPart> m_package_list = new Dictionary<string, DevPart>();

        // texture build
        RenderTexture m_render_texture;
        Camera m_render_camera;
        Transform m_parts;
        SpriteRenderer m_part_arm_back;
        SpriteRenderer m_part_arm_front;
        SpriteRenderer m_part_body;
        SpriteRenderer m_part_cape;
        SpriteRenderer m_part_eye_0;
        SpriteRenderer m_part_eye_1;
        SpriteRenderer m_part_glove_main;
        SpriteRenderer m_part_glove_sub;
        SpriteRenderer m_part_head_normal;
        SpriteRenderer m_part_helm;
        SpriteRenderer m_part_neck;
        SpriteRenderer m_part_leg_0;
        SpriteRenderer m_part_leg_1;
        SpriteRenderer m_part_weapon_main;
        SpriteRenderer m_part_weapon_sub;
        bool m_init = false;

        void OnEnable()
        {
            if (ms_instance == null)
            {
                ms_instance = this;
            }
            DontDestroyOnLoad(gameObject);
            Init();
        }
        public void Init()
        {
            if (m_init)
                return;
            m_init = true;

            GameObject temp = new GameObject();
            temp.name = "render_camera";
            temp.transform.localPosition = new Vector3(0, 0, -1);
            m_render_camera = temp.AddComponent(typeof(Camera)) as Camera;
            m_render_camera.transform.parent = transform;
            m_render_camera.orthographic = true;
            m_render_camera.orthographicSize = (float)texture_size / 200f;
            m_render_camera.cullingMask = 1 << layer_devwin_render_texture;
            m_render_camera.clearFlags = CameraClearFlags.SolidColor;
            m_render_camera.backgroundColor = new Color32(0, 0, 0, 0);
            m_render_camera.enabled = false;

            m_render_texture = new RenderTexture(texture_size, texture_size, 16);
            m_render_texture.name = "render_texture";
            m_render_camera.targetTexture = m_render_texture;

            m_parts = new GameObject().transform;
            m_parts.name = "parts";
            m_parts.parent = transform;
            m_parts.localPosition = Vector3.zero;
            m_parts.localScale = Vector3.one;

            m_part_arm_back = _create_character_part("part_arm", 0, 200, 50, 50);
            m_part_arm_front = _create_character_part("part_arm", 0, 250, 50, 50);
            m_part_body = _create_character_part("part_body", 100, 200, 100, 100);
            m_part_cape = _create_character_part("part_body", 200, 50, 150, 150);
            m_part_eye_0 = _create_character_part("part_eye_0", 200, 0, 50, 50);
            m_part_eye_1 = _create_character_part("part_eye_1", 250, 0, 50, 50);
            m_part_glove_main = _create_character_part("part_glove_main", 200, 250, 50, 50);
            m_part_glove_sub = _create_character_part("part_glove_sub", 200, 200, 50, 50);
            m_part_head_normal = _create_character_part("part_head_normal", 0, 0, 200, 200);
            m_part_helm = _create_character_part("part_helm", 0, 312, 256, 200);
            m_part_neck = _create_character_part("part_neck", 300, 0, 50, 50);
            m_part_leg_0 = _create_character_part("part_leg_0", 50, 250, 50, 50);
            m_part_leg_1 = _create_character_part("part_leg_1", 50, 200, 50, 50);
            m_part_weapon_main = _create_character_part("part_weapon_back", 256, 356, 256, 156);
            m_part_weapon_sub = _create_character_part("part_weapon_front", 256, 200, 256, 156);

            LoadPackages(preload_packages.ToArray());
        }
        public void LoadPackages(DevPart[] _packages)
        {
            foreach (DevPart pack in _packages)
            {
                if (m_package_list.ContainsKey(pack.package_name))
                    continue;
                m_package_list.Add(pack.package_name, pack);
            }
        }

        SpriteRenderer _create_character_part(string _name, float _pos_x, float _pos_y, float _width, float _height)
        {
            GameObject temp = new GameObject();
            temp.name = _name;
            temp.transform.parent = m_parts;
            temp.transform.localScale = Vector3.one;
            temp.transform.localPosition = new Vector2(-half_view_size + 0.01f * (_pos_x + 0.5f * _width), -half_view_size + 0.01f * (_pos_y + 0.5f * _height));
            temp.layer = layer_devwin_render_texture;
            SpriteRenderer r = temp.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            return r;
        }

        public Texture2D CreateCharacterTexture(CharacterData _info)
        {
            return CreateCharacterTexture(_info, null);
        }
        public Texture2D CreateCharacterTexture(CharacterData _info, string _save_path)
        {
            PackageData_Unit _pak_unit = GetPackage_Unit(_info.unit_part, _info.unit_index);
            PackageData_Armor _pak_armor = GetPackage_Armor(_info.armor_part, _info.armor_index, _info.armor_color);

            if (_pak_armor == null)
            {
                m_part_glove_main.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.GLOVE_MAIN, _info.unit_index, false, false);
                m_part_glove_main.color = _pak_unit == null ? Color.white : _pak_unit.glove_color;
                m_part_glove_sub.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.GLOVE_SUB, _info.unit_index, false, false);
                m_part_glove_sub.color = _pak_unit == null ? Color.white : _pak_unit.glove_color;
                m_part_arm_back.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.ARM_MAIN, _info.unit_index, false, false);
                m_part_arm_back.color = _pak_unit == null ? Color.white : _pak_unit.arm_color;
                m_part_arm_front.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.ARM_SUB, _info.unit_index, false, false);
                m_part_arm_front.color = _pak_unit == null ? Color.white : _pak_unit.arm_color;
                m_part_body.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.BODY, _info.unit_index, false, false);
                m_part_eye_0.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.EYE, _info.unit_index, false, false);
                m_part_eye_0.color = _pak_unit == null ? Color.white : _pak_unit.eye_color;
                m_part_eye_1.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.EYE, _info.unit_index, false, true);
                m_part_eye_1.color = _pak_unit == null ? Color.white : _pak_unit.eye_color;
                m_part_head_normal.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.FACE, _info.unit_index, false, false);
                m_part_leg_0.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.LEG_0, _info.unit_index, false, false);
                m_part_leg_1.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.LEG_1, _info.unit_index, false, false);
            }
            else
            {
                switch (_pak_armor.option)
                {
                    case SHOW_OPTION.HIDE_FACE:
                        m_part_eye_0.sprite = null;
                        m_part_eye_1.sprite = null;
                        m_part_head_normal.sprite = null;
                        break;
                    case SHOW_OPTION.SHOW_HAIR:
                        m_part_eye_0.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.EYE, _info.unit_index, false, false);
                        m_part_eye_0.color = _pak_unit == null ? Color.white : _pak_unit.eye_color;
                        m_part_eye_1.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.EYE, _info.unit_index, false, true);
                        m_part_eye_1.color = _pak_unit == null ? Color.white : _pak_unit.eye_color;
                        m_part_head_normal.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.FACE, _info.unit_index, false, false);
                        break;
                    default:
                        m_part_eye_0.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.EYE, _info.unit_index, false, false);
                        m_part_eye_0.color = _pak_unit == null ? Color.white : _pak_unit.eye_color;
                        m_part_eye_1.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.EYE, _info.unit_index, false, true);
                        m_part_eye_1.color = _pak_unit == null ? Color.white : _pak_unit.eye_color;
                        m_part_head_normal.sprite = GetSprite_Unit(_info.unit_part, CHARACTER_PART.FACE, _info.unit_index, true, false);
                        break;
                }

                m_part_arm_back.sprite = GetSprite_Armor(_info.armor_part, CHARACTER_PART.ARM_MAIN, _info.armor_index, _info.armor_color);
                m_part_arm_back.color = _pak_unit == null ? Color.white : _pak_armor.arm_color;
                m_part_arm_front.sprite = GetSprite_Armor(_info.armor_part, CHARACTER_PART.ARM_SUB, _info.armor_index, _info.armor_color);
                m_part_arm_front.color = _pak_unit == null ? Color.white : _pak_armor.arm_color;
                m_part_neck.color = _pak_armor.arm_color;
                m_part_body.sprite = GetSprite_Armor(_info.armor_part, CHARACTER_PART.BODY, _info.armor_index, _info.armor_color);
                m_part_glove_main.sprite = GetSprite_Armor(_info.armor_part, CHARACTER_PART.GLOVE_MAIN, _info.armor_index, _info.armor_color);
                m_part_glove_main.color = _pak_unit == null ? Color.white : _pak_armor.glove_color;
                m_part_glove_sub.sprite = GetSprite_Armor(_info.armor_part, CHARACTER_PART.GLOVE_SUB, _info.armor_index, _info.armor_color);
                m_part_glove_sub.color = _pak_unit == null ? Color.white : _pak_armor.glove_color;
                m_part_leg_0.sprite = GetSprite_Armor(_info.armor_part, CHARACTER_PART.LEG_0, _info.armor_index, _info.armor_color);
                m_part_leg_1.sprite = GetSprite_Armor(_info.armor_part, CHARACTER_PART.LEG_1, _info.armor_index, _info.armor_color);
            }

            // helm
            m_part_helm.sprite = GetSprite_Armor(_info.armor_part, CHARACTER_PART.HELM, _info.armor_index, _info.armor_color);
            m_part_neck.sprite = GetSprite_Armor(_info.armor_part, CHARACTER_PART.NECK, _info.armor_index, _info.armor_color);

            m_part_weapon_main.sprite = GetSprite_Weapon(_info.main_weapon_part, _info.main_weapon_index);
            m_part_weapon_sub.sprite = GetSprite_Weapon(_info.sub_weapon_part, _info.sub_weapon_index);
            m_part_cape.sprite = GetSprite_Wing(_info.wing_part, _info.wing_index);

            m_render_camera.Render();

            RenderTexture.active = m_render_camera.targetTexture;
            Texture2D output = new Texture2D(DevEngine.texture_size, DevEngine.texture_size, TextureFormat.ARGB32, false);
            output.ReadPixels(new Rect(0, 0, DevEngine.texture_size, DevEngine.texture_size), 0, 0);
            output.Apply();

            if (string.IsNullOrEmpty(_save_path) == false)
            {
                byte[] pngShot = output.EncodeToPNG();
                //System.IO.File.WriteAllBytes(_save_path, pngShot);

                System.IO.FileStream fs = new System.IO.FileStream(_save_path, System.IO.FileMode.Create);
                System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
                bw.Write(pngShot);
                bw.Close();
                fs.Close();
            }
            return output;
        }




    }
}
