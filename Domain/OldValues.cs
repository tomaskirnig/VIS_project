using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class OldValue
    {
        public int ChangeId { get; set; }
        public DateTime ChangedDate { get; set; }
        public int GameId { get; set; }
        public string OldTitle { get; set; }
        public DateTime OldReleaseDate { get; set; }
        public decimal OldPrice { get; set; }
        public string OldPublisher { get; set; }

        public OldValue(OldValueDTO oldValueDTO)
        {
            MapOldValue(oldValueDTO);
        }

        public OldValue(int changeId)
        {
            OldValueDTO oldValue = OldValueTDG.GetById(changeId);

            if (oldValue != null)
            {
                MapOldValue(oldValue);
            }
            else
            {
                throw new ArgumentException("Old value not found");
            }
        }

        public void MapOldValue(OldValueDTO oldValueDTO)
        {
            ChangeId = oldValueDTO.ChangeId;
            ChangedDate = oldValueDTO.ChangedDate;
            GameId = oldValueDTO.GameId;
            OldTitle = oldValueDTO.OldTitle;
            OldReleaseDate = oldValueDTO.OldReleaseDate;
            OldPrice = oldValueDTO.OldPrice;
            OldPublisher = oldValueDTO.OldPublisher;
        }

        public static List<OldValue> GetAllOldValues()
        {
            List<OldValueDTO> oldValuesDTO = OldValueTDG.GetAll().ToList();

            if (oldValuesDTO != null)
            {
                return oldValuesDTO.Select(dto => new OldValue(dto)).ToList();
            }
            else
            {
                throw new ArgumentException("No old values found");
            }
        }
    }
}
