using LevelUpClient.RequestBuilders;
using LevelUpRequests;

namespace LevelUpClient.RequestHandler
{
    internal class GetQuestCategoriesRequestHandler : RequestHandler<GetQuestCategoriesRequest>
    {
        public GetQuestCategoriesRequestHandler(string fulladdress) : base(fulladdress)
        {
        }

        public override GetQuestCategoriesRequest RequestBuilder()
        {
            return new ConsoleGetQuestCategoriesBuilder()
                .Build();
        }
    }
}