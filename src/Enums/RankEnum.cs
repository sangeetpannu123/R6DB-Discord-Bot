using R6DB_Bot.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace R6DB_Bot.Enums
{
    public enum RankEnum
    { 
        [RankInformation("Unranked", "https://archive.fo/kEsQO/92bb4b744dec75edae67420869e1154e1d7fe157.png", 3699)]
        Unranked = 0,

        [RankInformation("Copper 4", "https://i.imgur.com/deTjm7V.png", 1399)]
        Copper4 = 1,

        [RankInformation("Copper 3", "https://i.imgur.com/zx5KbBO.png", 1499)]
        Copper3 = 2,

        [RankInformation("Copper 2", "https://i.imgur.com/RTCvQDV.png", 1599)]
        Copper2 = 3,

        [RankInformation("Copper Star", "https://i.imgur.com/SN55IoP.png", 1699)]
        Copper1 = 4,

        [RankInformation("Bronze 4", "https://i.imgur.com/DmfZeRP.png", 1799)]
        Bronze4 = 5,

        [RankInformation("Bronze 3", "https://i.imgur.com/QOuIDW4.png", 1899)]
        Bronze3 = 6,

        [RankInformation("Bronze 2", "https://i.imgur.com/ry1KwLe.png", 1999)]
        Bronze2 = 7,

        [RankInformation("Bronze Star", "https://i.imgur.com/64eQSbG.png", 2099)]
        Bronze1 = 8,

        [RankInformation("Silver 4", "https://i.imgur.com/fOmokW9.png", 2199)]
        Silver4 = 9,

        [RankInformation("Silver 3", "https://i.imgur.com/e84XmHl.png", 2299)]
        Silver3 = 10,

        [RankInformation("Silver 2", "https://i.imgur.com/f68iB99.png", 2399)]
        Silver2 = 11,

        [RankInformation("Silver Star", "https://i.imgur.com/iQGr0yz.png",2499)]
        Silver1 = 12,

        [RankInformation("Gold 4", "https://i.imgur.com/DelhMBP.png",2699)]
        Gold4 = 13,

        [RankInformation("Gold 3", "https://i.imgur.com/5fYa6cM.png",2899)]
        Gold3 = 14,
        
        [RankInformation("Gold 2", "https://i.imgur.com/7c4dBTz.png", 3099)]
        Gold2 = 15,

        [RankInformation("Gold Star", "https://i.imgur.com/cOFgDW5.png", 3299)]
        Gold1 = 16,

        [RankInformation("Platinum 3", "https://i.imgur.com/to1cRGC.png", 3699)]
        Platinum3 = 17,

        [RankInformation("Platinum 2", "https://i.imgur.com/vcIEaEz.png", 4099)]
        Platinum2 = 18,

        [RankInformation("Platinum Star", "https://i.imgur.com/HAU5DLj.png", 4499)]
        Platinum1 = 19,

        [RankInformation("Diamond", "https://i.imgur.com/Rt6c2om.png", 9999)]
        Diamond = 20
    }
}
