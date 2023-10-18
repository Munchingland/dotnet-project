using Microsoft.AspNetCore.Mvc;

namespace Pri.GameLibrary.Web.ViewModels
{
    public class GamesUpdateViewModel:GamesAddViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
    }
}
