using Microsoft.Extensions.Configuration;
using Prueba.Domain;
using Prueba.Domain.Interfaces.Helper;
using Prueba.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Prueba.Application
{
    public class CardService
    {
        
        public CardService(IGenericRepository<Card> repository, IConfiguration configuration)
        {
            Repository = repository;
            config = configuration;

        }
        public IConfiguration config { get; set; }
        public IFileProcesorConfiguration FileProcesorConfiguration { get; }
        public IGenericRepository<Card> Repository { get; }



        public void Create(string name, string pan, string pin)
        {
            Repository.Insert(new Card(name, pan, pin));
            Repository.Save();
        }

        public void Update(Card card) {
            Repository.Update(card);
            Repository.Save();
        }            
               
        

        public Card GetById(Guid id)
        {
            return Repository.GetByID(id);
        }

        public IEnumerable<Card> ListCards()
        {            
            return Repository.Get();            
        }


        public string CsvEncriptedFile()
        {
            FileProcesorConfiguration fpc = new FileProcesorConfiguration();

            fpc.InitVector = config.GetValue<string>("FileProcesor:InitVector");            
            fpc.Keysize = config.GetValue<int>("FileProcesor:Keysize");            
            fpc.PassPhrase = Encoding.ASCII.GetBytes(config.GetValue<string>("FileProcesor:PassPhrase"));            
            fpc.SeparadorCsv = config.GetValue<char>("FileProcesor:SeparadorCsv");
            
            FileProcesor fp = new FileProcesor(fpc);

            string csv = fp.GetCsv(Repository.Get());

            return csv; 
        }

        
    }
}
