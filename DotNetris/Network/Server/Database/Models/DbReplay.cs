using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetris.Network.Server.Database.Models
{
    public class DbReplay
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public ulong Score { get; set; }

        [Required]
        public byte[] RawReplay { get; set; }

        [Required]
        public byte RawDifficulty { get; set; }

        [NotMapped]
        public Difficulty Difficulty
        {
            get => (Difficulty)RawDifficulty;
            set => RawDifficulty = (byte)value;
        }

        [NotMapped]
        public Inputs[] Replay
        {
            get => RawReplay.Cast<Inputs>().ToArray();
            set => RawReplay = value.Cast<byte>().ToArray();
        }
    }
}
