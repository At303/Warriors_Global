using UnityEngine;
using UnityEditor;
using System.Collections;
using Devwin;

public class DevwinEditor : EditorWindow
{
    [@MenuItem("Window/Devwin/Texture Baking")]
    static void BakingCharacterTexture()
    {
        EditorWindow.GetWindowWithRect(typeof(DevwinEditor), new Rect(0,0, 510f, 340f), true);
    }

    [@MenuItem("Window/Devwin/Create a Character Part")]
    static void CreatePackage()
    {
        string path = EditorUtility.SaveFilePanel(
                    "Create a Character Part",
                    "Assets",
                    "default",
                    "prefab");
        if (path.StartsWith(Application.dataPath))
        {
            string temp_path = path.Substring(Application.dataPath.Length + 1);
            Object empty_obj = PrefabUtility.CreateEmptyPrefab("Assets/" + temp_path);
            GameObject temp_obj = new GameObject();
            temp_obj.AddComponent<DevPart>();
            PrefabUtility.ReplacePrefab(temp_obj, empty_obj, ReplacePrefabOptions.ConnectToPrefab);
            DestroyImmediate(temp_obj);
        }
        else if (path.Length != 0)
        {
            EditorUtility.DisplayDialog(
                    "Failed to create a part",
                    string.Format("You must select child folder of {0}", Application.dataPath),
                    "OK");
        }
    }

    Color m_color_old = GUI.backgroundColor;
    Color m_color_blue = new Color(0.2f, 1f, 1f, 1f);
    Color m_color_green = new Color(0.3f, 0.9f, 0f, 1f);
    
    DevPart m_unit_part;
    int m_unit_index;

    DevPart m_armor_part;
    int m_armor_index;
    int m_armor_color;

    DevPart m_weapon_main_part;
    int m_weapon_main_index;

    DevPart m_weapon_sub_part;
    int m_weapon_sub_index;

    DevPart m_wing_part;
    int m_wing_index;

    CharacterData m_data = new CharacterData();

    void OnEnable()
    {
        this.title = "Texture Baking";
    }
    
    int _index_value(int _value)
    {
        return Mathf.Max(0, _value - 1);
    }
    void OnGUI()
    {
        const float temp_width_total = 500f;
        const float temp_width_label = 200f;
        DevPart temp_part = null;

        // unit
        GUI.backgroundColor = m_color_green;
        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Unit Package", GUILayout.Width(temp_width_label));
        temp_part = (DevPart)EditorGUILayout.ObjectField(m_unit_part, typeof(DevPart), false);
        if (temp_part == null || temp_part.type == PACKAGE_TYPE.UNIT)
            m_unit_part = temp_part;
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = m_color_old;

        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Unit Index", GUILayout.Width(temp_width_label));
        if (m_unit_part != null)
        {
            m_unit_index = EditorGUILayout.IntSlider(m_unit_index, 0, _index_value(m_unit_part.item_count));
        }
        else
        {
            m_unit_index = EditorGUILayout.IntSlider(m_unit_index, 0, 0);
        }
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10f);

        // armor
        GUI.backgroundColor = m_color_green;
        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Armor Package", GUILayout.Width(temp_width_label));
        temp_part = (DevPart)EditorGUILayout.ObjectField(m_armor_part, typeof(DevPart), false);
        if (temp_part == null || temp_part.type == PACKAGE_TYPE.ARMOR)
            m_armor_part = temp_part;
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = m_color_old;

        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Armor Index", GUILayout.Width(temp_width_label));
        if (m_armor_part != null)
        {
            m_armor_index = EditorGUILayout.IntSlider(m_armor_index, 0, _index_value(m_armor_part.item_count));
        }
        else
        {
            m_armor_index = EditorGUILayout.IntSlider(m_armor_index, 0, 0);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Armor Color", GUILayout.Width(temp_width_label));
        if (m_armor_part != null)
        {
            m_armor_color = EditorGUILayout.IntSlider(m_armor_color, 0, _index_value(m_armor_part.color_count));
        }
        else
        {
            m_armor_color = EditorGUILayout.IntSlider(m_armor_color, 0, 0);
        }
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10f);

