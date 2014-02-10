using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementSystem.Bll;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.Tests.Mocks;

namespace ProjectManagementSystem.Tests
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void AddTaskTest()
        {
            var task = new TaskInfo(1, "A", "B", 10, 20, 10);

            var fakeStorage = new FakeStorageForAddTask();
            var manager = new Manager(fakeStorage, new FakeTaskChecker(true), new FakeLogger());
            manager.AddTask(task);


            var storageTask = fakeStorage.AddedTask;
            Assert.AreEqual(task, storageTask, "Tasks should be same.");
        }

        [TestMethod]
        public void GetByIdAndIncreaseCounterTest_WrongIdTest()
        {
            var fakeStorage = new FakeStorageForWrongIdTest();

            var manager = new Manager(fakeStorage, new FakeTaskChecker(true), new FakeLogger());

            var task = manager.GetByIdAndIncreaseViewCounter(5);

            Assert.IsNull(task, "Task should be null!");
        }

        [TestMethod]
        public void GetByIdAndIncreaseCounterTest_ViewCountShouldBeIncreased()
        {
            var fakeStorage = new FakeStorageForCorrectTaskWithIncreasedCounter(15);
            var fakeTaskChecker = new FakeTaskChecker(true);
            var manager = new Manager(fakeStorage, fakeTaskChecker, new FakeLogger());

            var task = manager.GetByIdAndIncreaseViewCounter(5);

            Assert.IsNotNull(task, "Task should be not null!");
            Assert.AreEqual(16, task.ViewCounter);
        }

        [TestMethod]
        public void GetByIdAndIncreaseCounterTest_ViewCountShouldNotBeIncreased()
        {
            var fakeStorage = new FakeStorageForCorrectTaskWithIncreasedCounter(15);
            var fakeTaskChecker = new FakeTaskChecker(false);
            var manager = new Manager(fakeStorage, fakeTaskChecker, new FakeLogger());

            var task = manager.GetByIdAndIncreaseViewCounter(5);

            Assert.IsNotNull(task, "Task should be not null!");
            Assert.AreEqual(15, task.ViewCounter);
        }

    }
}
