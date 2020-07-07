using System;
using System.Collections.Generic;

namespace LevelUpDTO
{
    public class GetPAEntriesDTOResponse : DTOResponse
    {
        public class PAEntryDTOResponse
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int PhysicalActivitiesId { get; set; }
            public DateTime DatetimeStart { get; set; }
            public DateTime DatetimeEnd { get; set; }
            public PAEntryDTOResponse(int id, int userId, int physicalActivitiesId, DateTime datetimeStart, DateTime datetimeEnd)
            {
                Id = id;
                UserId = userId;
                PhysicalActivitiesId = physicalActivitiesId;
                DatetimeStart = datetimeStart;
                DatetimeEnd = datetimeEnd;
            }
        }

        public List<PAEntryDTOResponse> PAEntries { get; set; }

        public GetPAEntriesDTOResponse(List<PAEntryDTOResponse> pAEntries)
        {
            PAEntries = pAEntries;
        }
    }
}
