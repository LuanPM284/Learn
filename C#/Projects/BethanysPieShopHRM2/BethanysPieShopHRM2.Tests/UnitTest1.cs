using BethanysPieShopHRM2.HR;

namespace BethanysPieShopHRM2.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void PerformWork_Adds_NumberOfHours()
        {
            //Arrange
            Employee employee = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);

            int numberOfHours = 3;
            //Act
            employee.PerformWork(numberOfHours);

            //Assert
            Assert.Equal(numberOfHours, employee.numberOfHoursWorked);
        }

        [Fact]
        public void PerformWork_Adds_NumberOfHours_IfNoValueSpecified()
        {
            //Arrange
            Employee employee = new Employee("Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);

            //Act
            employee.PerformWork();

            //Assert
            Assert.Equal(1, employee.numberOfHoursWorked);
        }
    }
}