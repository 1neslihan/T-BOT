using Application.Common.Models.SignalR;
using Application.Features.Orders.Commands.Add;
using Domain.Enums;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.Http.Headers;
using System.Text;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _dataTransferHub = "https://localhost:7090/Hubs/DataTransferHub";
        private readonly HubConnection _DataTransferHubConnection;
        public FormattedLogDto formattedLogDto = new FormattedLogDto();

        int customAmount;
        int selectedAmount;
        int requestedAmount;
        string token;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            //_DataTransferHubConnection = new HubConnectionBuilder()
            //    .WithUrl(_dataTransferHub)
            //    .WithAutomaticReconnect()
            //    .Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //    // SignalR mesajlarýný bekleyin
            //    _DataTransferHubConnection.On<int, int, string>("ReceiveDataFromBlazor", (customAmount, selectedOption, token) =>
            //    {
            //        this.customAmount=customAmount;
            //        selectedAmount=selectedOption;
            //        this.token= token;
            //        TBOT();

            //    });

            //    await _DataTransferHubConnection.StartAsync(stoppingToken);
            TBOT();

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        async Task TBOT()
        {
            //Veri Geldi
            Console.WriteLine("BOT BAŞLADI");
            var orderAddRequest = new OrderAddCommand();
            using var httpClient = new HttpClient();
            selectedAmount=0;

            //Order Oluşturuluyor

            if (selectedAmount == 0)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Kadin_Pantolon
                };

            }

            if (selectedAmount == 1)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Erkek_Pantolon
                };
            }

            if (selectedAmount == 2)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Kadin_Gomlek
                };
            }

            if (selectedAmount == 3)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Erkek_Gomlek
                };
            }

            if (selectedAmount == 4)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Kadin_Sort
                };
            }

            if (selectedAmount == 5)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Erkek_Sort
                };
            }

            if (selectedAmount == 6)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Kadin_Etek
                };
            }

            if (selectedAmount == 7)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Erkek_Kravat
                };
            }

            if (selectedAmount == 8)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Kadin_Ceket
                };
            }

            if (selectedAmount == 9)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Erkek_Ceket
                };
            }

            if (selectedAmount == 10)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Kadin_Pijama
                };
            }

            if (selectedAmount == 11)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Erkek_Pijama
                };
            }

            if (selectedAmount == 12)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Kadin_Ayakkabi
                };
            }

            if (selectedAmount == 13)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Erkek_Ayakkabi
                };
            }

            if (selectedAmount == 14)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Kadin_Canta
                };
            }

            if (selectedAmount == 15)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Erkek_Canta
                };
            }

            if (selectedAmount == 16)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Bilgisayar
                };
            }

            if (selectedAmount == 17)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Telefon
                };
            }

            if (selectedAmount == 18)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Televizyon
                };
            }

            if (selectedAmount == 19)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Agiz_Bakimi
                };
            }

            if (selectedAmount == 20)
            {
                orderAddRequest = new OrderAddCommand()
                {
                    Id=Guid.NewGuid(),
                    RequestedAmount=this.customAmount,
                    Category=Categories.Vucut_Bakimi
                };
            }


            //var orderAddResponse = await SendHttpPostRequest<OrderAddCommand, object>(httpClient, "https://localhost:7090/api/Orders/Add", orderAddRequest, token);
            //Guid orderId = orderAddRequest.Id;
            //await SendLogNotification("New order generated");

            Console.WriteLine("Chrome başlatılıyor");
            IWebDriver driver = new ChromeDriver();
            Console.Clear();

            //Order event bot started oluþturulup signalR'a mesaj olarak geçildi.
            //var orderEventAddRequest = new OrderEventAddCommand()
            //{
            //    OrderId= orderId,
            //    Status=OrderStatus.BotStarted,
            //};

            //var orderEventAddResponse = await SendHttpPostRequest<OrderEventAddCommand, object>(httpClient, "https://localhost:7090/api/OrderEvents/Add", orderEventAddRequest, token);

            //SignalR ile verileri hub'a gönderme
            //await SendLogNotification(orderEventAddRequest.Status.ToString());

            driver.Navigate().GoToUrl("https://www.google.com.tr/?hl=tr");
            IWebElement searchBox = driver.FindElement(By.Name("q")); // Arama kutusunu bul
            searchBox.SendKeys(orderAddRequest.Category.ToString()); // Arama kutusuna kelimeyi yaz
            searchBox.SendKeys(Keys.Enter); // Enter tuşuna basarak aramayı yap

            IWebElement shoppingTab = driver.FindElement(By.LinkText("Alışveriş"));
            shoppingTab.Click();




        }

        async Task<TResponse> SendHttpPostRequest<TRequest, TResponse>(HttpClient httpClient, string url, TRequest payload, string jwtToken)
        {
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // Authorization baþlýðýný ayarla
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);


            var response = await httpClient.PostAsync(url, httpContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
            //Console.WriteLine($"Response: {responseObject}");

            return responseObject;
        }

        UserLogDto CreateLog(string message) => new UserLogDto(message);

        async Task SendLogNotification(string logMessage)
        {
            // 'CreateLog' metodu burada kullanýlarak bir günlük oluþturulabilir
            var log = CreateLog(logMessage);

            // HubConnection oluþturulmalý ve baþlatýlmalý
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7090/Hubs/UserLogHub") // Hub URL'sini burada belirtmelisiniz
                .WithAutomaticReconnect()
                .Build();

            try
            {
                await hubConnection.StartAsync(); // HubConnection'ý baþlatma
                await hubConnection.InvokeAsync("SendLogNotificationAsync", log); // Metodu çaðýrma
            }
            finally
            {
                await hubConnection.DisposeAsync(); // HubConnection'ý kapatma ve kaynaklarý temizleme
            }
        }

        async Task SendDetails(FormattedLogDto details)
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7090/Hubs/UserLogHub") // Hub URL'sini burada belirtmelisiniz
                .WithAutomaticReconnect()
                .Build();

            try
            {
                await hubConnection.StartAsync(); // HubConnection'ý baþlatma
                await hubConnection.InvokeAsync("OrderDetailsAsync", details); // Metodu çaðýrma
            }
            finally
            {
                await hubConnection.DisposeAsync(); // HubConnection'ý kapatma ve kaynaklarý temizleme
            }
        }
    }
}