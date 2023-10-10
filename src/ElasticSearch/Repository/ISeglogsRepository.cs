using CodeBehind.ElasticSearch.Models;

namespace CodeBehind.ElasticSearch.Repository
{
    public interface ISeglogsRepository
    {
        bool Atualizar(Seglogs segLogs);
        bool Excluir(string id);
        System.Collections.Generic.IEnumerable<Seglogs> Listar();
        bool Persistir(Seglogs segLogs);
        Seglogs Selecionar(string id);
    }
}