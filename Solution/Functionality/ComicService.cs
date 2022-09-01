namespace Solution.Functionality
{
    public record Icomic(string Id, string Title, string alt);
    public interface IDataComicService
    {
        bool SaveItemToComicService(Icomic? com);
        bool RemoveItemFromComicService(string? comId);
    }

    public class ComicService
    {
        private IDataComicService _dataComicService;
        
        //Constructor injection
        public ComicService(IDataComicService dataComicService)
        {
            _dataComicService = dataComicService;
        }
        //test inside
        public bool AddIcomic(Icomic? icomic)
        {
            if(icomic == null)
                return false;
            if(icomic.Id == null)
                return false;

            _dataComicService.SaveItemToComicService(icomic);
            return true;
        }
        
    }
}
