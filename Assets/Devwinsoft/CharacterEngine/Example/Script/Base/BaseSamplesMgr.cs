using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Devwin
{
    public delegate void func_character(DevCharacter _character, int _depth, bool _random);

    public abstract class BaseSamplesMgr : MonoBehaviour
    {
        public Transform prefab_character_engine;
        public DemoCharacter[] characters;
        public Camera ui_camera;
        public bool is_loading { get { return m_loading; } }
        public List<DevPart> packages = new List<DevPart>();
        bool m_loading = true;
        int m_load_total = 0;
        int m_load_index = 0;

        public func_character callback { get { return m_callback; } set { m_callback = value; } }
        func_character m_callback = null;
        public string title { get { return m_title; } set { m_title = value; } }
        string m_title = "";
        public string packname { get { return m_packname; } set { m_packname = value; } }
        string m_packname = "";

        public void Init()
        {
            DevEngine.Instance.LoadPackages(packages.ToArray());
            characters = transform.GetComponentsInChildren<DemoCharacter>();
            m_load_total = characters.Length;
            StartCoroutine(LoadCharacters(false));
        }

        void OnGUI()
        {
#if PREVIEW
            if (GUI.Button(new Rect(5, 5, 150, 40), "Show Viewer"))
            {
                Application.LoadLevel(string.Format("{0}Viewer", m_packname));
            }
#endif
            GUIStyle temp_style = new GUIStyle();
            temp_style.fontStyle = FontStyle.Bold;
            temp_style.alignment = TextAnchor.MiddleCenter;
            if (this.is_loading)
            {
                temp_style.fontSize = 50;
                GUI.Label(new Rect(0, 0, Screen.width, 50), string.Format("{0}/{1}", m_load_index, m_load_total), temp_style);
            }
            else
            {
                if (GUI.Button(new Rect(Screen.width - 155, 5, 150, 40), "Random"))
                {
                    foreach (DemoCharacter obj in characters)
                    {
                        obj.actor.PlayAnimation("anim_init", true);
                    }
                    StartCoroutine(LoadCharacters(true));
                }
                temp_style.fontSize = 30;
                GUI.Label(new Rect(0, 0, Screen.width, 50), m_title, temp_style);
                GUI.Label(new Rect(0, Screen.height - 50, Screen.width, 50), "Touch them!", temp_style);
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 click_pos = ui_camera.ScreenToWorldPoint(Input.mousePosition);
                foreach (DemoCharacter obj in characters)
                {
                    if (obj.Touch(click_pos))
                    {
                        break;
                    }
                }
            }
            else if (this.is_loading == false)
            {
                foreach (DemoCharacter obj in characters)
                {
                    obj.Tick(Time.deltaTime);
                }
            }
        }

        IEnumerator LoadCharacters(bool _random)
        {
            m_loading = true;
            while (DevEngine.is_created == false)
            {
                yield return 0;
            }
            if (_random)
            {
                yield return new WaitForFixedUpdate();
            }
            foreach (DemoCharacter obj in characters)
            {
                obj.gameObject.SetActive(false);
            }

            for (int i = 0; i < characters.Length; i++)
            {
                DemoCharacter obj = characters[i];
                m_load_index = i + 1;
                yield return 0f;
                obj.gameObject.SetActive(true);
                if (m_callback != null)
                {
                    m_callback(obj.actor, i, _random);
                }
                obj.Init(i);
                obj.Idle();
            }
            m_loading = false;
        }
    }
}