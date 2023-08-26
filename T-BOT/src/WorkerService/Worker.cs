using Application.Common.Models.SignalR;
using Application.Features.OrderEvents.Commands.Add;
using Application.Features.Orders.Commands.Add;
using Application.Features.Products.Commands.Add;
using Application.Features.SendEmail.Commands.OrderDetails;
using Application.Features.Users.Queries.GetNotifications;
using Domain.Enums;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
        int scraperCounter = 1;
        string token;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            _DataTransferHubConnection = new HubConnectionBuilder()
                .WithUrl(_dataTransferHub)
                .WithAutomaticReconnect()
                .Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // SignalR mesajlarini bekleyin
            _DataTransferHubConnection.On<int, int, string>("ReceiveDataFromBlazor", (customAmount, selectedOption, token) =>
            {
                this.customAmount=customAmount;
                selectedAmount=selectedOption;
                this.token= token;
                TBOT();

            });

            await _DataTransferHubConnection.StartAsync(stoppingToken);


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
            Console.WriteLine(token);
            var orderAddRequest = new OrderAddCommand();
            var orderEventAddRequest = new OrderEventAddCommand();
            using var httpClient = new HttpClient();
            //selectedAmount=1;

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


            var orderAddResponse = await SendHttpPostRequest<OrderAddCommand, object>(httpClient, "https://localhost:7090/api/Orders/Add", orderAddRequest, token);
            Guid orderId = orderAddRequest.Id;
            Console.Clear();
            await SendLogNotification("New order generated");

            Console.WriteLine("Chrome başlatılıyor");
            IWebDriver driver = new ChromeDriver();


            //Order event bot started olusturulup signalR'a mesaj olarak geçildi.
            orderEventAddRequest = new OrderEventAddCommand()
            {
                OrderId= orderId,
                Status=OrderStatus.BotStarted,
            };

            var orderEventAddResponse = await SendHttpPostRequest<OrderEventAddCommand, object>(httpClient, "https://localhost:7090/api/OrderEvents/Add", orderEventAddRequest, token);

            //SignalR ile verileri hub'a gönderme
            await SendLogNotification(orderEventAddRequest.Status.ToString());

            await SendLogNotification("Navigating to Google");
            driver.Navigate().GoToUrl("https://www.google.com.tr/?hl=tr");
            IWebElement searchBox = driver.FindElement(By.Name("q")); // Arama kutusunu bul
            searchBox.SendKeys(orderAddRequest.Category.ToString()); // Arama kutusuna kelimeyi yaz
            searchBox.SendKeys(Keys.Enter); // Enter tuşuna basarak aramayı yap

            IWebElement shoppingTab = driver.FindElement(By.LinkText("Alışveriş"));
            shoppingTab.Click();


            //Öge kazıma-Ürün isimleri
            orderEventAddRequest = new OrderEventAddCommand()
            {
                OrderId= orderId,
                Status=OrderStatus.CrawlingStarted,
            };

            orderEventAddResponse = await SendHttpPostRequest<OrderEventAddCommand, object>(httpClient, "https://localhost:7090/api/OrderEvents/Add", orderEventAddRequest, token);
            await SendLogNotification(orderEventAddRequest.Status.ToString());
            int index = 1; // Başlangıç indeksi
            string baseXPath = "/html/body/div[6]/div/div[4]/div[3]/div/div[3]/div[2]/div[2]/div/div";
            string nameXPath = $"{baseXPath}[{index}]/div[1]/div[2]/span/a/div/h3";
            string storeNameXPath = $"{baseXPath}[{index}]/div[1]/div[2]/div[2]/span/div[1]/div/a[1]/div[3]";
            string priceXPath = $"{baseXPath}[{index}]/div[1]/div[2]/div[2]/span/div[1]/div/a[1]/div[2]/span/span/span[1]/span";
            string pictureXPath = $"{baseXPath}[{index}]/div[1]/div[2]/div[1]/div/div/div/a/div/div/img";
            if (customAmount > 0)
            {

                while (driver.FindElements(By.XPath(nameXPath)).Count > 0)
                {

                    string productName = driver.FindElement(By.XPath(nameXPath)).Text;

                    string storeName = driver.FindElement(By.XPath(storeNameXPath)).Text;

                    string price = "";
                    Console.WriteLine($"Product Name:{productName}");
                    Console.WriteLine($"Store Name:{storeName}");

                    if (driver.FindElements(By.XPath(priceXPath)).Count > 0)
                    {
                        price=driver.FindElement(By.XPath(priceXPath)).Text;
                    }
                    else
                    {
                        price=driver.FindElement(By.XPath(priceXPath+"[1]")).Text;
                    }
                    Console.WriteLine($"Product Price:{price}");
                    string picture = driver.FindElement(By.XPath(pictureXPath)).GetAttribute("src");
                    Console.WriteLine($"Product Picture:{picture}");
                    Console.WriteLine("-----------------");
                    Console.WriteLine();

                    index++;
                    nameXPath = $"{baseXPath}[{index}]/div[1]/div[2]/span/a/div/h3";
                    storeNameXPath = $"{baseXPath}[{index}]/div[1]/div[2]/div[2]/span/div[1]/div/a[1]/div[3]";
                    priceXPath=$"{baseXPath}[{index}]/div[1]/div[2]/div[2]/span/div[1]/div/a[1]/div[2]/span/span/span[1]/span";
                    pictureXPath=$"{baseXPath}[{index}]/div[1]/div[2]/div[1]/div/div/div/a/div/div/img";

                    formattedLogDto.product_Name= productName;
                    formattedLogDto.product_StoreName= storeName;
                    formattedLogDto.product_Price= price;
                    formattedLogDto.product_imageURL= picture;

                    var productAddRequest = new ProductAddCommand()
                    {

                        OrderId =orderAddRequest.Id,
                        Name = productName,
                        StoreName = storeName,
                        Price= decimal.Parse(price.Remove(0, 1)),
                        Picture= picture,

                    };

                    var productAddResponse = await SendHttpPostRequest<ProductAddCommand, object>(httpClient, "https://localhost:7090/api/Products/Add", productAddRequest, token);
                    Console.WriteLine("Hata Kontrol Noktası 3");
                    await SendDetails(formattedLogDto);

                    if (scraperCounter==customAmount)
                        break;
                    else { scraperCounter++; }

                }

            }
            else
            {
                orderEventAddRequest = new OrderEventAddCommand()
                {
                    OrderId= orderId,
                    Status=OrderStatus.CrawlingFailed,
                };

                orderEventAddResponse = await SendHttpPostRequest<OrderEventAddCommand, object>(httpClient, "https://localhost:7090/api/OrderEvents/Add", orderEventAddRequest, token);
                await SendLogNotification(orderEventAddRequest.Status.ToString());
                driver.Dispose();
            }

            //int totalElements = index - 1; // Son indeks fazla arttığı için düzeltme yap
            //Console.WriteLine($"Toplam öğe sayısı: {totalElements}");
            driver.Dispose();
            scraperCounter=1;

            orderEventAddRequest = new OrderEventAddCommand()
            {
                OrderId= orderId,
                Status=OrderStatus.CrawlingCompleted,
            };

            orderEventAddResponse = await SendHttpPostRequest<OrderEventAddCommand, object>(httpClient, "https://localhost:7090/api/OrderEvents/Add", orderEventAddRequest, token);
            await SendLogNotification(orderEventAddRequest.Status.ToString());


            orderEventAddRequest = new OrderEventAddCommand()
            {
                OrderId= orderId,
                Status=OrderStatus.OrderCompleted,
            };

            orderEventAddResponse = await SendHttpPostRequest<OrderEventAddCommand, object>(httpClient, "https://localhost:7090/api/OrderEvents/Add", orderEventAddRequest, token);
            await SendLogNotification(orderEventAddRequest.Status.ToString());
            driver.Dispose();
            index=1;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetFromJsonAsync<GetNotificationsDto>("https://localhost:7090/api/Users/GetUserPreferences");
            bool emailNotification = response.EmailNotificationEnable;

            if (emailNotification)
            {
                var SendOrderDetailsAddCommandRequest = new SendOrderDetailsAddCommand()
                {
                    OrderId = orderId
                };

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var SendOrderDetailsAddCommandResponse = await httpClient.PostAsJsonAsync("https://localhost:7090/api/Email/OrderDetails", SendOrderDetailsAddCommandRequest);

            }



        }

        async Task<TResponse> SendHttpPostRequest<TRequest, TResponse>(HttpClient httpClient, string url, TRequest payload, string jwtToken)
        {
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // Authorization baglantisini ayarla
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

            var log = CreateLog(logMessage);


            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7090/Hubs/UserLogHub")
                .WithAutomaticReconnect()
                .Build();

            try
            {
                await hubConnection.StartAsync();
                await hubConnection.InvokeAsync("SendLogNotificationAsync", log);
            }
            finally
            {
                await hubConnection.DisposeAsync();
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
                await hubConnection.StartAsync();
                await hubConnection.InvokeAsync("OrderDetailsAsync", details);
            }
            finally
            {
                await hubConnection.DisposeAsync();
            }
        }
    }
}