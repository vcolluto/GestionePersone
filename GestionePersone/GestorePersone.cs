using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePersone
{
    public class GestorePersone
    {
        public List<Persona> elencoPersone { get;  }    

        public GestorePersone()
        {
            elencoPersone= new List<Persona>(); 
        }


        //la persona viene aggiunta se non ne esiste già una con quel nome e con quel cognome
        public void AggiungiPersona(Persona persona)
        {
            if (CercaPersonaPerCognomeENome(persona.Cognome, persona.Nome)==null)
                elencoPersone.Add(persona);
        }

        //se il cognome esiste restituisce l'oggetto persona con quel cognome   (test1)
        //se il cognome non esiste restituisce null                             (test2)
        public Persona CercaPersonaPerCognome(string cognome) {           
            //foreach(Persona person in elencoPersone)
            //    if (person.Cognome == cognome)
            //    {
            //        return person;
            //    }

            //Versione 2
            for(int i = 0; i < elencoPersone.Count;i++)
            {
                if (elencoPersone[i].Cognome == cognome)
                {
                    return elencoPersone[i];
                }
            }
            return null;
        }


        public Persona CercaPersonaPerCognomeENome(string cognome,string nome)
        {
            foreach (Persona person in elencoPersone)
                if (person.Cognome == cognome && person.Nome == nome)
                {
                    return person;
                }

            return null;
        }

    }
}
