using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MomiQuestions.Pages
{
    public class QuestionSetModel : PageModel
    {
        private static int id_counter = 0;

        public int ID_Counter
        {
            get { return id_counter++; }
        }

        public IEnumerable<SingleQuestion> Questions { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "正在答题中";
            ViewData["QuestionSet"] = "试题集";
            ViewData["Question"] = "题目";
            ViewData["Answer"] = "正确答案";
            ViewData["btnCorrect"] = "回答正确";
            ViewData["btnWrong"] = "回答错误";

            Questions = new[]
            {
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，什么是【真阳性】", 
                    "被 ATA 检测出来的恶意活动"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，什么是【假阳性】",
                    "虚惊一场，实际上没有发生的活动"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，什么是【良性真阳性】", 
                    "被 ATA 检测出来的真实的非恶意活动，比如一次穿透性测试"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，合法地对敏感群的修改不会引起 ATA 警报，对吗？",
                    "错误；修改敏感群极为罕见，每一次都会触发警报。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，侦测到对敏感群的修改。如果对象是用户账号，应该在调查时进行哪些检查？",
                    "查看该用户账号的细节；检查在添加动作前后是否存在可疑行为。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，针对对敏感群的修改活动有哪些措施？",
                    "最大化减少可疑修改敏感群的用户数量"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，采用 LDAP 简单绑定的暴力攻击发生时，所谓的【横向】和【纵向】攻击维度分别指什么？",
                    "横向：使用少数密码，对广域的用户账号进行尝试；纵向：使用广域密码，对少数的几个用户账号进行尝试"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，采用 LDAP 简单绑定的暴力攻击警报发生时，如何调查可疑行为？",
                    "1.检查失败的账号最后是否成功登录 > 如果成功，检查源电脑是否是被猜测账号的常用电脑 > 如果是，忽视可疑行为；"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，如何避免采用 LDAP 简单绑定的暴力攻击？",
                    "部署满足复杂性和长度的密码设置策略"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，什么是蜜罐账号活动？",
                    "蜜罐账号是专门用于诱惑恶意攻击者的账号。它通常有个很诱人的名字，比如“XXX-Admin”。一旦此类账号有活动，那么说明攻击者正在尝试攻击该网络"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，蜜罐账号活动时，如何确定是假阳性？",
                    "1.向源电脑所有者联系并确认是否使用了该账号；2.排除【非交互性登录】的可能性，检查有哪些应用或者脚本在该账户上运行"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，蜜罐账号活动时，如何避免是假阳性活动？",
                    "避免合法用户使用该账号"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，【身份窃取】的方式有哪三种？",
                    "Pass-the-Hash，Pass-the-Ticket，和 Kerberos 黄金票"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，【身份窃取】的 Pass-the-Ticket 攻击中，为什么出于 DHCP，VPN，Wifi，NAT 子网中的电脑会产生假阳性？",
                    "侦测 PtT 攻击手法的原理是检查是否同一张 Kerberos 票在不同的电脑上被使用，而这个原理利用的检查源电脑的 IP 地址；处于这些子网中的电脑的 IP 是动态的，所以在被改变后会引发警报。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，【身份窃取】的 Kerbros 黄金票攻击中，调查时需要检查哪两项假阳性因素？",
                    "1.近期是否进行过【用户票最大生命周期】的策略改动；2.发出警报的 ATA 网关是否是一个虚拟机，如果是，那么它是否刚刚从保存状态中苏醒？如果是，忽略此警报。"),                
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，【身份窃取】的三种攻击方式的处理各是什么？",
                    "对于 PtT 和 PtH 需要检查被攻陷的账户是否属于敏感账户。如果是一般账户，那么单独重置该账户的密码。如果属于敏感账户，那么必须要进行 KRBTGT 账户的重置；对于 Kerberos 黄金票，因为其只可能是敏感账户被攻陷后实现的，直接进行重置 KRBTGT 的操作。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的可疑活动中，为了应对【身份窃取】的三种攻击方式进行的 KRBTGT 重置需要注意哪些地方？",
                    "1.需要进行两次重置；2.重置后，域内当前存在的所有的 Kerberos 票都会失效，可能造成影响，因此必须要进行提前安排。"),
                //新的问题
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 的关键组件有哪些？",
                    "ATA 中心，ATA 网关，以及 ATA 轻量网关。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 中心的次级组件里，提供机器学习和决定性算法的组件叫什么名字？",
                    "侦测器 / Detector"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 中心的次级组件里，使用的数据库是什么数据库？",
                    "MongoDB"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "TA 中心的次级组件里，ATA 控制台在其核心服务停止时，就不能连接数据库了，这个理解正确吗？",
                    "不正确。只要可以和数据库建立连接，无论核心服务有没有运行，都可以连接数据库。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在部署 ATA 解决方案时，在什么情况下需要使用一个以上的 ATA 中心？",
                    "当部署环境所在的 AD 森林过大的时候。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "网络攻击的周期中的哪一个周期是攻击者在目标网络中扩散自己的影响力？",
                    "内网漫游阶段（Lateral Movement）"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "SIEM 的全称是什么？",
                    "安全信息与事件管理系统（Security Information and Event Management）"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "UDP 协议在 OSI 模型中属于那一层？",
                    "第四层 - 运输层 （Layer-4 Transport）"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "例举属于在 OSI 模型中第五层 Session 层中任意两种格式",
                    "NetBIOS、Network File System、Secure Shell (SSH)、SQL"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "例举在 OSI 模型中第六层 Presentation 层的作用任意两种。",
                    "（对数据流的）加密、解密、压缩、解压、翻译"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "DHCP 协议在 OSI 模型中属于那一层？",
                    "第七层 - 应用层（Layer-7 Application）"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "DDoS 攻击的全称是什么？",
                    "分布式拒绝服务攻击（Distributed Denial of Service）"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "什么是【域控制器】Domain Controller？",
                    "域控制器为在本域内登陆并认证成功的用户提供另外一个域的权限，使其可以获取另外一个域的字串的控制权。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 网关和 ATA 轻量网关相比，部署方式有什么不同？",
                    "1. 部署位置不同：网关部署在专用服务器上，轻量网关部署在域控制器（Domain Controller）上。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 网关和 ATA 轻量网关相比，部署方式有什么不同？",
                    "网关部署在专用服务器上，轻量网关部署在域控制器（Domain Controller）上。"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 网关和 ATA 轻量网关相比，域同步器选择的优先级有什么不同？",
                    "轻量网关不会被默认选择作为域同步器"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 网关和 ATA 轻量网关相比，在资源限制上有什么不同？",
                    "因为被部署在域控制器同一个服务器，为了保证控制器正常工作，轻量网关在本地的资源分配在控制器资源紧缺的情况下会被限制"),

                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 网关和 ATA 轻量网关相比，在资源限制上有什么不同？",
                    "因为被部署在域控制器同一个服务器，为了保证控制器正常工作，轻量网关在本地的资源分配在控制器资源紧缺的情况下会被限制"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 轻量网关在被限制资源的情况下，也可以正常发挥作用，对吗？",
                    "不全对。虽然可以使用，但是其监控的流量会被限制，在中心界面显示为 Dropped 警报"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "ATA 轻量网关在被限制资源的时发出的警报是什么？",
                    "在被限制资源时，轻量网关虽然可以使用，但是其监控的流量会被限制，在中心界面显示为 Dropped 警报"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的部署中，在域同步器缺失的情况下，ATA 中心就会发生错误无法使用，对吗？",
                    "错误。只是获取实体的方式由主动变为被动"),
                new SingleQuestion(
                    "Q" + ID_Counter,
                    "在 ATA 的部署中，域同步器网关的作用是什么？有同步器和没有的 ATA 部署有什么区别？",
                    "作用——【主动地】向 ATA 中心提供当前 AD 森林中的所有的实体名单。区别——在没有时，被动地记录新的实体。"),
            };
        }

    }

    public class SingleQuestion
    {
        public SingleQuestion(string id, string statement, string answer)
        {
            this.id = id;
            QuestionStatement = statement;
            Answer = answer;
            IsAnswered = false;
            IsCorrect = false;
        }
        public string id { get; set; }
        public string QuestionStatement {get; set;}
        public string Answer
        {get; set;}
        public bool IsAnswered {get; set;}
        public bool IsCorrect {get; set;}
    }
}