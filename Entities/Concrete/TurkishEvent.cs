using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class TurkishEvent : IEntity
    {
        public int ID { get; set; }
        public string dc_Zaman { get; set; }
        public string dc_Kategori { get; set; }
        public string dc_Olay { get; set; }
    }
}
