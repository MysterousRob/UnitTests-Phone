using ClassLibrary;

namespace TestProjectPhone
{
    [TestClass]
    public class UnitTest1
    {
        // Test for the constructor with valid data
        [TestMethod]
        public void Test_Konstruktor_Dane_poprawne()
        {
            // Arrange
            var wlasciciel = "Molenda";
            var numerTelefonu = "123456789";

            // Act
            var phone = new Phone(wlasciciel, numerTelefonu);

            // Assert
            Assert.AreEqual(wlasciciel, phone.Owner);
            Assert.AreEqual(numerTelefonu, phone.PhoneNumber);
        }

        // Test for the constructor with invalid owner (empty string)
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Konstruktor_Owner_Null_Or_Empty()
        {
            // Arrange
            var wlasciciel = "";
            var numerTelefonu = "123456789";

            // Act
            new Phone(wlasciciel, numerTelefonu); 
        }

        // Test for the constructor with an invalid phone number
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Konstruktor_PhoneNumber_Invalid()
        {
            // Arrange
            var wlasciciel = "Molenda";
            var numerTelefonu = "123"; 

            // Act
            new Phone(wlasciciel, numerTelefonu);
        }

        // Test adding a contact
        [TestMethod]
        public void Test_AddContact_Valid()
        {
            // Arrange
            var phone = new Phone("Molenda", "123456789");
            var contactName = "John";
            var contactNumber = "987654321";

            // Act
            var result = phone.AddContact(contactName, contactNumber);

            // Assert
            Assert.IsTrue(result); 
            Assert.AreEqual(1, phone.Count); 
        }

        // Test for adding a contact when the phonebook is full
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_AddContact_PhoneBook_Full()
        {
            // Arrange
            var phone = new Phone("Molenda", "123456789");

        
            for (int i = 0; i < 100; i++)
            {
                phone.AddContact($"Contact{i}", "111111111");
            }

            // Act: 
            phone.AddContact("Overflow", "222222222");
        }

        // Test calling an existing contact
        [TestMethod]
        public void Test_Call_ExistingContact()
        {
            // Arrange
            var phone = new Phone("Molenda", "123456789");
            phone.AddContact("John", "987654321");

            // Act
            var result = phone.Call("John");

            // Assert
            Assert.AreEqual("Calling 987654321 (John) ...", result); 
        }

        // Test calling a non-existing contact
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_Call_NonExistingContact()
        {
            // Arrange
            var phone = new Phone("Molenda", "123456789");

            // Act: 
            phone.Call("Nonexistent");
        }
    }
}
