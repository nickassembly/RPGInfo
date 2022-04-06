using Microsoft.AspNetCore.Mvc;
using RPGInfo.Web.Models;
using System.Threading.Tasks;

namespace RPGInfo.Web.Services
{
    public interface INpc
    {
        Task<ActionResult> OnPostAddNpcs([FromForm] RelatedNpc npcToAdd, RpgEntityType npcType, int id);

    }
}
