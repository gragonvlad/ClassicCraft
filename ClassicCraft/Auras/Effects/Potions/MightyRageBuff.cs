﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCraft
{
    class MightyRageBuff : Effect
    {
        public static int LENGTH = 20;

        public MightyRageBuff(Player p, double baseLength = 20)
            : base(p, p, true, baseLength, 1)
        {
        }

        public override void StartBuff()
        {
            base.StartBuff();

            Player.Ressource += Player.Sim.random.Next(45, 347);
            Player.BonusAttributes.SetValue(Attribute.Strength, Player.BonusAttributes.GetValue(Attribute.Strength) + 60);
            Player.BonusAttributes.SetValue(Attribute.AP, Player.BonusAttributes.GetValue(Attribute.AP) + 120);
        }

        public override void EndBuff()
        {
            base.EndBuff();

            Player.BonusAttributes.SetValue(Attribute.Strength, Player.BonusAttributes.GetValue(Attribute.Strength) - 60);
            Player.BonusAttributes.SetValue(Attribute.AP, Player.BonusAttributes.GetValue(Attribute.AP) - 120);
        }

        public override string ToString()
        {
            return "Mighty Rage Buff";
        }
    }
}
