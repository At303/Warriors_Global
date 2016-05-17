//----------------------------------------------
// Title    : Devwin Character Engine
// Copyright: © 2012-2015 devwinsoft
// Contact  : maoshy@nate.com
//----------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Devwin;

public class DevCharacter : MonoBehaviour
{
    public DevCharacter_Impl Impl;
    public List<IAnimEventListener> event_listener = new List<IAnimEventListener>();

    public CharacterData Info { get { return Impl.Info; } }
    public PACKAGE_TYPE main_weapon_type { get { return Impl.main_weapon_type; } }
    public PACKAGE_TYPE sub_weapon_type { get { return Impl.sub_weapon_type; } }

    public void UpdateView()
    {
        Impl.UpdateView();
    }
    public void UpdateView(Texture2D _texture)
    {
        Impl.UpdateView(_texture);
    }
    public void SetOrder(int _order)
    {
        Impl.SetOrder(_order);
    }

    public void InitWithoutTextureBaking()
    {
        Impl.InitWithoutTextureBaking();
    }
    public Texture2D GetMaterialTexture()
    {
        return Impl.GetMaterialTexture();
    }
    public void SetMaterialTexture(Texture2D _texture)
    {
        Impl.SetMaterialTexture(_texture);
    }
    public void SetAlpha(float _value)
    {
        Impl.SetAlpha(_value);
    }
    public void SetChroma(float _value)
    {
        Impl.SetChroma(_value);
    }
    public void SetColor(Color _value)
    {
        Impl.SetColor(_value);
    }

    // animation event
    public void _OnHitting(int _index)
    {
        foreach (IAnimEventListener obj in event_listener)
        {
            obj.OnAnimation_Hitting(_index);
        }
    }
    public void _OnAttackMove()
    {
        foreach (IAnimEventListener obj in event_listener)
        {
            obj.OnAnimation_AttackMove();
        }
    }

    public void SetAnimationSpeed(float _value)
    {
        Impl.anim.speed = _value;
    }

    public void PlayAnimation(string _anim, bool _reset)
    {
        Impl.PlayAnimation(_anim, _reset);
    }
}
