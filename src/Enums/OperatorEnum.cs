using R6DB_Bot.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace R6DB_Bot.Enums
{
    public enum OperatorEnum
    {
        [OperatorInformation("Iq", "https://i.imgur.com/VPIhiCi.png")]
        IQ = 0,

        [OperatorInformation("Ash", "https://i.imgur.com/yRY7qih.png")]
        ASH = 1,

        [OperatorInformation("Doc", "https://i.imgur.com/RBQQy7t.png")]
        DOC = 2,

        [OperatorInformation("Ela", "https://i.imgur.com/byl9htB.png")]
        ELA = 3,

        [OperatorInformation("Buck", "https://i.imgur.com/MdLrZh0.png")]
        BUCK = 4,

        [OperatorInformation("Echo", "https://i.imgur.com/hSt3FUF.png")]
        ECHO = 5,

        [OperatorInformation("Fuze", "https://i.imgur.com/e1Sn3Uy.png")]
        FUZE = 6,

        [OperatorInformation("Glaz", "https://i.imgur.com/cCrLZzv.png")]
        GLAZ = 7,

        [OperatorInformation("Mira", "https://i.imgur.com/xJB7ptA.png")]
        MIRA = 8,

        [OperatorInformation("Mute", "https://i.imgur.com/lPDyKrq.png")]
        MUTE = 9,

        [OperatorInformation("Rook", "https://i.imgur.com/D7k6Ryi.png")]
        ROOK = 10,

        [OperatorInformation("Ying", "https://i.imgur.com/ZJ12EE6.png")]
        YING = 11,

        [OperatorInformation("Blitz", "https://i.imgur.com/KcANWCI.png")]
        BLITZ = 12,

        [OperatorInformation("Frost", "https://i.imgur.com/SKiRW99.png")]
        FROST = 13,

        [OperatorInformation("Jager", "https://i.imgur.com/ykKyBAE.png")]
        JAGER = 14,

        [OperatorInformation("Pulse", "https://i.imgur.com/VbHDAWA.png")]
        PULSE = 15,

        [OperatorInformation("Smoke", "https://i.imgur.com/Ms5HhSV.png")]
        SMOKE = 16,

        [OperatorInformation("Vigil", "https://i.imgur.com/pI927af.png")]
        VIGIL = 17,

        [OperatorInformation("Zofia", "https://vignette.wikia.nocookie.net/rainbowsix/images/f/fb/Zofia_icon.png/revision/latest?cb=20171116042256&path-prefix=ru")]
        ZOFIA = 18,

        [OperatorInformation("Bandit", "https://i.imgur.com/20lT9YM.png")]
        BANDIT = 19,

        [OperatorInformation("Castle", "https://i.imgur.com/e9iG7QX.png")]
        CASTLE = 20,

        [OperatorInformation("Hibana", "https://i.imgur.com/JTkFhXK.png")]
        HIBANA = 21,

        [OperatorInformation("Jackal", "https://i.imgur.com/8Qj1MD9.png")]
        JACKAL = 22,

        [OperatorInformation("Kapkan", "https://i.imgur.com/v1N8f4T.png")]
        KAPKAN = 23,

        [OperatorInformation("Lesion", "https://i.imgur.com/8t4cl9l.png")]
        LESION = 24,

        [OperatorInformation("Sledge", "https://i.imgur.com/0sbuWQ2.png")]
        SLEDGE = 25,

        [OperatorInformation("Twitch", "https://i.imgur.com/FLnDryJ.png")]
        TWITCH = 26,

        [OperatorInformation("Capitao", "https://i.imgur.com/fLG4Owh.png")]
        CAPITAO = 27,

        [OperatorInformation("Caveira", "https://i.imgur.com/PCyfiwc.png")]
        CAVEIRA = 28,

        [OperatorInformation("Dokkaebi", "https://vignette.wikia.nocookie.net/rainbowsix/images/0/0c/Dokkaebi_icon.png/revision/latest?cb=20171120222956")]
        DOKKAEBI = 29,

        [OperatorInformation("Montagne", "https://i.imgur.com/hYEBm3m.png")]
        MONTAGNE = 30,

        [OperatorInformation("Recruit1", "https://i.imgur.com/qBtnIYx.png")]
        RECRUIT1 = 31,

        [OperatorInformation("Recruit2", "https://i.imgur.com/ryP1dcX.png")]
        RECRUIT2 = 32,

        [OperatorInformation("Recruit3", "https://i.imgur.com/IIGUMEF.png")]
        RECRUIT3 = 33,

        [OperatorInformation("Recruit4", "https://i.imgur.com/AJeZEDB.png")]
        RECRUIT4 = 34,

        [OperatorInformation("Recruit5", "https://i.imgur.com/kc9ExHJ.png")]
        RECRUIT5 = 35,

        [OperatorInformation("Tachanka", "https://i.imgur.com/Ab0GUHV.png")]
        TACHANKA = 36,

        [OperatorInformation("Thatcher", "https://i.imgur.com/DYb6W0F.png")]
        THATCHER = 37,

        [OperatorInformation("Thermite", "https://i.imgur.com/Xh2GFqm.png")]
        THERMITE = 38,

        [OperatorInformation("Valkyrie", "https://i.imgur.com/cIZD0NM.png")]
        VALKYRIE = 39,

        [OperatorInformation("Blackbeard", "https://i.imgur.com/tgLdEgU.png")]
        BLACKBEARD = 40
    }
}
