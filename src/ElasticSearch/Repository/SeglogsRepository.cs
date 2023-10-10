using CodeBehind.ElasticSearch.Models;
using Nest;
using System.Collections.Generic;
using System.Linq;


namespace CodeBehind.ElasticSearch.Repository
{
    public class SeglogsRepository : ISeglogsRepository
    {
        private readonly IElasticClient _elasticClient;

        public SeglogsRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;

        }

        public bool Excluir(string id)
        {
            bool status;

            var response = _elasticClient.Delete<Seglogs>(id, d => d
            .Index(nameof(Seglogs).ToLower()));

            if (response.IsValid)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        public IEnumerable<Seglogs> Listar()
        {
            var searchResponse = _elasticClient.Search<Seglogs>(s =>  s
           .Index(nameof(Seglogs).ToLower()));

            var people = searchResponse.Documents;
            return people?.ToList();
        }

        public Seglogs Selecionar(string id)
        {
            var result = _elasticClient.Get<Seglogs>(id);
           
            return result.Source;
        }
        public bool Persistir(Seglogs segLogs)
        {
            bool status;
            

            var response = _elasticClient.IndexDocument(segLogs);

            if (response.IsValid)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        public bool Atualizar(Seglogs segLogs)
        {
            bool status;

            var response = _elasticClient.Update<Seglogs, Seglogs>(segLogs.cod_log, d => d
            .Index(nameof(Seglogs).ToLower())
            .Doc(segLogs));

            if (response.IsValid)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }
    }
}
