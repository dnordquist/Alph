using Alph.Lib;
using NUnit.Framework;

namespace Alph.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ABandNameThatLooksLikeAProperNameIsReturnedWithoutTrouble()
        {
            Artist a = new Artist("Annie Taylor");
            Assert.AreEqual("Annie Taylor", a.SortName);
        }

        [Test]
        public void BostonIsWhatItIs()
        {
            Artist a = new Artist("Boston");
            Assert.AreEqual("Boston", a.SortName);
        }

        [Test]
        public void AnArtistNameIsSortedAsYouWouldExpect()
        {
            Artist a = new Artist
            {
                ArtistName = "Mayer Hawthorne",
                FamilyName = "Hawthorne"
            };
            Assert.AreEqual("Hawthorne, Mayer", a.SortName);
        }

        [Test]
        public void WeEvenHandleTheCountyCorrectly()
        {
            Artist a = new Artist
            {
                ArtistName = "Mayer Hawthorne and the County",
                FamilyName = "Hawthorne"
            };
            Assert.AreEqual("Hawthorne, Mayer and the County", a.SortName);
        }

        [Test]
        public void ATrickyPatronymicDoesNotTrickUs()
        {
            Artist a = new Artist
            {
                ArtistName = "Hildur Guðnadóttir"
            };
            Assert.AreEqual("Hildur Guðnadóttir", a.SortName);
        }

        [Test]
        public void AnArtistWithOnlyOneNameIsSortedCorrectly()
        {
            Artist a = new Artist
            {
                ArtistName = "Prince"
            };
            Assert.AreEqual("Prince", a.SortName);
        }

        [Test]
        public void ArnaldsIsASurnamItTurnsOutSoThatIsHandledRight()
        {
            Artist a = new Artist("Ólafur Arnalds")
            {
                FamilyName = "Arnalds"
            };
            Assert.AreEqual("Arnalds, Ólafur", a.SortName);
        }

        [Test]
        public void HarryConnickJrIsSortedCorrectly()
        {
            Artist a = new Artist("Harry Connick, Jr.")
            {
                FamilyName = "Connick"
            };
            Assert.AreEqual("Connick, Harry, Jr.", a.SortName);
        }

        [Test]
        public void JeanTootsThielemans()
        {
            Artist a = new Artist("Jean 'Toots' Thielemans")
            {
                FamilyName = "Thielemans"
            };
            Assert.AreEqual("Thielemans, Jean 'Toots'", a.SortName);
        }

        [Test]
        public void DJShah()
        {
            Artist a = new Artist("DJ Shah");
            Assert.AreEqual("Shah, DJ", a.SortName);
        }

        [Test]
        public void SPCStephenPauls()
        {
            Artist a = new Artist("SPC Stephen Pauls")
            {
                FamilyName = "Pauls"
            };
            Assert.AreEqual("Pauls, SPC Stephen", a.SortName);
        }

        [Test]
        public void RebeccaStJames()
        {
            Artist a = new Artist("Rebecca St. James")
            {
                FamilyName = "St. James"
            };
            a.UtilizedAbbreviations.Add("St.", "Saint");
            Assert.AreEqual("Saint James, Rebecca", a.SortName);
        }

        [Test]
        public void FamousRapActStLunaticsWhoWeAllKnowAndLove()
        {
            Artist a = new Artist("St. Lunatics");
            a.UtilizedAbbreviations.Add("St.", "Saint");
            Assert.AreEqual("Saint Lunatics", a.SortName);
        }

        [Test]
        public void APerfectCircle()
        {
            Artist a = new Artist("A Perfect Circle");
            Assert.AreEqual("Perfect Circle, A", a.SortName);
        }

        [Test]
        public void LosLobos()
        {
            Artist a = new Artist("Los Lobos");
            Assert.AreEqual("Lobos, Los", a.SortName);
        }

        [Test]
        public void BenFoldsFive()
        {
            Artist a = new Artist("Ben Folds Five")
            {
                PersonNameInGroupName = "Ben Folds",
                FamilyName = "Folds"
            };
            Assert.AreEqual("Folds, Ben, Five", a.SortName);
        }

        [Test]
        public void TheAlanParsonsProject()
        {
            Artist a = new Artist("The Alan Parsons Project")
            {
                PersonNameInGroupName = "Alan Parsons",
                FamilyName = "Parsons"
            };
            Assert.AreEqual("Parsons, Alan, Project, The", a.SortName);
        }

        [Test]
        public void TheSensationalAlexHarveyBand()
        {
            Artist a = new Artist("The Sensational Alex Harvey Band")
            {
                PersonNameInGroupName = "Alex Harvey",
                FamilyName = "Harvey"
            };
            Assert.AreEqual("Harvey, Alex, Sensational Band, The", a.SortName);
        }

        [Test]
        public void TheJimiHendrixExperience()
        {
            Artist a = new Artist("The Jimi Hendrix Experience")
            {
                PersonNameInGroupName = "Jimi Hendrix",
                FamilyName = "Hendrix"
            };
            Assert.AreEqual("Hendrix, Jimi, Experience, The", a.SortName);
        }

        [Test]
        public void StevieRayVaughanandDoubleTrouble()
        {
            Artist a = new Artist("Stevie Ray Vaughan and Double Trouble")
            {
                PersonNameInGroupName = "Stevie Ray Vaughan",
                FamilyName = "Vaughan"
            };
            Assert.AreEqual("Vaughan, Stevie Ray and Double Trouble", a.SortName);
        }

        [Test]
        public void GloriaEstefanandtheMiamiSoundMachine()
        {
            Artist a = new Artist("Gloria Estefan and the Miami Sound Machine")
            {
                PersonNameInGroupName = "Gloria Estefan",
                FamilyName = "Estefan"
            };
            Assert.AreEqual("Estefan, Gloria and the Miami Sound Machine", a.SortName);
        }

        [Test]
        public void BillHaleyandHisComets()
        {
            Artist a = new Artist("Bill Haley & His Comets")
            {
                PersonNameInGroupName = "Bill Haley",
                FamilyName = "Haley"
            };
            Assert.AreEqual("Haley, Bill & His Comets", a.SortName);
        }

        [Test]
        public void BobMarleyandtheWailers()
        {
            Artist a = new Artist("Bob Marley and the Wailers")
            {
                PersonNameInGroupName = "Bob Marley",
                FamilyName = "Marley"
            };
            Assert.AreEqual("Marley, Bob and the Wailers", a.SortName);
        }

        [Test]
        public void Maniacs()
        {
            Artist a = new Artist("10,000 Maniacs");
            Assert.AreEqual("10,000 Maniacs", a.SortName);
        }

        [Test]
        public void TheFourFreshmen()
        {
            Artist a = new Artist("The Four Freshmen");
            Assert.AreEqual("Four Freshmen, The", a.SortName);
        }

        [Test]
        public void RenéLöwe()
        {
            Artist a = new Artist("René Löwe")
            {
                FamilyName = "Löwe"
            };
            Assert.AreEqual("Löwe, René", a.SortName);
        }
    }
}