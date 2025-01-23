using Microsoft.AspNetCore.Mvc;
using Moq;
using biblioteka.Controllers;
using biblioteka.Models;
using biblioteka.Services;
using Shared.Enums;

namespace UnitTests
{
    public class MediaControllerTests
    {
        List<MediaViewModel> media;
        Mock<IMediaService> mediaServiceMock;

        [SetUp]
        public void Setup()
        {
            // fill media model mock
            media = new List<MediaViewModel>();
            media.Add(new MediaViewModel() { Id = 1, Title = "Elden Ring", Author = "From Software", Status = Status.Finished, Category = Category.Game});
            media.Add(new MediaViewModel() { Id = 2, Title = "No Mud, No Lotus", Author = "Thich Nhat Hanh", Status = Status.Finished, Category = Category.Book });
            // create service mock
            mediaServiceMock = new Mock<IMediaService>();
        }

        [Test]
        public void TestIndexAction()
        {
            // Arrange
            this.mediaServiceMock.Setup(m => m.FindAll()).Returns(media);
            var mediaController = new MediaController(mediaServiceMock.Object);
            // Act
            var result = mediaController.Index();
            // Assert
            Assert.IsNotNull(result);
            Assert.True(result is ViewResult);
            var viewResult = result as ViewResult;
            Assert.IsTrue(string.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "Index");
            Assert.IsNotNull(viewResult.Model);
            Assert.IsTrue(viewResult.Model is List<MediaViewModel>);
            var mediaModel = viewResult.Model as List<MediaViewModel>;
            Assert.That(mediaModel, Has.Count.EqualTo(2));
        }

        [Test]
        public void TestGetCreateAction()
        {
            // Arrange
            //this.mediaServiceMock.Setup(m => m.Add()).Returns(5);
            var mediaController = new MediaController(mediaServiceMock.Object);

            // Act
            var result = mediaController.Create();

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result is ViewResult);
            var viewResult = result as ViewResult;
            Assert.IsTrue(string.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "Create");
        }

        [Test]
        public void TestPostCreateActionPositive()
        {
            // Arrange
            MediaViewModel viewModel = new MediaViewModel();
            //this.mediaServiceMock.Setup(m => m.Add(viewModel)).Returns(0);
            var mediaController = new MediaController(mediaServiceMock.Object);


            // Act
            var vm = new MediaViewModel() { Title = "Eyes Wide Shut", Author = "Stanley Kubrick", Status = Status.Finished, Category = Category.Movie };
            var result = mediaController.Create(vm);

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result is RedirectToActionResult);
        }


        [Test]
        public void TestPostCreateActionNegative()
        {
            // Arrange
            var mediaController = new MediaController(mediaServiceMock.Object);
            mediaController.ModelState.AddModelError("fakeError", "fakeError");

            // Act
            var vm = new MediaViewModel() { };
            var result = mediaController.Create(vm);

            // Assert
            Assert.IsNotNull(result);
            Assert.True(result is ViewResult);
        }

    }
}