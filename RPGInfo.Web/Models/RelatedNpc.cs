namespace RPGInfo.Web.Models
{
    public class RelatedNpc : BaseEntity
    {
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string Background { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }

        public int? AreaId { get; set; }
        public int? WorldEventId { get; set; }
        public int? CharacterId { get; set; }
        public string UserId { get; set; }
    }

}
