using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Platform
    {
        public int PlatformId { get; set; }
        public string Name { get; set; }
        public string ParentCompany { get; set; }
        public DateTime Founded { get; set; }
        public string Website { get; set; }

        public Platform(PlatformDTO platformDTO)
        {
            MapPlatform(platformDTO);
        }

        public Platform(int platformId)
        {
            PlatformDTO platform = PlatformTDG.GetById(platformId);

            if (platform != null)
            {
                MapPlatform(platform);
            }
            else
            {
                throw new ArgumentException("Platform not found");
            }
        }

        public void MapPlatform(PlatformDTO platformDTO)
        {
            PlatformId = platformDTO.PlatformId;
            Name = platformDTO.Name;
            ParentCompany = platformDTO.ParentCompany;
            Founded = platformDTO.Founded;
            Website = platformDTO.Website;
        }

        public void Update()
        {
            PlatformDTO platform = new PlatformDTO
            {
                PlatformId = PlatformId,
                Name = Name,
                ParentCompany = ParentCompany,
                Founded = Founded,
                Website = Website
            };

            PlatformTDG.Update(platform);
        }

        public static List<Platform> GetAllPlatforms()
        {
            List<PlatformDTO> platformsDTO = PlatformTDG.GetAll().ToList();

            if (platformsDTO != null)
            {
                return platformsDTO.Select(dto => new Platform(dto)).ToList();
            }
            else
            {
                throw new ArgumentException("No platforms found");
            }
        }
    }
}
