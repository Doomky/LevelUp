using LevelUpAPI.DataAccess.GoogleFit;
using LevelUpAPI.DataAccess.QuestHandlers.Interfaces;
using LevelUpAPI.DataAccess.Repositories;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.QuestHandlers
{
    public class DailySleepQuestHandler : QuestHandler
    {
        private readonly User _user;

        public DailySleepQuestHandler(User user)
        {
            _user = user;
        }

        public override IQuestHandler.QuestState GetState()
        {
            ListSessionsRequest listSessionsRequest = new ListSessionsRequest();
            listSessionsRequest.StartTime = Quest.CreationDate.ToString();
            listSessionsRequest.EndTime = Quest.ExpirationDate.ToString();
            ListSessionstResponse listSessionstResponse = GoogleFitService.ListSessions(_user, listSessionsRequest).GetAwaiter().GetResult();

            if (Quest.IsClaimed)
                return IQuestHandler.QuestState.Claimed;
            else if (listSessionstResponse.Sessions.Count >= Quest.ProgressCount)
                return IQuestHandler.QuestState.Finished;
            else if (Quest.ExpirationDate > DateTime.Now)
                return IQuestHandler.QuestState.InProgress;
            else
                return IQuestHandler.QuestState.Failed;
        }

        public override IQuestHandler.QuestState Update(UpdateQuestDTORequest updateQuestRequest)
        {
            return GetState();
        }

        public override IQuestHandler.QuestState Update(string key, string value)
        {
            return GetState();
        }
    }
}
