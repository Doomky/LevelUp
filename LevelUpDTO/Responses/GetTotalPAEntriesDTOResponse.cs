using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    public class GetTotalPAEntriesDTOResponse : DTOResponse
    {
        public class PAEntryByLoginDTOResponse
        {
            public string Login { get; set; }
            public string Name { get; set; }
            public int? Total { get; set; }

            public PAEntryByLoginDTOResponse(string login, string name, int? total)
            {
                Login = login;
                Name = name;
                Total = total;
            }
        }
        
        List<PAEntryByLoginDTOResponse> PaEntries { get; set; }

        public GetTotalPAEntriesDTOResponse(List<PAEntryByLoginDTOResponse> paEntries)
        {
            this.PaEntries = paEntries;
        }
    }
}
