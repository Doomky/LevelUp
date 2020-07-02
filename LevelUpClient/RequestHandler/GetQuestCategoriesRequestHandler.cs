using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    internal class GetQuestCategoriesRequestHandler : RequestHandler<GetQuestCategoriesDTORequest>
    {
        public GetQuestCategoriesRequestHandler(string fulladdress) : base(fulladdress)
        {
        }

        public override GetQuestCategoriesDTORequest RequestBuilder()
        {
            return new ConsoleGetQuestCategoriesRequestBuilder()
                .Build();
        }
    }
}