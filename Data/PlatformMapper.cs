﻿using System.Data;


namespace Data
{
    internal class PlatformMapper
    {
        public PlatformDTO MapPlatform(IDataReader data) 
        {
            return new PlatformDTO
            {
                PlatformId = data.GetInt32(data.GetOrdinal("PlatformId")),
                Name = data.GetString(data.GetOrdinal("Name")),
                ParentCompany = data.GetString(data.GetOrdinal("ParentCompany")),
                Founded = data.GetDateTime(data.GetOrdinal("Founded")),
                Website = data.GetString(data.GetOrdinal("Website"))
            };
        }
    }
}
