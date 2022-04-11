using Microsoft.AspNetCore.Mvc;
using RPGInfo.Web.Models;
using System.Threading.Tasks;

namespace RPGInfo.Web.Services
{
    public interface INpc
    {
        void AddNpcs([FromForm] RelatedNpc npcToAdd, string userId, RpgEntityType npcType, int id);
        void EditNpc(RelatedNpc editedNpc, string userId);
        void DeleteNpc(RelatedNpc npcToDelete);
    }
}
