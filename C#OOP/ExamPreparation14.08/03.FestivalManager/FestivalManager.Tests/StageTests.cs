// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void PerformerConstructor()
        {
            Performer performer = new Performer("Oleg", "Anokhin", 18);
            Assert.AreEqual("Oleg Anokhin", performer.FullName);
            Assert.AreEqual(18, performer.Age);
            Assert.AreEqual(0, performer.SongList.Count);
        }
        [Test]
        public void AddPerformerSmaller18()
        {
            Stage stage = new Stage();
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(new Performer("Oleg", "Anokhin", 15));
            });
        }
        [Test]
        public void AddPerformerCountShouldWorkCorrect()
        {
            Stage stage = new Stage();
            stage.AddPerformer(new Performer("Oleg", "Anokhin", 18));
            Assert.AreEqual(1, stage.Performers.Count);
        }
        [Test]
        public void AddSong()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Oleg", "Anokhin", 18);
            Song song = new Song("Bla bla", new TimeSpan(0, 0, 2, 22));
            stage.AddPerformer(performer);
            stage.AddSong(song);
            performer.SongList.Add(song);
            var expected = $"Bla bla (02:22) will be performed by Oleg Anokhin";
            var actual = stage.AddSongToPerformer("Bla bla", "Oleg Anokhin");
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void PlayMethodShouldWorkCorect()
        {
            Stage stage = new Stage();
            Performer performer1 = new Performer("Oleg", "Anokhin", 18);
            Performer performer2 = new Performer("Pesho", "Peshow", 38);
            Song song1 = new Song("Bla bla", new TimeSpan(0, 0, 3, 59));
            Song song2 = new Song("Bo bo", new TimeSpan(0, 0, 3, 15));
            Song song3 = new Song("Ha ha", new TimeSpan(0, 0, 4, 3));
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddSong(song1);
            stage.AddSong(song2);
            stage.AddSong(song3);
            performer1.SongList.Add(song3);
            performer2.SongList.Add(song1);
            performer2.SongList.Add(song2);
            string actual = stage.Play();
            Assert.AreEqual($"2 performers played 3 songs", actual);
        }
        [Test]
        public void PlayMethodShouldTrowExceptionWhenNonExistPerformer()
        {
            Stage stage = new Stage();
            Performer performer1 = new Performer("Oleg", "Anokhin", 18);
            Song song1 = new Song("Bla bla", new TimeSpan(0, 0, 3, 59));
            stage.AddPerformer(performer1);
            stage.AddSong(song1);
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer("Bla bla", "Pesho Peshow");
            });
        }
        [Test]
        public void PlayMethodShouldTrowExceptionWhenNonExistSong()
        {
            Stage stage = new Stage();
            Performer performer1 = new Performer("Oleg", "Anokhin", 18);
            Song song1 = new Song("Bla bla", new TimeSpan(0, 0, 3, 59));
            stage.AddPerformer(performer1);
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer("Bla bla", "Oleg Anokhin");
            });
        }
        [Test]
        public void ValidateNullValueShouldThrowException()
        {
            Stage stage = new Stage();
            Performer performer = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(performer);
            });
        }
    }
}