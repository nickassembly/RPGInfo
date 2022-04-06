using Microsoft.AspNetCore.Mvc;
using RPGInfo.Web.Models;
using System.Threading.Tasks;

namespace RPGInfo.Web.Services
{
    public interface INpc
    {
        void AddNpcs([FromForm] RelatedNpc npcToAdd, RpgEntityType npcType, int id);
        void EditNpc(RelatedNpc editedNpc);
        void DeleteNpc(RelatedNpc npcToDelete);
    }
}
