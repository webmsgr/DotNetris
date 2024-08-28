using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetris.Network.Server.Database.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

    public class DbReplayConfig : IEntityTypeConfiguration<DbReplay>
    {
        public void Configure(EntityTypeBuilder<DbReplay> builder)
        {
            builder
                .Property(i => i.RawReplay)
                .HasConversion(
                    c => Compression.Zip(c),
                    c => Compression.Unzip(c),
                    new ValueComparer<byte[]>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToArray()) // from https://learn.microsoft.com/en-us/ef/core/modeling/value-comparers?tabs=ef5#overriding-the-default-comparer
                );
        }
    }
}

