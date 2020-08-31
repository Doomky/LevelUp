using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetTotalPAEntriesDTOResponse : DTOResponse
    {
        public class PAEntryByLoginDTOResponse
        {
            public string Login { get; set; }
            public string Name { get; set; }
            public int? Total { get; set; }

            public PAEntryByLoginDTOResponse()
            {

            }

            public PAEntryByLoginDTOResponse(string login, string name, int? total)
            {
                Login = login;
                Name = name;
                Total = total;
            }
        }
        
        public List<PAEntryByLoginDTOResponse> PaEntries { get; set; }

        public GetTotalPAEntriesDTOResponse()
        {

        }

        public GetTotalPAEntriesDTOResponse(List<PAEntryByLoginDTOResponse> paEntries)
        {
            PaEntries = paEntries;
        }
    }
}
