using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MomiQuestions.Pages
{
    public class QuestionSetModel : PageModel
    {
        private int id_counter = 0;

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
                    "在 ATA 的可疑活动中，什么是【真阳性】", 
                    "被 ATA 检测出来的恶意活动"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，什么是【假阳性】",
                    "虚惊一场，实际上没有发生的活动"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，什么是【良性真阳性】", 
                    "被 ATA 检测出来的真实的非恶意活动，比如一次穿透性测试"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，合法地对敏感群的修改不会引起 ATA 警报，对吗？",
                    "错误；修改敏感群极为罕见，每一次都会触发警报。"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，侦测到对敏感群的修改。如果对象是用户账号，应该在调查时进行哪些检查？",
                    "查看该用户账号的细节；检查在添加动作前后是否存在可疑行为。"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，针对对敏感群的修改活动有哪些措施？",
                    "最大化减少可疑修改敏感群的用户数量"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，采用 LDAP 简单绑定的暴力攻击发生时，所谓的【横向】和【纵向】攻击维度分别指什么？",
                    "横向：使用少数密码，对广域的用户账号进行尝试；纵向：使用广域密码，对少数的几个用户账号进行尝试"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，采用 LDAP 简单绑定的暴力攻击警报发生时，如何调查可疑行为？",
                    "1.检查失败的账号最后是否成功登录 > 如果成功，检查源电脑是否是被猜测账号的常用电脑 > 如果是，忽视可疑行为；"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，如何避免采用 LDAP 简单绑定的暴力攻击？",
                    "部署满足复杂性和长度的密码设置策略"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，什么是蜜罐账号活动？",
                    "蜜罐账号是专门用于诱惑恶意攻击者的账号。它通常有个很诱人的名字，比如“XXX-Admin”。一旦此类账号有活动，那么说明攻击者正在尝试攻击该网络"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，蜜罐账号活动时，如何确定是假阳性？",
                    "1.向源电脑所有者联系并确认是否使用了该账号；2.排除【非交互性登录】的可能性，检查有哪些应用或者脚本在该账户上运行"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，蜜罐账号活动时，如何避免是假阳性活动？",
                    "避免合法用户使用该账号"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，【身份窃取】的方式有哪三种？",
                    "Pass-the-Hash，Pass-the-Ticket，和 Kerberos 黄金票"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，【身份窃取】的 Pass-the-Ticket 攻击中，为什么出于 DHCP，VPN，Wifi，NAT 子网中的电脑会产生假阳性？",
                    "侦测 PtT 攻击手法的原理是检查是否同一张 Kerberos 票在不同的电脑上被使用，而这个原理利用的检查源电脑的 IP 地址；处于这些子网中的电脑的 IP 是动态的，所以在被改变后会引发警报。"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，【身份窃取】的 Kerbros 黄金票攻击中，调查时需要检查哪两项假阳性因素？",
                    "1.近期是否进行过【用户票最大生命周期】的策略改动；2.发出警报的 ATA 网关是否是一个虚拟机，如果是，那么它是否刚刚从保存状态中苏醒？如果是，忽略此警报。"),                
                new SingleQuestion(
                    "在 ATA 的可疑活动中，【身份窃取】的三种攻击方式的处理各是什么？",
                    "对于 PtT 和 PtH 需要检查被攻陷的账户是否属于敏感账户。如果是一般账户，那么单独重置该账户的密码。如果属于敏感账户，那么必须要进行 KRBTGT 账户的重置；对于 Kerberos 黄金票，因为其只可能是敏感账户被攻陷后实现的，直接进行重置 KRBTGT 的操作。"),
                new SingleQuestion(
                    "在 ATA 的可疑活动中，为了应对【身份窃取】的三种攻击方式进行的 KRBTGT 重置需要注意哪些地方？",
                    "1.需要进行两次重置；2.重置后，域内当前存在的所有的 Kerberos 票都会失效，可能造成影响，因此必须要进行提前安排。"),
            };
        }

    }

    public class SingleQuestion
    {
        public SingleQuestion(string statement, string answer)
        {
            QuestionStatement = statement;
            Answer = answer;
            IsAnswered = false;
            IsCorrect = false;
        }
        public string QuestionStatement {get; set;}
        public string Answer
        {get; set;}
        public bool IsAnswered {get; set;}
        public bool IsCorrect {get; set;}
    }
}