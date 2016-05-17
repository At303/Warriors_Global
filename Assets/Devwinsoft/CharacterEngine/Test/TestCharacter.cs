using UnityEngine;
using System.Collections;
using Devwin;

public class TestCharacter : MonoBehaviour
{
    public DevCharacter character;

    void Start()
    {
        character.Info.order = 1;
        character.Info.unit_part = "undead";
        character.Info.main_weapon_part = "blunt-a";
        character.UpdateView(); // with texture-baking
        //character.InitWithoutTextureBaking();

        switch (character.main_weapon_type)
        {
            case PACKAGE_TYPE.WEAPON_BOW:
                character.PlayAnimation("anim_bow_walk", false);
                break;
            case PACKAGE_TYPE.WEAPON_STAFF:
                character.PlayAnimation("anim_staff_walk", false);
                break;
            case PACKAGE_TYPE.WEAPON_MELEE:
            default:
                character.PlayAnimation("anim_melee_walk", false);
                break;
        }
    }
}
