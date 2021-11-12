using System;
using System.Collections;
using System.Collections.Generic;
using Jyx2;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Jyx2Configs
{
    [CreateAssetMenu(menuName = "金庸重制版/配置文件/角色", fileName = "角色ID_角色名")]
    public class Jyx2ConfigCharacter : Jyx2ConfigBase
    {
        public enum SexualType
        {
            男 = 0,
            女 = 1,
            太监 = 2,
        }

        //0:阴 1:阳 2:调和
        public enum MpTypeEnum
        {
            阴 = 0,
            阳 = 1,
            调和 = 2
        }

        private const string CGroup1 = "基本配置";
        private const string CGroup2 = "战斗属性";
        private const string CGroup3 = "装备";
        private const string CGroupSkill = "武功";
        private const string CGroupItems = "道具";
        
        [BoxGroup(CGroup1)][LabelText("性别")][EnumToggleButtons] 
        public SexualType Sexual;
        
        [BoxGroup(CGroup1)][LabelText("头像")]
        public AssetReferenceTexture2D Pic;
        
        [BoxGroup(CGroup1)][LabelText("品德")] 
        public int Pinde; //品德
        
        [BoxGroup(CGroup1)][LabelText("资质")] 
        public int IQ; //资质
        
        /* ------- 分割线 ------- */
        
        [InfoBox("必须至少有一个武功", InfoMessageType.Error, "@this.Skills==null || this.Skills.Count == 0")]
        [InfoBox("注：等级0：对应1级武功，  等级900：对应10级武功")]
        [BoxGroup(CGroupSkill)] [LabelText("武功")][SerializeReference][TableList]
        public List<Jyx2ConfigCharacterSkill> Skills;
        
        /* ------- 分割线 --------*/
        [InlineEditor]
        [BoxGroup(CGroupItems)] [LabelText("携带道具")][SerializeReference]
        public List<Jyx2ConfigCharacterItem> Items;
        
        /* ------- 分割线 --------*/

        [BoxGroup(CGroup2)][LabelText("生命上限")]
        public int MaxHp;
        
        [BoxGroup(CGroup2)][LabelText("内力上限")]
        public int MaxMp;

        [BoxGroup(CGroup2)][LabelText("生命增长")] 
        public int HpInc;
        
        [BoxGroup(CGroup2)][LabelText("开场等级")]
        public int Level;
        
        /*[BoxGroup(CGroup2)][LabelText("经验")]
        public int Exp;*/

        [BoxGroup(CGroup2)][LabelText("内力性质")][EnumToggleButtons]
        public MpTypeEnum MpType; //内力性质 ,0:阴 1:阳 2:调和
        

        [BoxGroup(CGroup2)][LabelText("攻击力")]
        public int Attack; //攻击力
        
        [BoxGroup(CGroup2)][LabelText("轻功")]
        public int Qinggong; //轻功
        
        [BoxGroup(CGroup2)][LabelText("防御力")]
        public int Defence; //防御力
        
        [BoxGroup(CGroup2)][LabelText("医疗")]
        public int Heal; //医疗
        
        [BoxGroup(CGroup2)][LabelText("用毒")]
        public int UsePoison; //用毒
        
        [BoxGroup(CGroup2)][LabelText("解毒")]
        public int DePoison; //解毒
        
        [BoxGroup(CGroup2)][LabelText("抗毒")]
        public int AntiPoison; //抗毒
        
        [BoxGroup(CGroup2)][LabelText("拳掌")]
        public int Quanzhang; //拳掌
        
        [BoxGroup(CGroup2)][LabelText("御剑")]
        public int Yujian; //御剑
        
        [BoxGroup(CGroup2)][LabelText("耍刀")]
        public int Shuadao; //耍刀
        
        [BoxGroup(CGroup2)][LabelText("特殊兵器")]
        public int Qimen;//特殊兵器
        
        [BoxGroup(CGroup2)][LabelText("暗器技巧")]
        public int Anqi; //暗器技巧
        
        [BoxGroup(CGroup2)][LabelText("武学常识")]
        public int Wuxuechangshi; //武学常识
        
        [BoxGroup(CGroup2)][LabelText("攻击带毒")]
        public int AttackPoison; //攻击带毒
        
        [BoxGroup(CGroup2)][LabelText("左右互搏")]
        public int Zuoyouhubo; //左右互搏
        
        /* ------- 分割线 --------*/
        
        [BoxGroup(CGroup3)][LabelText("武器")][SerializeReference]
        public Jyx2ConfigItem Weapon;
        
        [BoxGroup(CGroup3)][LabelText("防具")][SerializeReference]
        public Jyx2ConfigItem Armor;
        
        
        /* ------- 分割线 --------*/

        [BoxGroup("其他")][LabelText("队友离场对话")] 
        public string LeaveStoryId;

        /* ------- 分割线 --------*/
        
        [BoxGroup("模型配置")] [LabelText("模型配置")] [SerializeReference][InlineEditor]
        public ModelAsset Model;
    }

    [Serializable]
    public class Jyx2ConfigCharacterSkill
    {
        [LabelText("武功")][SerializeReference]
        public Jyx2ConfigSkill Skill;

        [LabelText("等级")] 
        public int Level;
    }
    
    [Serializable]
    public class Jyx2ConfigCharacterItem : ScriptableObject
    {
        [LabelText("道具")] 
        public Jyx2ConfigItem Skill;

        [LabelText("数量")] 
        public int Count;
    }
}

