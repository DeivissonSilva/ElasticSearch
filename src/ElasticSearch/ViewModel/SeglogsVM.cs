using System;

namespace CodeBehind.ElasticSearch.Models
{
    public class SeglogsVM
    {
        public int cod_log { get; set; }
        public string log_usuario { get; set; }
        public string log_login { get; set; }
        public string log_acao { get; set; }
        public DateTime log_data_inicio { get; set; }
        public string log_ip { get; set; }
        public string log_maquina { get; set; }
        public string log_tabela { get; set; }
        public int log_tabela_id { get; set; }
        public string log_objeto_mudancas { get; set; }
    }
}
