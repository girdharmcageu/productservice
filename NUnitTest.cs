using CoreAPI.Controllers;
using CoreAPI.Models;
using CoreAPI.Repository;
using JsonDiffPatchDotNet;

using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace NunitTestProject
{

    // https://chaitanyasuvarna.wordpress.com/2020/09/06/nunit-test-for-httpclient-moq/
    //https://copyprogramming.com/howto/c-httpclient-post-with-authorization-and-json-data
    // https://positiwise.com/blog/unit-testing-in-net-core-using-nunit
    //JsonDiffpatch.net(2.3.0)
    //coverlet.collector(3.2.0)
    //microsoft.net.test.SDK(17.6.0)
    //Moq(4.20.70)
    //NUnit(3.13.3)
    //Nunit.Analyzers(3.6.1)
    //Nunit3TestAdapter(4.4.2)

    public class NUnitTest
    {
        private Mock<IProductService> productService;
        Mock<HttpMessageHandler> httpMessageHandlerMock;
        private readonly object diffObj;

        [SetUp]
        public void Setup()
        {
            productService = new Mock<IProductService>();
        }

        [Test]

        //   [ExpectedException(typeof(System.DivideByZeroException))]
        // [TestCase(1, "Jignesh")]
        //[TestCase(2, "Rakesh")]
        //[TestCase(3, "Not Found")]


        public void GetProductList_ProductList_Nunit()
        {
            try
            {
               // int a = 0, b = 20, c = 0;
               // c = b / a;
                //var productList = GetProductsData();
                //productService.Setup(x => x.GetProductList()).Returns(productList);
                //var productController = new ProductController(productService.Object);
                //var productResult = productController.ProductList();
                // Assert.IsTrue(productList.Equals(productResult));

                var request = new
                {
                    //publisherId = "tfs",
                    //eventType = " workitem.created",
                    //resourceVersion = "1.0",
                    //consumerId = "webHooks",
                    //consumerActionId = "httpRequest",
                    publisherInputs = new
                    {
                        userid = "arnav",
                        projectId = "test123",
                    },
                    consumerInputs = new
                    {
                        path = "adaada",
                        url = "https://mydomain/api/ServiceHook/SaveWorkItem"
                    }
                };

                //var abc = JsonConvert.SerializeObject(request);

                //httpMessageHandlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                //  "SendAsync",
                //  ItExpr.IsAny<HttpRequestMessage>(),
                //  ItExpr.IsAny<CancellationToken>()
                //  ).ReturnsAsync(new HttpResponseMessage()
                //  {
                //      StatusCode = HttpStatusCode.OK,
                //      Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
                //  }).Verifiable();


                JToken expected = JToken.Parse(@"{ ""Name"": ""20181004164456"", ""objectId"": ""4ea9b00b"" }");
                JToken actual = JToken.Parse (@"{ ""Name"": ""20181004164456"", ""objectId"": ""4ea9b00"" }");


                var diffObj = new JsonDiffPatch();
                var objJson = JsonConvert.SerializeObject(expected);
                var anotherJson = JsonConvert.SerializeObject(actual);

                // var result = diffObj.Diff(objJson, anotherJson);
                var check = diffObj.Diff(objJson, anotherJson) == null ? "1" : "2";

                if (check == "1")
                {
                    Assert.Pass("Condition pass");
                }
                else
                {

                    Assert.Fail("Input and output are mismatch");

                }

            }

            catch (Exception ex)
            {
                if (ex.Message != "Input and output are mismatch")
                {
                    Assert.Fail(ex.Message);
                }
                //Assert.Contains("must be greater than or equal to zero.", ex.Message);
             
            }

        }

            //if (result == null)
            //{
            //    Assert.Pass();
            //}
            //else
            //{
            //    Assert.Fail("Input parameters are different");
            //    Assert.IsFalse(true, "Input parameters are different");
            //}
            //Assert.AreSame(objJson, anotherJson);

           // var ab = "";
            //return result == null;



        





        public List<Product> GetProductsData()
        {
            List<Product> productsData = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "IPhone",
                ProductDescription = "IPhone 12",
                ProductPrice = 55000,
                ProductStock = 10
            }
            ,
             new Product
            {
                ProductId = 2,
                ProductName = "Laptop",
                ProductDescription = "HP Pavilion",
                ProductPrice = 100000,
                ProductStock = 20
            },
             new Product
            {
                ProductId = 3,
                ProductName = "TV",
                ProductDescription = "Samsung Smart TV",
                ProductPrice = 35000,
                ProductStock = 30
            },
        };
            return productsData;
        }
    }
}
