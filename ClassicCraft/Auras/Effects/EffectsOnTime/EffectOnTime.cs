﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCraft
{
    public abstract class EffectOnTime : Effect
    {
        public int TickDelay { get; set; }

        public double NextTick { get; set; }
        public int TickDamage { get; set; }

        public EffectOnTime(Player p, Entity target, bool friendly, double baseLength, int baseStacks = 1, int tickDelay = 3)
            : base(p, target, friendly, baseLength, baseStacks)
        {
            TickDelay = tickDelay;
            NextTick = Player.Sim.CurrentTime + TickDelay;
        }

        public override void StartBuff()
        {
            base.StartBuff();

            TickDamage = GetTickDamage();
        }

        public override void CheckEffect()
        {
            if (!Ended && NextTick <= Player.Sim.CurrentTime)
            {
                ApplyTick(TickDamage);
                NextTick += TickDelay;
            }

            base.CheckEffect();
        }

        public override void Refresh()
        {
            base.Refresh();

            TickDamage = GetTickDamage();
            NextTick = Player.Sim.CurrentTime + TickDelay;
        }
        public abstract int GetTickDamage();

        public virtual void ApplyTick(int damage)
        {
            Player.Sim.RegisterEffect(new RegisteredEffect(this, damage, Player.Sim.CurrentTime));

            if(Program.logFight)
            {
                Program.Log(string.Format("{0:N2} : {1} for {2} damage", Player.Sim.CurrentTime, ToString(), damage, Player.Ressource));
            }
        }

        public override string ToString()
        {
            return "Undefined Effect on Time";
        }
    }
}
