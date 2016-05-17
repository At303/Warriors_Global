using UnityEngine;
using System.Collections;

namespace Devwin
{
    public class DemoSamplesMgr : BaseSamplesMgr
    {
        void Start()
        {
            base.title = "Devwin Character Engine";
            base.packname = "Demo";
            base.callback = this.InitCharacter;
            base.Init();
        }

        void InitCharacter(DevCharacter _character, int _depth, bool _random)
        {
            if (_random)
            {
                DevPart[] temp_pak;
                int temp_index;
                DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.UNIT);
                temp_index = Random.Range(0, temp_pak.Length);
                _character.Info.unit_part = temp_pak[temp_index].package_name;
                _character.Info.unit_index = Random.Range(0, temp_pak[temp_index].item_count);

                DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.ARMOR);
                temp_index = Random.Range(0, temp_pak.Length);
                _character.Info.armor_part = temp_pak[temp_index].package_name;
                _character.Info.armor_index = Random.Range(0, temp_pak[temp_index].item_count);
                _character.Info.armor_color = Random.Range(0, temp_pak[temp_index].color_count);

                switch (Random.Range(0, 3))
                {
                    case 0:
                        {
                            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.WEAPON_BOW);
                            temp_index = Random.Range(0, temp_pak.Length);
                            _character.Info.main_weapon_part = temp_pak[temp_index].package_name;
                            _character.Info.main_weapon_index = Random.Range(0, temp_pak[temp_index].item_count);
                        }
                        {
                            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.WEAPON_ARROW);
                            temp_index = Random.Range(0, temp_pak.Length);
                            _character.Info.sub_weapon_part = temp_pak[temp_index].package_name;
                            _character.Info.sub_weapon_index = Random.Range(0, temp_pak[temp_index].item_count);
                        }
                        break;
                    case 1:
                        {
                            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.WEAPON_STAFF);
                            temp_index = Random.Range(0, temp_pak.Length);
                            _character.Info.main_weapon_part = temp_pak[temp_index].package_name;
                            _character.Info.main_weapon_index = Random.Range(0, temp_pak[temp_index].item_count);
                            _character.Info.sub_weapon_part = "";
                        }
                        break;
                    default:
                        {
                            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.WEAPON_MELEE);
                            temp_index = Random.Range(0, temp_pak.Length);
                            _character.Info.main_weapon_part = temp_pak[temp_index].package_name;
                            _character.Info.main_weapon_index = Random.Range(0, temp_pak[temp_index].item_count);
                        }
                        {
                            DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.WEAPON_SHIELD);
                            temp_index = Random.Range(0, temp_pak.Length);
                            _character.Info.sub_weapon_part = temp_pak[temp_index].package_name;
                            _character.Info.sub_weapon_index = Random.Range(0, temp_pak[temp_index].item_count);
                        }
                        break;
                }

                if (Random.Range(0, 2) == 0)
                {
                    DevEngine.Instance.GetPackageList(out temp_pak, PACKAGE_TYPE.WING);
                    temp_index = Random.Range(0, temp_pak.Length);
                    _character.Info.wing_part = temp_pak[temp_index].package_name;
                    _character.Info.wing_index = Random.Range(0, temp_pak[temp_index].item_count);
                }
                else
                {
                    _character.Info.wing_part = "";
                }
            }
            else
            {
                switch (_depth)
                {
                    case 5 * 0 + 0:
                        _character.Info.unit_part = "undead";
                        _character.Info.unit_index = 1;
                        _character.Info.main_weapon_part = "blunt-a";
                        _character.Info.main_weapon_index = 4;
                        break;
                    case 5 * 0 + 1:
                        _character.Info.unit_part = "darkelf-male";
                        _character.Info.unit_index = 0;
                        _character.Info.main_weapon_part = "axe-a";
                        _character.Info.main_weapon_index = 0;
                        _character.Info.sub_weapon_part = "shield-a";
                        _character.Info.sub_weapon_index = 0;
                        break;
                    case 5 * 0 + 2:
                        _character.Info.unit_part = "imp";
                        _character.Info.unit_index = 0;
                        _character.Info.main_weapon_part = "bow-a";
                        _character.Info.main_weapon_index = 12;
                        _character.Info.sub_weapon_part = "arrow-a";
                        _character.Info.sub_weapon_index = 0;
                        _character.Info.wing_part = "wing-a";
                        _character.Info.wing_index = 0;
                        break;
                    case 5 * 0 + 3:
                        _character.Info.unit_part = "troll";
                        _character.Info.unit_index = 0;
                        _character.Info.armor_part = "steel-a";
                        _character.Info.armor_index = 0;
                        _character.Info.main_weapon_part = "axe-a";
                        _character.Info.main_weapon_index = 2;
                        break;
                    case 5 * 0 + 4:
                        _character.Info.unit_part = "orc";
                        _character.Info.unit_index = 0;
                        _character.Info.armor_part = "steel-a";
                        _character.Info.armor_index = 4;
                        _character.Info.armor_color = 0;
                        _character.Info.main_weapon_part = "blunt-a";
                        _character.Info.main_weapon_index = 9;
                        _character.Info.sub_weapon_part = "shield-a";
                        _character.Info.sub_weapon_index = 1;
                        break;

                    case 5 * 1 + 0:
                        _character.Info.unit_part = "undead";
                        _character.Info.unit_index = 0;
                        _character.Info.armor_part = "hood-a";
                        _character.Info.armor_index = 0;
                        _character.Info.armor_color = 2;
                        _character.Info.main_weapon_part = "bow-a";
                        _character.Info.main_weapon_index = 13;
                        _character.Info.sub_weapon_part = "arrow-a";
                        _character.Info.wing_part = "cape-a";
                        _character.Info.wing_index = 10;
                        break;
                    case 5 * 1 + 1:
                        _character.Info.unit_part = "darkelf-female";
                        _character.Info.unit_index = 0;
                        _character.Info.armor_part = "hood-a";
                        _character.Info.armor_index = 2;
                        _character.Info.armor_color = 2;
                        _character.Info.main_weapon_part = "dagger-a";
                        _character.Info.main_weapon_index = 1;
                        break;
                    case 5 * 1 + 2:
                        _character.Info.unit_part = "elf-male";
                        _character.Info.unit_index = 0;
                        _character.Info.armor_part = "hood-a";
                        _character.Info.armor_index = 2;
                        _character.Info.armor_color = 3;
                        _character.Info.main_weapon_part = "bow-a";
                        _character.Info.main_weapon_index = 11;
                        _character.Info.sub_weapon_part = "arrow-a";
                        break;
                    case 5 * 1 + 3:
                        _character.Info.unit_part = "elf-female";
                        _character.Info.unit_index = 3;
                        _character.Info.armor_part = "mithril-a";
                        _character.Info.armor_index = 1;
                        _character.Info.main_weapon_part = "sword-a";
                        _character.Info.main_weapon_index = 11;
                        _character.Info.sub_weapon_part = "shield-a";
                        _character.Info.sub_weapon_index = 4;
                        _character.Info.wing_part = "wing-a";
                        _character.Info.wing_index = 5;
                        break;
                    case 5 * 1 + 4:
                        _character.Info.unit_part = "human-male";
                        _character.Info.unit_index = 0;
                        _character.Info.armor_part = "mithril-a";
                        _character.Info.armor_index = 2;
                        _character.Info.main_weapon_part = "sword-a";
                        _character.Info.main_weapon_index = 13;
                        _character.Info.sub_weapon_part = "shield-a";
                        _character.Info.sub_weapon_index = 4;
                        _character.Info.wing_part = "cape-a";
                        _character.Info.wing_index = 3;
                        break;

                    case 5 * 2 + 0:
                        _character.Info.unit_part = "mummy";
                        _character.Info.unit_index = 0;
                        _character.Info.main_weapon_part = "staff-a";
                        _character.Info.main_weapon_index = 7;
                        _character.Info.wing_part = "wing-a";
                        _character.Info.wing_index = 4;
                        break;
                    case 5 * 2 + 1:
                        _character.Info.unit_part = "goblin";
                        _character.Info.unit_index = 0;
                        _character.Info.armor_part = "robe-a";
                        _character.Info.armor_index = 0;
                        _character.Info.armor_color = 2;
                        _character.Info.main_weapon_part = "staff-a";
                        _character.Info.main_weapon_index = 3;
                        _character.Info.wing_part = "cape-a";
                        _character.Info.wing_index = 10;
                        break;
                    case 5 * 2 + 2:
                        _character.Info.unit_part = "human-female";
                        _character.Info.unit_index = 1;
                        _character.Info.armor_part = "robe-a";
                        _character.Info.armor_index = 1;
                        _character.Info.armor_color = 1;
                        _character.Info.main_weapon_part = "staff-a";
                        _character.Info.main_weapon_index = 10;
                        _character.Info.wing_part = "cape-a";
                        _character.Info.wing_index = 11;
                        break;
                    case 5 * 2 + 3:
                        _character.Info.unit_part = "elf-female";
                        _character.Info.unit_index = 1;
                        _character.Info.armor_part = "robe-a";
                        _character.Info.armor_index = 1;
                        _character.Info.armor_color = 3;
                        _character.Info.main_weapon_part = "staff-a";
                        _character.Info.main_weapon_index = 14;
                        break;
                    case 5 * 2 + 4:
                        _character.Info.unit_part = "dwarf-male";
                        _character.Info.unit_index = 2;
                        _character.Info.armor_part = "robe-a";
                        _character.Info.armor_index = 1;
                        _character.Info.armor_color = 4;
                        _character.Info.main_weapon_part = "staff-a";
                        _character.Info.main_weapon_index = 19;
                        _character.Info.wing_part = "cape-a";
                        _character.Info.wing_index = 9;
                        break;

                    default:
                        break;
                }
            } // end of if (_random)
        }
    }
}
