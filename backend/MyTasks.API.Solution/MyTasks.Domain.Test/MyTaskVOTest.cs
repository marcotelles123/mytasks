using MyTasks.API.DTOs;
using MyTasks.Domain.VO;

namespace MyTasks.Domain.Test
{
    public class Tests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            long id = 123;
            string title = "My Task";
            string description = "This is a task description.";

            // Act
            var taskVO = new MyTaskDTO { Id = id, Title = title, Description = description };

            // Assert
            Assert.AreEqual(id, taskVO.Id);
            Assert.AreEqual(title, taskVO.Title);
            Assert.AreEqual(description, taskVO.Description);
        }

        [Test]
        public void Properties_ShouldHaveGetAndSetAccessors()
        {
            // Arrange
            var taskVO = new MyTaskVO();

            // Act
            taskVO.Id = 456;
            taskVO.Title = "Another Task";
            taskVO.Description = "New description";

            // Assert
            Assert.AreEqual(456, taskVO.Id);
            Assert.AreEqual("Another Task", taskVO.Title);
            Assert.AreEqual("New description", taskVO.Description);
        }
    }
}