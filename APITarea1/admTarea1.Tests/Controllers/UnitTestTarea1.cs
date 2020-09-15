using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APITarea1.Controllers;
using APITarea1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace admTarea1.Tests.Controllers
{
    [TestClass]
    public class UnitTestTarea1
    {
        [TestMethod]
        public void TestGetTarea1()
        {
            //Arrange
            Tarea1Controller tarea1Controller = new Tarea1Controller();

            //Act
            var ListaTraea1 = tarea1Controller.GetTarea1();

            //Assert
            Assert.IsNotNull(ListaTraea1);
        }

        [TestMethod]
        public void TestPostTarea1()
        {
            //Arrange
            Tarea1Controller tarea1Controller = new Tarea1Controller();
            Tarea1 PruebaEsperada = new Tarea1()
            {
                FrinedofZambrana = "Maely Zambrana",
                ZambranaID = 1,
                Email = "maelysael@gmail.com",
                Birthdate = DateTime.Today,
                Place = CategoryType.Cbba
            };

            //Act
            IHttpActionResult actionResult = tarea1Controller.PostTarea1(PruebaEsperada);
            var Tarea1Actual = actionResult as CreatedAtRouteNegotiatedContentResult<Tarea1>;

            //Assert
            Assert.IsNotNull(Tarea1Actual);
            Assert.AreEqual("DefaultApi", Tarea1Actual.RouteName);
            Assert.AreEqual(PruebaEsperada.FrinedofZambrana, Tarea1Actual.Content.FrinedofZambrana);
            Assert.AreEqual(PruebaEsperada.ZambranaID, Tarea1Actual.Content.ZambranaID);
            Assert.AreEqual(PruebaEsperada.Email, Tarea1Actual.Content.Email);
            Assert.AreEqual(PruebaEsperada.Birthdate, Tarea1Actual.Content.Birthdate);
            Assert.AreEqual(PruebaEsperada.Place, Tarea1Actual.Content.Place);
        }

        [TestMethod]
        public void TestDeleteTarea1()
        {
            //Arrange
            Tarea1Controller tarea1Controller = new Tarea1Controller();
            Tarea1 PruebaEsperada = new Tarea1()
            {
                FrinedofZambrana = "Maely Zambrana",
                ZambranaID = 1,
                Email = "maelysael@gmail.com",
                Birthdate = DateTime.Today,
                Place = CategoryType.Cbba
            };

            //Act
            IHttpActionResult actionResult = tarea1Controller.DeleteTarea1(PruebaEsperada.ZambranaID);

            //Assert
            Assert.IsNotInstanceOfType(actionResult, typeof(OkResult));
        }

        public void TestPutTarea1()
        {
            //Arrange
            Tarea1Controller tarea1Controller = new Tarea1Controller();
            Tarea1 PruebaEsperada = new Tarea1()
            {
                FrinedofZambrana = "Maely Zambrana",
                ZambranaID = 1,
                Email = "maelysael@gmail.com",
                Birthdate = DateTime.Today,
                Place = CategoryType.Cbba
            };
            String newname = "Maely Sael Zambrana";

            //Act
            var actionResult = tarea1Controller.PostTarea1(PruebaEsperada);
            PruebaEsperada.FrinedofZambrana = newname;
            var acctionResultPut = tarea1Controller.PutTarea1(PruebaEsperada.ZambranaID, PruebaEsperada) as StatusCodeResult;

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.NoContent, acctionResultPut.StatusCode);
            Assert.IsInstanceOfType(acctionResultPut, typeof(StatusCodeResult));

         
        }
    }
}