        // weapon main
        GUI.backgroundColor = m_color_green;
        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Weapon Package (Main)", GUILayout.Width(temp_width_label));
        temp_part = (DevPart)EditorGUILayout.ObjectField(m_weapon_main_part, typeof(DevPart), false);
        if (temp_part == null)
        {
            m_weapon_main_part = temp_part;
        }
        else
        {
            switch (temp_part.type)
            {
                case PACKAGE_TYPE.WEAPON_BOW:
                case PACKAGE_TYPE.WEAPON_MELEE:
                case PACKAGE_TYPE.WEAPON_STAFF:
                    m_weapon_main_part = temp_part;
                    break;
                default:
                    break;
            }
        }
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = m_color_old;

        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Weapon Index (Main)", GUILayout.Width(temp_width_label));
        if (m_weapon_main_part != null)
        {
            m_weapon_main_index = EditorGUILayout.IntSlider(m_weapon_main_index, 0, _index_value(m_weapon_main_part.item_count));
        }
        else
        {
            m_weapon_main_index = EditorGUILayout.IntSlider(m_weapon_main_index, 0, 0);
        }
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10f);

        // weapon sub
        GUI.backgroundColor = m_color_green;
        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Weapon Package (Sub)", GUILayout.Width(temp_width_label));
        temp_part = (DevPart)EditorGUILayout.ObjectField(m_weapon_sub_part, typeof(DevPart), false);
        if (temp_part == null)
        {
            m_weapon_sub_part = temp_part;
        }
        else
        {
            switch (temp_part.type)
            {
                case PACKAGE_TYPE.WEAPON_ARROW:
                case PACKAGE_TYPE.WEAPON_MELEE:
                case PACKAGE_TYPE.WEAPON_SHIELD:
                    m_weapon_sub_part = temp_part;
                    break;
                default:
                    break;
            }
        }
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = m_color_old;

        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Weapon Index (Sub)", GUILayout.Width(temp_width_label));
        if (m_weapon_sub_part != null)
        {
            m_weapon_sub_index = EditorGUILayout.IntSlider(m_weapon_sub_index, 0, _index_value(m_weapon_sub_part.item_count));
        }
        else
        {
            m_weapon_sub_index = EditorGUILayout.IntSlider(m_weapon_sub_index, 0, 0);
        }
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10f);

        // wing
        GUI.backgroundColor = m_color_green;
        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Wing Package", GUILayout.Width(temp_width_label));
        temp_part = (DevPart)EditorGUILayout.ObjectField(m_wing_part, typeof(DevPart), false);
        if (temp_part == null || temp_part.type == PACKAGE_TYPE.WING)
            m_wing_part = temp_part;
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = m_color_old;

        EditorGUILayout.BeginHorizontal(GUILayout.Width(temp_width_total));
        EditorGUILayout.LabelField("Wing Index", GUILayout.Width(temp_width_label));
        if (m_wing_part != null)
        {
            m_wing_index = EditorGUILayout.IntSlider(m_wing_index, 0, _index_value(m_wing_part.item_count));
        }
        else
        {
            m_wing_index = EditorGUILayout.IntSlider(m_wing_index, 0, 0);
        }
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(20f);

        GUI.backgroundColor = m_color_blue;
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Generate Texture", GUILayout.Width(200f), GUILayout.Height(30f)))
        {
            string save_path = EditorUtility.SaveFilePanel(
            "Generate Texture",
            "Assets",
            "default",
            "png");
            if (save_path.StartsWith(Application.dataPath))
            {
                GameObject temp_obj = new GameObject();
                DevEngine temp_engine = temp_obj.AddComponent<DevEngine>();
                if (m_unit_part != null)
                {
                    m_data.unit_part = m_unit_part.package_name;
                    m_data.unit_index = m_unit_index;
                    temp_engine.preload_packages.Add(m_unit_part);
                }
                else
                {
                    m_data.unit_part = "";
                }
                if (m_armor_part != null)
                {
                    m_data.armor_part = m_armor_part.package_name;
                    m_data.armor_index = m_armor_index;
                    m_data.armor_color = m_armor_color;
                    temp_engine.preload_packages.Add(m_armor_part);
                }
                else
                {
                    m_data.armor_part = "";
                }
                if (m_weapon_main_part != null)
                {
                    m_data.main_weapon_part = m_weapon_main_part.package_name;
                    m_data.main_weapon_index = m_weapon_main_index;
                    temp_engine.preload_packages.Add(m_weapon_main_part);
                }
                else
                {
                    m_data.main_weapon_part = "";
                }
                if (m_weapon_sub_part != null)
                {
                    m_data.sub_weapon_part = m_weapon_sub_part.package_name;
                    m_data.sub_weapon_index = m_weapon_sub_index;
                    temp_engine.preload_packages.Add(m_weapon_sub_part);
                }
                else
                {
                    m_data.sub_weapon_part = "";
                }
                if (m_wing_part != null)
                {
                    m_data.wing_part = m_wing_part.package_name;
                    m_data.wing_index = m_wing_index;
                    temp_engine.preload_packages.Add(m_wing_part);
                }
                else
                {
                    m_data.wing_part = "";
                }
                temp_engine.Init();
                temp_engine.CreateCharacterTexture(m_data, save_path);
                DestroyImmediate(temp_obj);
                EditorUtility.DisplayDialog("Successfully created", "", "OK");
            }
            else if (save_path.Length != 0)
            {
                EditorUtility.DisplayDialog(
                        "Failed to create package",
                        string.Format("You must select child folder of {0}", Application.dataPath),
                        "OK");
            }
        }
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = m_color_old;
    }


    static public void BeginBox()
    {
        GUILayout.BeginHorizontal();
        EditorGUILayout.BeginHorizontal("AS TextArea", GUILayout.MinHeight(11f));
        GUILayout.BeginVertical();
        GUILayout.Space(2f);
    }
    public static void EndBox()
    {
        GUILayout.Space(3f);
        GUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(3f);
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(3f);
    }

    static public bool DrawHeader(string text)
    {
        return DrawHeader(text, text);
    }
    static public bool DrawHeader(string text, string key)
    {
        bool state = EditorPrefs.GetBool(key, false);

        GUILayout.Space(3f);
        if (!state) GUI.backgroundColor = new Color(0.8f, 0.8f, 0.8f);
        GUILayout.BeginHorizontal();
        GUI.changed = false;

        text = "<b><size=11>" + text + "</size></b>";
        if (state) text = "\u25BC " + text;
        else text = "\u25BA " + text;
        if (!GUILayout.Toggle(true, text, "dragtab", GUILayout.MinWidth(20f))) state = !state;
        if (GUI.changed) EditorPrefs.SetBool(key, state);

        GUILayout.Space(2f);
        GUILayout.EndHorizontal();
        GUI.backgroundColor = Color.white;
        if (!state) GUILayout.Space(3f);
        return state;
    }
}
