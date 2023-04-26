using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePersone
{
    public class Persona        //deve essere public affinché sia visibile nel progetto di test
    {
        private string nome;
        public string Cognome { get; set;}
        public int Età { get; set; }
             
       
        public string Nome {
            get {
                return nome; 
            }
            
            set {
                VerificaNome(value);
                nome = value;
            }
        }

        public Persona(string nome, string cognome, int età)
        {
            VerificaNome(nome);
            Nome = nome;
            VerificaCognome(cognome);
            Cognome = cognome;
            VerificaEtà(età);
            Età=età;
            
        } 

        private void VerificaEtà(int età)
        {
            if (età < 0)
                throw new ArgumentException("L'età è negativa");
        }

        private void VerificaNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Il nome è vuoto o nullo");
        }


        private void VerificaCognome(string cognome)
        {
            if (string.IsNullOrEmpty(cognome))
                throw new ArgumentException("Il cognome è vuoto o nullo");
        }


        public void Compleanno()
        {
            if(Età<150)
                Età++;
        }
    }
}
