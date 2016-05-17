using UnityEngine;
using System.Collections;
using Devwin;

public class DemoCharacter : MonoBehaviour
{
    public DevCharacter actor;
    public Collider2D colid;

    const float time_out = 3.0f;
    enum ANIM
    {
        NONE,
        WALK,
        ATTACK,
        DAMAGE,
        DEATH,
    }

    ANIM m_last_anim = ANIM.NONE;
    float m_animTime = 0f;

    public void Tick(float _deltaTime)
    {
        m_animTime += _deltaTime;
        if (m_animTime > time_out)
        {
            m_animTime -= time_out;
            ChangeAnimation();
        }
    }
    public void ChangeAnimation()
    {
        int seed = Random.Range(0, 100);
        if (seed < 30)
        {
            if (m_last_anim != ANIM.WALK)
            {
                this.Walk();
                m_last_anim = ANIM.WALK;
            }
        }
        else if (seed < 50)
        {
            this.Damage();
            m_last_anim = ANIM.DAMAGE;
        }
        else if (seed < 60)
        {
            this.Death();
            m_last_anim = ANIM.DEATH;
        }
        else
        {
            switch (actor.main_weapon_type)
            {
                case PACKAGE_TYPE.WEAPON_BOW:
                    this.Shoot();
                    break;
                default:
                    if (seed < 80)
                        this.Attack1();
                    else
                        this.Attack2();
                    break;
            }
            m_last_anim = ANIM.ATTACK;
        }
    }

    public void Init(int _depth)
    {
        m_animTime = time_out * Random.Range(0f, 1f);
        actor.Info.order = _depth;
        actor.UpdateView();
        this.Idle();
    }

    public bool Touch(Vector3 _world_pos)
    {
        if (colid.OverlapPoint(_world_pos))
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                this.Damage();
            }
            else
            {
                this.Death();
            }
            m_animTime = 0f;
            return true;
        }
        return false;
    }

    public void Attack1()
    {
        switch (actor.main_weapon_type)
        {
            case PACKAGE_TYPE.WEAPON_BOW:
                actor.PlayAnimation("anim_melee_attack1", false);
                break;
            case PACKAGE_TYPE.WEAPON_STAFF:
                actor.PlayAnimation("anim_staff_attack1", false);
                break;
            case PACKAGE_TYPE.WEAPON_MELEE:
            default:
                actor.PlayAnimation("anim_melee_attack1", false);
                break;
        }
    }
    public void Attack2()
    {
        switch (actor.main_weapon_type)
        {
            case PACKAGE_TYPE.WEAPON_BOW:
                actor.PlayAnimation("anim_melee_attack2", true);
                break;
            case PACKAGE_TYPE.WEAPON_STAFF:
                actor.PlayAnimation("anim_staff_attack2", true);
                break;
            case PACKAGE_TYPE.WEAPON_MELEE:
            default:
                actor.PlayAnimation("anim_melee_attack2", true);
                break;
        }
    }
    public void Stab()
    {
        actor.PlayAnimation("anim_melee_stab", true);
    }
    public void Casting()
    {
        actor.PlayAnimation("anim_staff_casting", true);
    }
    public void Shoot()
    {
        actor.PlayAnimation("anim_bow_shoot", true);
    }
    public void Shoot_1()
    {
        actor.PlayAnimation("anim_bow_shoot_1", true);
    }
    public void Damage()
    {
        switch (actor.main_weapon_type)
        {
            case PACKAGE_TYPE.WEAPON_BOW:
                actor.PlayAnimation("anim_bow_damage", true);
                break;
            case PACKAGE_TYPE.WEAPON_STAFF:
                actor.PlayAnimation("anim_staff_damage", true);
                break;
            case PACKAGE_TYPE.WEAPON_MELEE:
            default:
                actor.PlayAnimation("anim_melee_damage", true);
                break;
        }
    }

    public void Death()
    {
        actor.PlayAnimation("anim_death1", true);
    }

    public void Idle()
    {
        switch (actor.main_weapon_type)
        {
            case PACKAGE_TYPE.WEAPON_BOW:
                actor.PlayAnimation("anim_bow_idle", false);
                break;
            case PACKAGE_TYPE.WEAPON_STAFF:
                actor.PlayAnimation("anim_staff_idle", false);
                break;
            case PACKAGE_TYPE.WEAPON_MELEE:
            default:
                actor.PlayAnimation("anim_melee_idle", false);
                break;
        }
    }

    public void Jump()
    {
        switch (actor.main_weapon_type)
        {
            case PACKAGE_TYPE.WEAPON_BOW:
                actor.PlayAnimation("anim_bow_jump", true);
                break;
            case PACKAGE_TYPE.WEAPON_STAFF:
                actor.PlayAnimation("anim_staff_jump", true);
                break;
            case PACKAGE_TYPE.WEAPON_MELEE:
            default:
                actor.PlayAnimation("anim_melee_jump", true);
                break;
        }
    }

    public void Walk()
    {
        switch (actor.main_weapon_type)
        {
            case PACKAGE_TYPE.WEAPON_BOW:
                actor.PlayAnimation("anim_bow_walk", false);
                break;
            case PACKAGE_TYPE.WEAPON_STAFF:
                actor.PlayAnimation("anim_staff_walk", false);
                break;
            case PACKAGE_TYPE.WEAPON_MELEE:
            default:
                actor.PlayAnimation("anim_melee_walk", false);
                break;
        }
    }
}
