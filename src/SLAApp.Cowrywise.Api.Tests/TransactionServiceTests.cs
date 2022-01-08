using SLACowryWise.Domain;
using SLACowryWise.Domain.Abstractions;
using System.Threading.Tasks;
using Xunit;

namespace SLAApp.Cowrywise.Api.Tests
{
    public class TransactionServiceTests
    {
        private ITransactionService _service;
        private IHttpService _httpService;


        public TransactionServiceTests()
        {
            //BootstrapTest();
        }

        [Fact]
        public async Task GetAllTransfersReturnsGetTransactionsPaginatedResponse()
        {
            var result = await _service.GetAllWithdrawals(new GetPaginatedResponseInputModel()).ConfigureAwait(false);
            Assert.NotNull(result.Data);
        }

        //private void BootstrapTest()
        //{
        //    var config = new SLACowryWise.Domain.Configuration.AuthenticationConfiguration
        //    {
        //        ClientId = "CWRY-QMjMdkxOr1R5sXD2EvmJUPt03KhKURDsPMbM5i5k",
        //        ClientSecret = "CWRY-SECRET-1UZJLwy726yjrw0b66kVudkAr7u5xOReWmBRMvdLivgt4xvBI2FmBlK7qPXApWImyqgS7gMXlyzqBfnzjnZWeqqnfMxoeduXKQHjY1KrDAf8DiOiYbJIf7cFe1OT9sHZ",
        //        EndPointBaseUrl = "https://sandbox.embed.cowrywise.com",
        //        TokenEndPoint = "/o/token/",
        //        ApiVersion = "v1",
        //        GrantType = "client_credentials"
        //    };

        //    var options = Options.Create<SLACowryWise.Domain.Configuration.AuthenticationConfiguration>(config);
        //    var client = new RestClient("https://sandbox.embed.cowrywise.com");
        //    SLACowryWise.Domain.Abstractions.IAuthenticationService auth = new SLACowryWise.Domain.Services.AuthenticationService(new HttpClient(), options);
        //    var restClient = new RestClient("https://sandbox.embed.cowrywise.com");
        //    _httpService = new HttpService(auth, restClient);
        //    _service = new TransactionsService(_httpService);
        //}
    }
}
