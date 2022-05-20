using Microsoft.AspNetCore.Mvc;
using RPGInfo.Web.Models;
using System.Linq;

namespace RPGInfo.Web.Services
{
    public class GeneralNpc : INpc
    {

        public void AddNpcs([FromForm] RelatedNpc npcToAdd, string userId, RpgEntityType npcType, int id)
        {
            RelatedNpc newNpc = new RelatedNpc();

            if (npcType == RpgEntityType.CharacterType)
            {
                newNpc.CharacterId = id;
            }
            else if (npcType == RpgEntityType.EventType)
            {
                newNpc.WorldEventId = id;
            }
            else
            {
                newNpc.AreaId = id;
            }

            newNpc.Name = npcToAdd.Name;
            newNpc.Relationship = npcToAdd.Relationship;
            newNpc.Background = npcToAdd.Background;
            newNpc.Race = npcToAdd.Race;
            newNpc.Class = npcToAdd.Class;
            newNpc.UserId = userId;

        }

        public void EditNpc(RelatedNpc editedNpc, string userId)
        {
            //var npcToEdit = _context.RelatedNpcs.Where(npc => npc.Id == editedNpc.Id).FirstOrDefault();

            //npcToEdit.Name = editedNpc.Name != null ? editedNpc.Name : npcToEdit.Name;
            //npcToEdit.Relationship = editedNpc.Relationship != null ? editedNpc.Relationship : npcToEdit.Relationship;
            //npcToEdit.Background = editedNpc.Background != null ? editedNpc.Background : npcToEdit.Background;
            //npcToEdit.Race = editedNpc.Race != null ? editedNpc.Race : npcToEdit.Race;
            //npcToEdit.Class = editedNpc.Class != null ? editedNpc.Class : npcToEdit.Class;
            //npcToEdit.UserId = userId;

            //_context.SaveChanges();
        }

        public void DeleteNpc(RelatedNpc npcToDelete)
        {
            //var npcToRemove = _context.RelatedNpcs.AsNoTracking().Where(npc => npc.Id == npcToDelete.Id).FirstOrDefault();

            //if (npcToRemove != null)
            //{
            //    _context.RelatedNpcs.Remove(npcToRemove);
            //    _context.SaveChanges();
            //}
        }
    }
}
