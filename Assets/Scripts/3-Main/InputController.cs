﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    PlayerController _playerController;

    Player_Attack _attack;
    Player_Skill1 _skill1;
    Player_Skill2 _skill2;
    Player_SkillChange _skillChange;
    Player_Magic1 _magic1;
    Player_Magic2 _magic2;
    Player_AuthoritySkill _authortySkill;

    //攻撃できなくする
    //動けなくする・攻撃できなくする
    //敵の動きを止める

    private void Awake()
    {
        _playerController = _player.GetComponent<PlayerController>();
        _attack = _player.GetComponentInChildren<Player_Attack>();
        _skill1 = _player.GetComponentInChildren<Player_Skill1>();
        _skill2 = _player.GetComponentInChildren<Player_Skill2>();
        _skillChange = _player.GetComponentInChildren<Player_SkillChange>();
        _magic1 = _player.GetComponentInChildren<Player_Magic1>();
        _magic2 = _player.GetComponentInChildren<Player_Magic2>();
        _authortySkill = _player.GetComponentInChildren<Player_AuthoritySkill>();
    }

    private void Start()
    {
        _playerController.enabled = false;
        _authortySkill.enabled = false;
    }

    public void MoveOnly() //行動だけできる
    {
        _playerController.enabled = true;
    }

    public void AttackOnly() //通常攻撃だけできる
    {
        _playerController.enabled = true;
        _attack.enabled = true;
    }

    public void Event3()
    {
        _playerController.enabled = true;
        _attack.enabled = true;
        _skill1.enabled = true;
        _skill2.enabled = true;
    }
    public void Event3_2()
    {
        _playerController.enabled = true;
        _attack.enabled = true;
        _skill1.enabled = true;
        _skill2.enabled = true;
        _skillChange.enabled = true;
        _magic1.enabled = true;
        _magic2.enabled = true;
    }

    public void NonAttack() //7種類　何もできない
    {
        _attack.enabled = false;
        _skill1.enabled = false;
        _skill2.enabled = false;   
        _skillChange.enabled = false;
        _magic1.enabled = false;
        _magic2.enabled = false;
        _authortySkill.enabled = false;
    }

    public void ASSkill() //権限スキル中
    {
        _playerController.enabled = false;
        _attack.enabled = false;
        _skill1.enabled = false;
        _skill2.enabled = false;
        _skillChange.enabled = false;
        _magic1.enabled = false;
        _magic2.enabled = false;
    }

    public void Attack()　//全部使えるようにする
    {
        _attack.enabled = true;
        _skill1.enabled = true;
        _skill2.enabled = true;
        _skillChange.enabled = true;
        _magic1.enabled = true;
        _magic2.enabled = true;
    }

    public void PlayerStop() //スキルが使えない+動きもできない
    {
        _playerController.enabled = false;
        _attack.enabled = false;
        _skill1.enabled = false;
        _skill2.enabled = false;
        _skillChange.enabled = false;
        _magic1.enabled = false;
        _magic2.enabled = false;
        _authortySkill.enabled = false;
    }

    public void PlayerAwake()　//権限スキルだけつけない
    {
        _playerController.enabled = true;
        _attack.enabled = true;
        _skill1.enabled = true;
        _skill2.enabled = true;
        _skillChange.enabled = true;
        _magic1.enabled = true;
        _magic2.enabled = true;
    }

    public void AuthortySkill()
    {
        _authortySkill.enabled = true;
    }

}
