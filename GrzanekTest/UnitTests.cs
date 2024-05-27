using System.Collections.Generic;
using System.IO;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Xunit;
using Microsoft.Extensions.FileProviders;

namespace API.Tests
{
    public class ControllersTests
    {
        [Fact]
        public void GetBooks_ReturnsOkResult_WithListOfBooks()
        {
            // Arrange
            var controller = new BooksController(new TestWebHostEnvironment());

            // Act
            var result = controller.GetBooks() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Books>>(result.Value);
        }

        [Fact]
        public void AddBook_ReturnsOkResult_AfterAddingBook()
        {
            // Arrange
            var controller = new BooksController(new TestWebHostEnvironment());
            var book = new Books { Tytul = "Test Book", Autor = "Test Author" };

            // Act
            var result = controller.AddBook(book) as OkResult;
            var books = controller.GetBooks() as OkObjectResult;
            var booksList = books.Value as List<Books>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(books);
            Assert.Contains(booksList, b => b.Tytul == book.Tytul && b.Autor == book.Autor);
        }





        [Fact]
        public void GetToRead_ReturnsOkResult_WithListOfBooksToRead()
        {
            // Arrange
            var controller = new ToReadController(new TestWebHostEnvironment());

            // Act
            var result = controller.GetToRead() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ToRead>>(result.Value);
        }

        [Fact]
        public void AddToRead_ReturnsOkResult_AfterAddingBookToRead()
        {
            // Arrange
            var controller = new ToReadController(new TestWebHostEnvironment());
            var book = new ToRead { Tytul = "Test Book", Autor = "Test Author" };

            // Act
            var result = controller.AddToRead(book) as OkResult;
            var books = controller.GetToRead() as OkObjectResult;
            var booksList = books.Value as List<ToRead>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(books);
            Assert.Contains(booksList, b => b.Tytul == book.Tytul && b.Autor == book.Autor);
        }

        // Test implementation of IWebHostEnvironment for testing purposes
        private class TestWebHostEnvironment : IWebHostEnvironment
        {
            public string EnvironmentName { get; set; }
            public string ApplicationName { get; set; }
            public string WebRootPath { get; set; }
            public IFileProvider WebRootFileProvider { get; set; }
            public string ContentRootPath { get; set; }
            public IFileProvider ContentRootFileProvider { get; set; }

            public TestWebHostEnvironment()
            {
                ContentRootPath = Directory.GetCurrentDirectory(); // Set current directory as content root path
            }
        }
    }
}
