using System;
using System.Collections.Generic;
using System.Text;
using static LevelUpDTO.Responses.GetSleepEntriesDTOResponse.SessionDTOResponse;

namespace LevelUpDTO.Responses
{
    public class GetSleepEntriesDTOResponse : DTOResponse
    {
        public class SessionDTOResponse
        {
            public class AppliactionDTOResponse
            {
                public string PackageName { get; set; }
                public string Version { get; set; }
                public string DetailUrl { get; set; }
                public string Name { get; set; }

                public AppliactionDTOResponse(string packageName, string version, string detailUrl, string name)
                {
                    PackageName = packageName;
                    Version = version;
                    DetailUrl = detailUrl;
                    Name = name;
                }
            }

            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public long StartTimeMillis { get; set; }
            public long EndTimeMillis { get; set; }
            public long ModifiedTimeMillis { get; set; }
            public AppliactionDTOResponse Application { get; set; }
            public string ActivityType { get; set; }
            public long ActiveTimeMillis { get; set; }
            public SessionDTOResponse(string id, string name, string description, long startTimeMillis, long endTimeMillis, long modifiedTimeMillis, AppliactionDTOResponse application, string activityType, long activeTimeMillis)
            {
                Id = id;
                Name = name;
                Description = description;
                StartTimeMillis = startTimeMillis;
                EndTimeMillis = endTimeMillis;
                ModifiedTimeMillis = modifiedTimeMillis;
                Application = application;
                ActivityType = activityType;
                ActiveTimeMillis = activeTimeMillis;
            }
        }

        public List<SessionDTOResponse> Sessions { get; set; }

        public GetSleepEntriesDTOResponse(List<SessionDTOResponse> sessions)
        {
            Sessions = sessions;
        }
    }
}
