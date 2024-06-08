using System.Collections;
using System.Collections.Generic;
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
    //Player_Magic2 _magic2;
    Player_AuthoritySkill _authortySkill;

    //UŒ‚‚Å‚«‚È‚­‚·‚é
    //“®‚¯‚È‚­‚·‚éEUŒ‚‚Å‚«‚È‚­‚·‚é
    //“G‚Ì“®‚«‚ğ~‚ß‚é

    private void Awake()
    {
        _playerController = _player.GetComponent<PlayerController>();
        _attack = _player.GetComponentInChildren<Player_Attack>();
        _skill1 = _player.GetComponentInChildren<Player_Skill1>();
        _skill2 = _player.GetComponentInChildren<Player_Skill2>();
        _skillChange = _player.GetComponentInChildren<Player_SkillChange>();
        _magic1 = _player.GetComponentInChildren<Player_Magic1>();
        //_magic2 = _player.GetComponentInChildren<Player_Magic2>();
        _authortySkill = _player.GetComponentInChildren<Player_AuthoritySkill>();
    }

    public void NonAttack()
    {
        _attack.enabled = false;
        _skill1.enabled = false;
        _skill2.enabled = false;   
        _skillChange.enabled = false;
        _magic1.enabled = false;
        //_magic2.enabled = false;
        _authortySkill.enabled = false;
    }

    public void Attack()
    {
        _attack.enabled = true;
        _skill1.enabled = true;
        _skill2.enabled = true;
        _skillChange.enabled = true;
        _magic1.enabled = true;
        //_magic2.enabled = true;
        _authortySkill.enabled = true;
    }

    public void PlayerStop()
    {
        _playerController.enabled = false;
        _attack.enabled = false;
        _skill1.enabled = false;
        _skill2.enabled = false;
        _skillChange.enabled = false;
        _magic1.enabled = false;
        //_magic2.enabled = false;
        _authortySkill.enabled = false;
    }

    public void PlayerAwake()
    {
        _playerController.enabled = true;
        _attack.enabled = true;
        _skill1.enabled = true;
        _skill2.enabled = true;
        _skillChange.enabled = true;
        _magic1.enabled = true;
        //_magic2.enabled = true;
        _authortySkill.enabled = true;
    }

}
