using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProjectPhone
{
    [TestClass]
    public class PhoneTests
    {
        #region Constructor Tests

        [TestMethod]
        public void Constructor_ValidData_ShouldCreatePhone()
        {
            var phone = new Phone("Molenda", "123456789");

            Assert.AreEqual("Molenda", phone.Owner);
            Assert.AreEqual("123456789", phone.PhoneNumber);
            Assert.AreEqual(0, phone.Count);
        }

        [TestMethod]
        public void Constructor_OwnerEmpty_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Phone("", "123456789"));
        }

        [TestMethod]
        public void Constructor_OwnerNull_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Phone(null, "123456789"));
        }

        [TestMethod]
        public void Constructor_PhoneNull_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Phone("Molenda", null));
        }

        [TestMethod]
        public void Constructor_PhoneEmpty_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Phone("Molenda", ""));
        }

        [TestMethod]
        public void Constructor_PhoneTooShort_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Phone("Molenda", "123"));
        }

        [TestMethod]
        public void Constructor_PhoneTooLong_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Phone("Molenda", "1234567890"));
        }

        [TestMethod]
        public void Constructor_PhoneContainsLetters_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Phone("Molenda", "12345ABCD"));
        }

        #endregion


        #region AddContact Tests

        [TestMethod]
        public void AddContact_NewContact_ShouldReturnTrue_AndIncreaseCount()
        {
            var phone = new Phone("Molenda", "123456789");

            var result = phone.AddContact("John", "987654321");

            Assert.IsTrue(result);
            Assert.AreEqual(1, phone.Count);
        }

        [TestMethod]
        public void AddContact_DuplicateContact_ShouldReturnFalse()
        {
            var phone = new Phone("Molenda", "123456789");

            phone.AddContact("John", "987654321");
            var result = phone.AddContact("John", "111111111");

            Assert.IsFalse(result);
            Assert.AreEqual(1, phone.Count);
        }

        [TestMethod]
        public void AddContact_WhenPhoneBookFull_ShouldThrow()
        {
            var phone = new Phone("Molenda", "123456789");

            for (int i = 0; i < phone.PhoneBookCapacity; i++)
            {
                phone.AddContact($"Contact{i}", "111111111");
            }

            Assert.ThrowsException<InvalidOperationException>(() =>
                phone.AddContact("Overflow", "222222222"));
        }

        #endregion


        #region Call Tests

        [TestMethod]
        public void Call_ExistingContact_ShouldReturnCorrectMessage()
        {
            var phone = new Phone("Molenda", "123456789");
            phone.AddContact("John", "987654321");

            var result = phone.Call("John");

            Assert.AreEqual("Calling 987654321 (John) ...", result);
        }

        [TestMethod]
        public void Call_NonExistingContact_ShouldThrow()
        {
            var phone = new Phone("Molenda", "123456789");

            Assert.ThrowsException<InvalidOperationException>(() =>
                phone.Call("Unknown"));
        }

        #endregion
    }
}