using Moq;
using Solution.Functionality;
using Xunit;
using System;
using System.Net;
using Solution;

namespace TestingApp.Test
{

    public class ComicServiceTest
    {
        
    public readonly Mock<IDataComicService> _dataComicServiceMock = new();
    

        public class Service
        {
            private readonly HttpClient _http;
            public Service(HttpClient http)
            {
                _http = http;
            }
            
            public async Task<string> CreateAsync()
            {
               var response = await _http.GetStringAsync("https://xkcd.com/1/info.0.json");
            //    if(response.StatusCode == HttpStatusCode.BadRequest)
            //    {
            //         return null; 
            //    }
               return response;
            }
        }

        [Fact]
        public async void AddIcomic_Success()
        {


            var comicService = new ComicService(_dataComicServiceMock.Object);
            var http = new HttpClient();
            var service = new Service(http);
            var resultad = await service.CreateAsync();
            List<string> Num = resultad.Split(',').ToList();

            var comic = new Icomic(Num[1].Split()[2],
                                   Num[5].Split()[2],
                                   Num[7].Split()[2]);
            var result = comicService.AddIcomic(comic);

            Assert.True(result);
            Assert.Equal("\"Barrel", comic.Title); // Comic title verification
            Assert.Equal("1", comic.Id); // Comic Id/num verification
            Assert.Equal("\"Don't", comic.alt); // Comic alt verification
            _dataComicServiceMock.Verify(x => x.SaveItemToComicService(It.IsAny<Icomic>()), Times.Once);
            
        }
    }

   
        
    
}