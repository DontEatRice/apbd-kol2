using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kol2.Models
{
    public class RepoDbContext : DbContext
    {

        public DbSet<Album> Albums {get; set;} = null!;
        public DbSet<Musician> Musicians {get; set;} = null!;
        public DbSet<MusicianTrack> MusicianTracks {get; set;} = null!;
        public DbSet<MusicLabel> MusicLabels {get; set;} = null!;
        public DbSet<Track> Tracks {get; set;} = null!;
        public RepoDbContext(DbContextOptions options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>(e => {
                e.ToTable("Musician");
                e.HasKey(e => e.IdMusician);

                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired(true);
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired(true);
                e.Property(e => e.Nickname).HasMaxLength(20).IsRequired(false);

                e.HasData(new Musician {
                    IdMusician = 1,
                    FirstName = "Filip",
                    LastName = "Szcześniak",
                    Nickname = "Taco Hemingway"
                }, new Musician {
                    IdMusician = 2,
                    FirstName = "Malik",
                    LastName = "Montana",
                    Nickname = null
                });
            });

            modelBuilder.Entity<MusicianTrack>(e => {
                e.ToTable("Musician_Track");
                e.HasKey(e => new {e.IdMusician, e.IdTrack});

                e.HasOne(e => e.Musician).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdMusician).OnDelete(DeleteBehavior.NoAction);
                e.HasOne(e => e.Track).WithMany(e => e.MusicianTracks).HasForeignKey(e => e.IdTrack).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(new MusicianTrack {
                    IdMusician = 1,
                    IdTrack = 1
                }, new MusicianTrack {
                    IdMusician = 2,
                    IdTrack = 2
                });
            });

            modelBuilder.Entity<Album>(e => {
                e.ToTable("Album");
                e.HasKey(e => e.IdAlbum);

                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired(true);
                e.Property(e => e.PublishDate).IsRequired(true);
                e.Property(e => e.IdMusicLabel).IsRequired(true);

                e.HasOne(e => e.Label).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(new Album{
                    IdAlbum = 1,
                    AlbumName = "Marmur",
                    PublishDate = DateTime.Now,
                    IdMusicLabel = 1
                });
            });

            modelBuilder.Entity<MusicLabel>(e => {
                e.ToTable("MusicLabel");
                e.HasKey(e => e.IdMusicLabel);

                e.Property(e => e.Name).HasMaxLength(50).IsRequired(true);
                
                e.HasData(new MusicLabel {
                    IdMusicLabel = 1,
                    Name = "Katolicka wytwórnia muzyki"
                });
            });

            modelBuilder.Entity<Track>(e => {
                e.ToTable("Track");
                e.HasKey(e => e.IdTrack);

                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired(true);
                e.Property(e => e.Duration).IsRequired(true);
                e.Property(e => e.IdMusicAlbum).IsRequired(false);

                e.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(new Track {
                    Duration = 6750,
                    IdMusicAlbum = 1,
                    IdTrack = 1,
                    TrackName = "Deszcz na betonie",
                }, new Track {
                    Duration = 325,
                    IdMusicAlbum = null,
                    IdTrack = 2,
                    TrackName = "Wszystko dla rodziny",
                });
            });
        }
    }
}