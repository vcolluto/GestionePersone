using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePersone.Tests
{
    [TestFixture]
    internal class GestorePersoneTests
    {
        private GestorePersone gestorePersone;



        [SetUp]
        public void Setup()     //viene eseguito prima di ogni test
        {
           
                gestorePersone = new GestorePersone();
                gestorePersone.AggiungiPersona(new Persona("Mario", "Rossi", 20));
                gestorePersone.AggiungiPersona(new Persona("Franco", "Verdi", 25));
                gestorePersone.AggiungiPersona(new Persona("Gina", "Gialli", 22));
          
        }

        //verifico che se il cognome esiste restituisca un'istanza di persona
        [Test(Description = "Verifica che se il cognome esiste restituisca un'istanza di persona")]
        [TestCase("Verdi")]
        [TestCase("Gialli")]
        [TestCase("Rossi")]
        public void CercaPerCognomeOK(string cognome) {
            Persona persona = gestorePersone.CercaPersonaPerCognome(cognome);
            Assert.IsNotNull(persona);      //il test passa se l'oggetto restituito non è nullo
        }


        //verifico che se il cognome non esiste restituisca null
        [Test]    
        public void CercaPerCognomeKO()
        {
            Persona persona = gestorePersone.CercaPersonaPerCognome("Marroni");
            Assert.IsNull(persona);      //il test passa se l'oggetto è nullo
        }

        [Test]
        [TestCase("Rossana", "Neri")]       //andrà a buon fine
        [TestCase("Pino", "Blu")]        //andrà a buon fine
        public void AggiungiPersonaOK(string nome, string cognome)
        {
            //parto da una situazione con 3 persone
            Persona persona = new Persona(nome, cognome, 32);
            gestorePersone.AggiungiPersona(persona);
            //se ha aggiunto me ne trovo 4
            Assert.That(gestorePersone.elencoPersone.Count, Is.EqualTo(4));           
        }

        [Test]
        public void AggiungiPersonaKO()
        {
            Persona persona = new Persona("Gina", "Gialli", 32);        
            gestorePersone.AggiungiPersona(persona);        //esiste già => non viene aggiunta
            Assert.That(gestorePersone.elencoPersone.Count, Is.EqualTo(3));     //il metodo funziona se non aggiunge la persona!
        }
    }
}
