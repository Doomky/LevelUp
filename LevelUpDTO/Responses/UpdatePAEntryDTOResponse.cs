using System;

namespace LevelUpDTO
{
    public class UpdatePAEntryDTOResponse : DTOResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PhysicalActivitiesId { get; set; }
        public DateTime DatetimeStart { get; set; }
        public DateTime DatetimeEnd { get; set; }

        public UpdatePAEntryDTOResponse(
            int id,
            int userId,
            int physicalActivitiesId,
            DateTime datetimeStart,
            DateTime datetimeEnd)
        {
            Id = id;
            UserId = userId;
            PhysicalActivitiesId = physicalActivitiesId;
            DatetimeStart = datetimeStart;
            DatetimeEnd = datetimeEnd;
        }
    }
}
