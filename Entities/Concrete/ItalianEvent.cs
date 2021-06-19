using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class ItalianEvent : IEntity
    {
        public int ID { get; set; }
        public string dc_Orario { get; set; }
        public string dc_Categoria { get; set; }
        public string dc_Evento { get; set; }
    }
}
