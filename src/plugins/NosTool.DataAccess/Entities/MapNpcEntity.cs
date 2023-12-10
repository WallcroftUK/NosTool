using System.ComponentModel.DataAnnotations.Schema;

namespace NosTool.DataAccess.MSSQL.Entities
{
    public class MapNpcEntity
    {
        public short Dialog { get; set; }

        public short Effect { get; set; }

        public short EffectDelay { get; set; }

        public bool IsDisabled { get; set; }

        public bool IsMoving { get; set; }

        public bool IsSitting { get; set; }

        public short MapId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MapNpcId { get; set; }

        public short MapX { get; set; }

        public short MapY { get; set; }

        public string Name { get; set; }

        public short NpcVNum { get; set; }

        public byte Position { get; set; }
    }
}