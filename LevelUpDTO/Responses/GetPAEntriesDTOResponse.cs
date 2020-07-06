using System;
using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetPAEntriesDTOResponse : DTOResponse
    {
        public class PAEntryDTOResponse
        {
            public string Login { get; set; }
            public string Name { get; set; }
            public int? Total { get; set; }

            public PAEntryDTOResponse(string login, string name, int? total)
            {
                Login = login;
                Name = name;
                Total = total;
            }
        }

        public List<PAEntryDTOResponse> PAEntries { get; set; }

        public GetPAEntriesDTOResponse(List<PAEntryDTOResponse> pAEntries)
        {
            PAEntries = pAEntries;
        }
    }
}
