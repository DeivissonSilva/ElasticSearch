using CodeBehind.ElasticSearch.Models;
using CodeBehind.ElasticSearch.ViewModel;

namespace ElasticLogAPI.Mapper
{
    public class Mapper
    {
        public static Seglogs SeglogVMParaSeglogs(SeglogVM seglogsVM)
        {
            return new Seglogs
            {
                cod_log = seglogsVM.cod_log,
                log_usuario = seglogsVM.log_usuario,
                log_login = seglogsVM.log_login,
                log_acao = seglogsVM.log_acao,
                log_data_inicio = seglogsVM.log_data_inicio,
                log_ip = seglogsVM.log_ip,
                log_maquina = seglogsVM.log_maquina,
                log_tabela = seglogsVM.log_tabela,
                log_tabela_id = seglogsVM.log_tabela_id,
                log_objeto_mudancas = seglogsVM.log_objeto_mudancas
            };
        }
    }
}
