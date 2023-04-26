using GestionePersone;
using System.Diagnostics;

namespace GestionePersone.Tests
{
   
    public class PersonaTests
    {
        private Persona matusa=new Persona("Matusa", "Lemme", 140);



        [SetUp]
        public void Setup()
        {
           
        }

        [Test]       
        public void CreazionePersonaOK()
        {
            Persona persona = new Persona("Mario", "Rossi", 20);          
            Assert.Pass();
        }

        [Test]
        public void CreazionePersonaKOEtàNegativa()
        {
            Assert.Throws<ArgumentException>(
                () => { Persona persona = new Persona("Mario", "Rossi", -4); }
                ); //ho verificato che sia stata generata l'eccezione
        }

        [Test]
        public void CreazionePersonaKONomeVuoto()
        {
            Assert.Throws<ArgumentException>(
                () => { Persona persona = new Persona("", "Rossi", 24); }
                ); //ho verificato che sia stata generata l'eccezione
        }

        [Test]
        [Repeat(5)]        //il test passa se passa per tutte e 25 le volte
        public void CompleannoOK()
        {
            int etaPrima = matusa.Età;
            
            matusa.Compleanno();
            Assert.That(matusa.Età, Is.EqualTo(etaPrima+1));    //dovrebbe avere un anno in più
        }
    }
}