using FixMath;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRender : RenderObject
{
    private HeroLogic mHeroLogic;

    private Vector3 inputDir;

    /// <summary>
    /// 角色动画
    /// </summary>
    private Animation mAnima;


    public override void OnCreate()
    {
        base.OnCreate();
        mHeroLogic = logicObject as HeroLogic;
        JoystickUGUI.OnMoveCallBack += OnJoyStickMove;
        mAnima = transform.GetComponent<Animation>();
    }


    public override void OnRelease()
    {
        base.OnRelease();
        JoystickUGUI.OnMoveCallBack -= OnJoyStickMove;
    }


    /// <summary>
    /// 遥感移动输入
    /// </summary>
    /// <param name="inputDir"></param>
    private void OnJoyStickMove(Vector3 inputDir) 
    {
        this.inputDir = inputDir;
        FixIntVector3 logicDir = FixIntVector3.zero;

        if(inputDir != Vector3.zero)
        {
            logicDir.x = inputDir.x;
            logicDir.y = inputDir.y;
            logicDir.z = inputDir.z;
        }
        //向英雄逻辑层直接输入操作帧事件  没有服务端的测试代码  应该是将操作发给服务端，服务端再把帧分发给所有客户端
        mHeroLogic.InputLogicFrameEvent(logicDir);
    }

    protected override void Update()
    {
        base.Update();

        if(mHeroLogic.releaseSkillList.Count == 0)
        {
            //判断输入值 有值就播放奔跑动画 没有值就播放 Idle 动画
            if (inputDir == Vector3.zero)
            {
                PlayAnima("Anim_Idle02");
            }
            else
            {
                PlayAnima("Anim_Run");
            }
        }
        else
        {

        }

      
    }



    public void PlayAnima(string animaName)
    {
        mAnima.CrossFade(animaName,0.2f);
    }

    /// <summary>
    /// 通过动画文件播放动画
    /// </summary>
    /// <param name="clip"></param>
    public override void PlayAnim(AnimationClip clip)
    {
        base.PlayAnim(clip);

        if(mAnima.GetClip(clip.name) == null)
        {
            mAnima.AddClip(clip, clip.name);
        }
        mAnima.clip = clip;
        mAnima.Play(clip.name);
    }


}
