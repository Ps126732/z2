using System;
using NUnit.Framework;


namespace z2.Tests
{
    [TestFixture]

    public class PhoneTests
    {
        [Test]
        public void Constructor_PoprawneDane_TworzyObiekt()
        {
            string wlasciciel = "Jan Kowalski";
            string numer = "123456789";


            var telefon = new Phone(wlasciciel, numer);


            Assert.That(telefon.Owner, Is.EqualTo(wlasciciel));
            Assert.That(telefon.PhoneNumber, Is.EqualTo(numer));
            Assert.That(telefon.Count, Is.EqualTo(0));
            Assert.That(telefon.PhoneBookCapacity, Is.EqualTo(100));
        }

        [Test]
        public void Constructor_RzucaWyjatek()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "123456789"));
            Assert.Throws<ArgumentException>(() => new Phone("", "123456789"));
            Assert.Throws<ArgumentException>(() => new Phone("Jan Kowalski", null));
            Assert.Throws<ArgumentException>(() => new Phone("Jan Kowalski", ""));
            Assert.Throws<ArgumentException>(() => new Phone("Jan Kowalski", "12345"));
            Assert.Throws<ArgumentException>(() => new Phone("Jan Kowalski", "1234567890"));
            Assert.Throws<ArgumentException>(() => new Phone("Jan Kowalski", "12345678a"));
        }

        [Test]
        public void AddContact_PojemnoscMaksymalna_RzucaWyjatek()
        {
            var telefon = new Phone("Jan", "123456789");


            for (int i = 0; i < 100; i++)
            {
                telefon.AddContact("Osoba" + i, "111222333");
            }
        }


        [Test]
        public void AddContact_NowyKontakt_DodajePrawidlowo()
        {
            var telefon = new Phone("Jan", "123456789");
            bool wynik = telefon.AddContact("Anna", "987654321");

            Assert.That(wynik, Is.True);
            Assert.That(telefon.Count, Is.EqualTo(1));
        }





        [Test]
        public void AddContact_IstniejacyKontakt_ZwracaFalse()
        {
            var telefon = new Phone("Jan", "123456789");
            telefon.AddContact("Anna", "987654321");

            // Próba dodania drugiego kontaktu o tym samym imieniu
            bool wynik = telefon.AddContact("Anna", "111222333");

            Assert.That(wynik, Is.False);
            Assert.That(telefon.Count, Is.EqualTo(1)); // Ilość nie powinna wzrosnąć
        }

        [Test]
        public void Call_IstniejacyKontakt_ZwracaKomunikat()
        {
            var telefon = new Phone("Jan", "123456789");
            telefon.AddContact("Anna", "987654321");

            string wynik = telefon.Call("Anna");

            Assert.That(wynik, Is.EqualTo("Calling 987654321 (Anna) ..."));
        }

        [Test]
        public void Call_BrakKontaktu_ZglaszaWyjatek()
        {
            var telefon = new Phone("Jan", "123456789");

            Assert.Throws<InvalidOperationException>(() => telefon.Call("KtosKogoNieMa"));




        }
    }

}





