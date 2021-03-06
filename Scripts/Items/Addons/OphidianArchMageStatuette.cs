using System;

namespace Server.Items
{
    public class OphidianArchMageStatuette : BaseStatuette
    {
        private static readonly int[] m_Sounds = new int[]
        {
            0x280, 0x281, 0x282, 0x283, 0x284
        };
        [Constructable]
        public OphidianArchMageStatuette()
            : base(0x25A9)
        {
            this.Name = "Ophidian Arch Mage";
            this.Weight = 5.0;
        }

        public OphidianArchMageStatuette(Serial serial)
            : base(serial)
        {
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (this.TurnedOn && this.IsLockedDown && (!m.Hidden || m.IsPlayer()) && Utility.InRange(m.Location, this.Location, 2) && !Utility.InRange(oldLocation, this.Location, 2))
                Effects.PlaySound(this.Location, this.Map, m_Sounds[Utility.Random(m_Sounds.Length)]);

            base.OnMovement(m, oldLocation);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (this.ItemID == 0x25AB)
                this.ItemID = 0x25A9;
        }
    }
}