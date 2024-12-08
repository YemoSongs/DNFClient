using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//LogicActorSkill
public partial class LogicActor
{

    /// <summary>
    /// 技能系统
    /// </summary>
    private SkillSystem mSkillSystem;


    /// <summary>
    /// 普通攻击技能id数组
    /// </summary>
    private int[] mNormalSkillidArr = new int[] { 1001,};


    public List<Skill> releaseSkillList = new List<Skill>();

    /// <summary>
    /// 初始化技能系统
    /// </summary>
    public virtual void InitActorSkill()
    {
        mSkillSystem = new SkillSystem(this);
        mSkillSystem.InitSkills(mNormalSkillidArr);
    }

    /// <summary>
    /// 释放技能
    /// </summary>
    /// <param name="skillid"></param>
    public virtual void ReleaseSkill(int skillid)
    {
        Skill skill = mSkillSystem.ReleaseSkill(skillid, OnSkillReleaseAfter, OnSkillReleaseEnd);
        if(skill != null)
        {
            releaseSkillList.Add(skill);
        }
    }

    /// <summary>
    /// 释放技能后摇
    /// </summary>
    /// <param name="skill"></param>
    public virtual void OnSkillReleaseAfter(Skill skill)
    {
        //Debug.Log("释放技能后");
    }

    /// <summary>
    /// 释放技能结束
    /// </summary>
    /// <param name="skill"></param>
    public virtual void OnSkillReleaseEnd(Skill skill)
    {
        //Debug.Log("释放技能结束");
        releaseSkillList.Remove(skill);
    }




    /// <summary>
    /// 逻辑帧更新技能接口
    /// </summary>
    public virtual void OnLogicFrameUpdateSkill()
    {
        mSkillSystem.OnLogicFrameUpdate();
    }

}
