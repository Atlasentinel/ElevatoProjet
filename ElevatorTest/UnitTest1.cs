using ElevatoProjet;

namespace ElevatorTest
{
    [TestClass]
    public class UnitTest1
    {

     

        [TestMethod]
        [DataRow(150,90)]
        public void InUser_CheckIfContainsEmployee_IsTrue(int maxElevatorWeight, int currentEmployeeWeight)
        {
            Employee _employee = new Employee();
            Elevator _elevator = new Elevator(maxElevatorWeight);
            _employee.Weight = currentEmployeeWeight;
            _elevator.InUser(_employee);
            Assert.IsTrue(_elevator.CurrentWeight == _employee.Weight);
        }

        [TestMethod]
        [DataRow(150, 90)]
        public void InUser_CheckIfContainsEmployee_IsFalse(int maxElevatorWeight, int currentEmployeeWeight)
        {
            Employee _employee = new Employee();
            Elevator _elevator = new Elevator(maxElevatorWeight);
            _employee.Weight = currentEmployeeWeight;
            _elevator.InUser(_employee);
            Assert.IsFalse(_elevator.CurrentWeight == _employee.Weight + 80);
        }

        [TestMethod]
        [DataRow(150, 90)]
        [DataRow(150, 30)]
        public void OutUser_CheckIfEmployeeIsIn_IsTrue(int maxElevatorWeight, int currentEmployeeWeight)
        {
            Employee _employee = new Employee();
            Elevator _elevator = new Elevator(maxElevatorWeight);
            _employee.Weight = currentEmployeeWeight;
            _elevator.OutUser(_employee);
            Assert.IsTrue(_elevator.CurrentWeight < _employee.Weight);
        }

        [TestMethod]
        [DataRow(150,90)]
        [DataRow(150, 0)]
        public void OutUser_CheckIfEmployeeIsOut_IsFalse(int maxElevatorWeight, int currentEmployeeWeight)
        {
            Employee _employee = new Employee();
            Elevator _elevator = new Elevator(maxElevatorWeight);
            _employee.Weight = currentEmployeeWeight;
            _elevator.OutUser(_employee);
            Assert.IsFalse(_elevator.CurrentWeight + _employee.Weight < _employee.Weight);
        }

        [TestMethod]
        [DataRow(90,95)]
        [DataRow(100, 200)]
        public void CheckMaxWeightAllowedReached_ShouldBeTrue(int maxElevatorWeight, int currentEmployeeWeight)
        {
            Employee _employee = new Employee();
            Elevator _elevator = new Elevator(maxElevatorWeight);
            _employee.Weight = currentEmployeeWeight;
            _elevator.CurrentWeight = _employee.Weight;
            _elevator.CheckMaxWeightAllowedReached();
            Assert.IsTrue(_elevator.CheckMaxWeightAllowedReached());
        }

        [TestMethod]
        [DataRow(150, 90)]
        [DataRow(3, 1)]
        public void CheckMaxWeightAllowedReached_ShouldBeFalse(int maxElevatorWeight, int currentEmployeeWeight)
        {
            Employee _employee = new Employee();
            Elevator _elevator = new Elevator(maxElevatorWeight);
            _employee.Weight = currentEmployeeWeight;
            _elevator.CurrentWeight = _employee.Weight;
            _elevator.CheckMaxWeightAllowedReached();
            Assert.IsFalse(_elevator.CheckMaxWeightAllowedReached());
        }

        [TestMethod]
        [DataRow(150,90,true)]
        public void GoToVipSection_ShouldBeTrue(int maxElevatorWeight, int currentEmployeeWeight, bool isExecutive)
        {
            Employee _employee = new Employee();
            _employee.IsExecutive = isExecutive;
            _employee.Weight = currentEmployeeWeight;
            Elevator _elevator = new Elevator(maxElevatorWeight);
            _elevator.CurrentWeight = _employee.Weight;
            Assert.IsTrue(_elevator.GoToVipSection(_employee));
        }

        [TestMethod]
        [DataRow(150, 90, false)]
        public void GoToVipSection_ShouldBeFalse_EmployeeNoVip(int maxElevatorWeight, int currentEmployeeWeight, bool isExecutive)
        {
            Employee _employee = new Employee();
            _employee.IsExecutive = isExecutive;
            _employee.Weight = currentEmployeeWeight;
            Elevator _elevator = new Elevator(maxElevatorWeight);
            _elevator.CurrentWeight = _employee.Weight;
            Assert.IsFalse(_elevator.GoToVipSection(_employee));
        }

        [TestMethod]
        [DataRow(150, 0, true)]
        public void GoToVipSection_ShouldBeFalse_ElevatorNoWeight(int maxElevatorWeight, int currentEmployeeWeight, bool isExecutive)
        {
            Employee _employee = new Employee();
            _employee.IsExecutive = isExecutive;
            _employee.Weight = currentEmployeeWeight;
            Elevator _elevator = new Elevator(maxElevatorWeight);
            _elevator.CurrentWeight = _employee.Weight;
            Assert.IsFalse(_elevator.GoToVipSection(_employee));
        }
    }
}